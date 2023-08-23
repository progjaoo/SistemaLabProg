using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaLabProg.Model.Models;

namespace SistemaLabProg.Controllers
{
    public class TipoProdutoController : Controller
    {
        private readonly DBSISTEMASContext _dbcontext;

        public TipoProdutoController(DBSISTEMASContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var listTypeProduct = _dbcontext.TipoProduto.ToList();

            return View(listTypeProduct);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TipoProduto productType)
        {
            if(ModelState.IsValid)
            {
                _dbcontext.Entry(productType).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _dbcontext.SaveChanges();
            }
            return View(); 
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editProduct = _dbcontext.TipoProduto.FirstOrDefault(tp => tp.TipCodigo == id);

            return View(editProduct);
        }
        [HttpPost]
        public IActionResult Edit(TipoProduto tpproduto)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Entry(tpproduto).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                _dbcontext.SaveChanges();

                return View(tpproduto);
            }
            ViewData["MensagemError"] = "Ocorreu um Erro";
            return View(tpproduto);
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var deleteProduct = _dbcontext.TipoProduto.FirstOrDefault(dp => dp.TipCodigo == id);
            _dbcontext.Entry(deleteProduct).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details (int id)
        {
            var tipoProduto = _dbcontext.TipoProduto.Find(id);
            return View(tipoProduto);
        }
    }
}
