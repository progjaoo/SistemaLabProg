using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaLabProg.Model.Models;

namespace SistemaLabProg.Controllers
{
    public class TipoPagamentoController : Controller
    {
        private readonly DBSISTEMASContext _dbcontext;

        public TipoPagamentoController(DBSISTEMASContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var listPayment = _dbcontext.TipoPagamento.ToList();

            return View(listPayment);
        }
        [HttpGet]
        public ActionResult Details(int id) 
        {
            var paymentType = new TipoPagamento();
            paymentType = _dbcontext.TipoPagamento.FirstOrDefault(tp => tp.TpgCodigo == id);

            return View(paymentType);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var paymentType = _dbcontext.TipoPagamento.FirstOrDefault(p => p.TpgCodigo == id);
            return View(paymentType);   
        }
        [HttpPost]
        public IActionResult Edit(TipoPagamento paymentType)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Entry(paymentType).State = EntityState.Modified;
                _dbcontext.SaveChanges();

                return View(paymentType);
            }
            ViewData["MensagemError"] = "Ocorreu um Erro";
            return View(paymentType);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoPagamento paymentType)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Entry(paymentType).State = EntityState.Added;
                _dbcontext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(ModelState.IsValid)
            {
                var deletePayment = _dbcontext.TipoPagamento.FirstOrDefault(dp => dp.TpgCodigo == id);
                _dbcontext.Entry(deletePayment).State = EntityState.Deleted;
                _dbcontext.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
    }
}
