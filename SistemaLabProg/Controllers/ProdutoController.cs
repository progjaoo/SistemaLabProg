using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SistemaLabProg.Model.Models;

namespace SistemaLabProg.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DBSISTEMASContext _dbcontext;

        public ProdutoController(DBSISTEMASContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var productList = _dbcontext.Produto.ToList();
            return View(productList);
        }

        public void CarregaViewData()
        {
            ViewData["ProCodigoTipoProduto"] = new SelectList(_dbcontext.TipoProduto, "TipCodigo", "TipDescricao");
            ViewData["ProCodigoUnidade"] = new SelectList(_dbcontext.Unidade, "UnCodigo", "UnDescricao");
        }
        [HttpGet]
        public IActionResult Create ()
        {
            CarregaViewData();
            return View();
        }

        [HttpPost]
        public IActionResult Create (Produto produto)
        {

            if (ModelState.IsValid)
            {
                _dbcontext.Entry(produto).State = EntityState.Added;
                _dbcontext.SaveChanges();

                return View(produto);
            }
            else
            {
                return View();
            }
        }
    }
}
