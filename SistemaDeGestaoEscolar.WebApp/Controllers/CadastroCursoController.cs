using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoEscolar.Common;
using SistemaDeGestaoEscolar.Repository.Interface;
using SistemaDeGestaoEscolar.ViewModel;
using System.Threading.Tasks;

namespace SistemaDeGestaoEscolar.WebApp
{
    public class CadastroCursoController : BaseController
    {
        private readonly IRepCurso _repCurso;

        public CadastroCursoController(IRepCurso repCurso)
        {
            _repCurso = repCurso;
        }

        [HttpGet]
        [GestaoAuthorize(DireitoDeAcessoEnum.AcessarCadastroCurso)]
        public async Task<IActionResult> Index()
        {
            var categorias = (await _repCurso.GetComCursos()).ToViewModel();

            return View(categorias);
        }

        [HttpGet]
        [GestaoAuthorize(DireitoDeAcessoEnum.IncluirAlterarCadastroCurso)]
        public IActionResult Incluir(CadastroCursoViewModel model)
        {
            return View("Manutencao", model);
        }

        [HttpGet]
        [GestaoAuthorize(DireitoDeAcessoEnum.IncluirAlterarCadastroCurso)]
        public async Task<IActionResult> Alterar(int id)
        {
            var entity = await _repCurso.GetCurso(id);
            var model = entity.ToViewModel();

            return View("Manutencao", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [GestaoAuthorize(DireitoDeAcessoEnum.IncluirAlterarCadastroCurso)]
        public async Task<IActionResult> Salvar(CadastroCursoViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool ret;
                var curso = model.ToDomain();

                if (model.Id <= 0) // inclusão
                {
                    ret = await _repCurso.Criar(curso);
                }
                else // alteração
                {
                    ret = await _repCurso.Alterar(curso);
                }

                if (ret)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Não foi possível gravar o curso");
                }
            }

            return View("Manutencao", model);
        }

        [HttpDelete]
        [GestaoAuthorize(DireitoDeAcessoEnum.ExcluirCadastroCurso)]
        public async Task<JsonResult> Excluir(int id)
        {
            var ret = false;

            if (id > 0)
            {
                ret = await _repCurso.Excluir(id);
            }

            return Json(ret);
        }
    }
}