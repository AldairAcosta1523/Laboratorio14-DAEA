using Lab13C.Models;
using Lab13C.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13C.Controllers.Request
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;

        // Objeto en el constructor como parametro
        // Inyeccion de dependencias

        public CustomerCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]

        public void Insert(CustomerRequestV1 request)
        {
            // Aqui llamamos al modelo ( Customer ) para instanciarlo en una variable model
            // y llamar al modelo de nuestra BD

            Customer model = new Customer();
            model.FirstName = request.FirstName;
            model.LastName = request.LastName;
            model.DocumentNumber = request.DocumentNumber;
            model.Active = true;

            _context.Customers.Add(model);
            _context.SaveChanges();
        }


        [HttpPost]
        public void Delete(CustomerRequestV2 request)
        {
            var model = _context.Customers.Where(x => x.CustomerID == request.CustomerID).FirstOrDefault();
            _context.Entry(model).State = EntityState.Modified;
            model.Active = false;
            _context.SaveChanges();
        }

        [HttpPost]

        public void Update(CustomerRequestV3 request)
        {
            var model= _context.Customers.Where(x => x.CustomerID==request.CustomerID).FirstOrDefault();
            // Prepararlo para modificar 
            _context.Entry(model).State = EntityState.Modified;
            // Asigno el Precio
            model.DocumentNumber = request.DocumentNumber ;
            // Confirmacion o commit
            _context.SaveChanges();

        }
    }
}
