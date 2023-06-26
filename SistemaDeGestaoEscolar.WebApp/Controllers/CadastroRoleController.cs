using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoEscolar.Common;
using SistemaDeGestaoEscolar.ViewModel;
using System.Threading.Tasks;

namespace SistemaDeGestaoEscolar.WebApp
{
    public class CadastroRoleController : BaseController
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public CadastroRoleController(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        [GestaoAuthorize(DireitoDeAcessoEnum.AcessarCadastroPerfilUsuario)]
        public async Task<IActionResult> Index()
        {
            var roles = (await _roleManager.Roles.ToListAsync()).ToViewModel();

            return View(roles);
        }

        [HttpGet]
        public IActionResult Incluir(CadastroRoleViewModel model)
        {
            return View("Manutencao", model);
        }

        [HttpGet]
        public async Task<IActionResult> Alterar(int id)
        {
            var entity = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            var model = entity.ToViewModel();

            return View("Manutencao", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(CadastroRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult ret;

                if (model.Id <= 0) // inclusão
                {
                    var role = model.ToDomain();
                    ret = await _roleManager.CreateAsync(role);
                }
                else // alteração
                {
                    var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == model.Id);
                    role.Name = model.Nome;
                    ret = await _roleManager.UpdateAsync(role);
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

            return View("Manutencao", model);
        }

        [HttpDelete]
        public async Task<JsonResult> Excluir(int id)
        {
            IdentityResult ret;

            if (id > 0)
            {
                var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
                ret = await _roleManager.DeleteAsync(role);

                return Json(ret.Succeeded);
            }
            else
            {
                return Json(false);
            }
        }
    }
}