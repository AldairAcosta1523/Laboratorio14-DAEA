using Lab13C.Models;
using Lab13C.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab13C.Controllers.Request
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;

        // Objeto en el constructor como parametro
        // Inyeccion de dependencias

        public InvoiceCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]

        public void Insert(InvoiceRequestV1 request)
        {
            
            // Para vincular el CustomerID primero se tienen que crear campos
            // en la tabla CustomerID para de ahi proporcionar su FK ( Foreign Key )
            Invoice model = new Invoice();
            model.CustomerID = request.CustomerID;
            model.Date= DateTime.Now;
            model.InvoiceNumber = request.InvoiceNumber;
            model.Total= request.Total;
            model.Active = true;

            
            _context.Invoices.Add(model);
            _context.SaveChanges();

        }
    }
}
