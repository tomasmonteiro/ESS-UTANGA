using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoEscolar.Common;
using SistemaDeGestaoEscolar.Data.Domain;
using SistemaDeGestaoEscolar.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeGestaoEscolar.WebApp
{
    public class CadastroUserController : BaseController
    {
        private const string _senhaPadrao = "senhapadrao";

        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<GestaoUser> _userManager;

        private async Task SetPerfis()
        {
            var perfis = new Dictionary<int, string>();
            (await _roleManager.Roles.ToListAsync()).ForEach(role => perfis.Add(role.Id, role.Name));
            ViewData["perfis"] = perfis;
        }

        public CadastroUserController(UserManager<GestaoUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [GestaoAuthorize(DireitoDeAcessoEnum.AcessarCadastroUsuario)]
        public async Task<IActionResult> Index()
        {
            await SetPerfis();
            var users = (await _userManager.Users.ToListAsync()).ToViewModel();
            return View(users);
        }

        [HttpGet]
        [GestaoAuthorize(DireitoDeAcessoEnum.IncluirAlterarCadastroUsuario)]
        public async Task<IActionResult> Incluir(CadastroUserViewModel model)
        {
            await SetPerfis();
            return View("Manutencao", model);
        }

        [HttpGet]
        [GestaoAuthorize(DireitoDeAcessoEnum.IncluirAlterarCadastroUsuario)]
        public async Task<IActionResult> Alterar(int id)
        {
            await SetPerfis();
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            var model = user.ToViewModel();

            var roleNames = await _userManager.GetRolesAsync(user);
            if (roleNames.Count > 0)
            {
                var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == roleNames.First());

                model.Perfil = role.Id;
            }

            return View("Manutencao", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [GestaoAuthorize(DireitoDeAcessoEnum.IncluirAlterarCadastroUsuario)]
        public async Task<IActionResult> Salvar(CadastroUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult ret;
                var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == model.Perfil);

                if (model.Id <= 0) // inclusão
                {
                    var user = model.ToDomain();
                    ret = await _userManager.CreateAsync(user, _senhaPadrao);
                    if (ret.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                }
                else // alteração
                {
                    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
                    user.NomeCompleto = model.Nome;
                    user.Email = model.Email;

                    ret = await _userManager.UpdateAsync(user);
                    if (ret.Succeeded)
                    {
                        var roleNames = await _userManager.GetRolesAsync(user);
                        if (roleNames.Count > 0)
                        {
                            var roleAnterior = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == roleNames.First());

                            await _userManager.RemoveFromRoleAsync(user, roleAnterior.Name);
                        }

                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                }

                if (ret.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var erro in ret.Errors)
                {
                    ModelState.AddModelError(string.Empty, erro.Description);
                }
            }

            await SetPerfis();
            return View("Manutencao", model);
        }

        [HttpDelete]
        [GestaoAuthorize(DireitoDeAcessoEnum.ExcluirCadastroUsuario)]
        public async Task<JsonResult> Excluir(int id)
        {
            if (id > 0)
            {
                var role = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
                var ret = await _userManager.DeleteAsync(role);

                return Json(ret.Succeeded);
            }
            else
            {
                return Json(false);
            }
        }
    }
}