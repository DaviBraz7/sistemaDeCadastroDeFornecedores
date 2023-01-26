using Microsoft.AspNetCore.Mvc;
using sistemaDeCadastroDeFornecedores.Models;
using sistemaDeCadastroDeFornecedores.Repositorio;

namespace sistemaDeCadastroDeFornecedores.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }
        public IActionResult Index()
        {
            var Fornecedores = _fornecedorRepositorio.BuscarTodos();
            return View(Fornecedores);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult Apagar(int id)
        {
            _fornecedorRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                _fornecedorRepositorio.Adicionar(fornecedor);
                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        [HttpPost]
        public IActionResult Alterar(FornecedorModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                _fornecedorRepositorio.Atualizar(fornecedor);
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }
    }
}
