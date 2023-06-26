using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoEscolar.Data.Domain;
using SistemaDeGestaoEscolar.ViewModel;
using System.Threading.Tasks;

namespace SistemaDeGestaoEscolar.WebApp
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly UserManager<GestaoUser> _userManager;
        private readonly SignInManager<GestaoUser> _signInManager;

        private IActionResult RedirectLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        public AccountController(UserManager<GestaoUser> userManager, SignInManager<GestaoUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Registro(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(RegistroViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var usuario = model.ToDmain();

                var ret = await _userManager.CreateAsync(usuario, model.Senha);

                if (ret.Succeeded)
                {
                    await _signInManager.SignInAsync(usuario, false);

                    return RedirectLocal(returnUrl);
                }

                foreach (var erro in ret.Errors)
                {
                    ModelState.AddModelError(string.Empty, erro.Description);
                }
            }

            return View(model);
         
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var ret = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, model.MeLembrar, false);

                if (ret.Succeeded)
                {
                    return RedirectLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login inválido.");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        [ResponseCache(Duration =0, Location =ResponseCacheLocation.None, NoStore =true)]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}