using Lab13C.Models;
using Lab13C.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13C.Controllers.Request
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;

        // Objeto en el constructor como parametro
        // Inyeccion de dependencias

        public ProductCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Insert(ProductRequestV1 request)

        {
            // Convertir Request a Modelo
            Product model = new Product();
            model.Price = request.Price;
            model.Name = request.Name;
            model.Active = true;

            _context.Products.Add(model);
            _context.SaveChangesAsync(); //Confirmacion o Commit
        }


        [HttpPost]

        public void Delete(ProductRequestV2 request) 
        {
            var model = _context.Products.Where(x => x.ProductID == request.ProductID).FirstOrDefault();
            _context.Entry(model).State = EntityState.Modified;
            model.Active = false;
            _context.SaveChanges();
        }


        [HttpPost]

        public void Update(ProductRequestV3 request)

        {

            // Se puede hacer de 2 formas 
            // var model = _context.Products.Find(request.ProductID);

            var model = _context.Products.Where(x => x.ProductID == request.ProductID).FirstOrDefault();
            // Prepararlo para modificar 
            _context.Entry(model).State = EntityState.Modified;
            // Asigno el Precio
            model.Price = request.Price;
            // Confirmacion o commit
            _context.SaveChanges();
        }



        [HttpPost]
        public void DeleteProducts(List<ProductRequestV2> request)
        {

            foreach (var prod in request)
            {
                var model = _context.Products.Where(x => x.ProductID == prod.ProductID).FirstOrDefault();
                _context.Entry(model).State = EntityState.Modified;
                model.Active = false;
                _context.SaveChanges();
            }
        }
    }
}
