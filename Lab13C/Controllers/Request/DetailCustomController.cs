using Humanizer;
using Lab13C.Models;
using Lab13C.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab13C.Controllers.Request
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;

        // Objeto en el constructor como parametro
        // Inyeccion de dependencias

        public DetailCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]

        public void InsertDetail(int InvoiceId, List<DetailInvoiceRequestV1> request)
        {
            var inv = _context.Invoices.Where(x => x.InvoiceID == InvoiceId).FirstOrDefault();
            foreach (var detail in request)
            {
                var prod = _context.Products.Where(x => x.ProductID == detail.ProductId).FirstOrDefault();
                Detail model = new Detail();
                model.Amount = detail.Amount;
                model.Price = prod.Price;
                model.SubTotal = detail.Amount * prod.Price;
                model.InvoiceID = InvoiceId;
                model.ProductID = detail.ProductId;
                model.Active = true;
                _context.Details.Add(model);
                inv.Details.Add(model);
            }
            _context.SaveChanges();

        }

    }
}
