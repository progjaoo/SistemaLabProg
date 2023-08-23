using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaLabProg.Model.Models;

namespace SistemaLabProg.Controllers
{
    public class DescricaoController : Controller
    {
        private readonly DBSISTEMASContext _dbcontext;

        public DescricaoController(DBSISTEMASContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var listUnity = _dbcontext.Unidade.ToList();

            return View(listUnity);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Unidade unity)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Entry(unity).State = EntityState.Added;
                _dbcontext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editUnity = _dbcontext.Unidade.FirstOrDefault(u => u.UnCodigo == id);

            return View(editUnity);
        }
        [HttpPost]
        public IActionResult Edit(Unidade unity)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Entry(unity).State = EntityState.Modified;
                _dbcontext.SaveChanges();

                return View(unity);
            }
            ViewData["MensagemError"] = "Ocorreu um Erro";
            return View(unity);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deleteUnity = _dbcontext.Unidade.FirstOrDefault(dp => dp.UnCodigo == id);
            _dbcontext.Entry(deleteUnity).State = EntityState.Deleted;
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var unity = _dbcontext.Unidade.Find(id);
            return View(unity);
        }
    }
}
