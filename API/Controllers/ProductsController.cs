using API.BusinessLayer;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly BusinessLogic _logic;

        public ProductsController(BusinessLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<Product>> GetProducts()
        {
            return Ok(_logic.GetAllProducts());
        }

        [HttpGet("{id:int}")] // api/products/2
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _logic.GetProduct(id);

            if (product == null) return NotFound();

            return product;
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            _logic.AddProduct(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteProduct(int id)
        {

            var product = _logic.GetProduct(id);
            if (product == null) return NotFound();
            _logic.DeleteProduct(product);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateProduct(int id, Product product)
        {

            var p = _logic.GetProduct(id);
            if (p == null) return NotFound();
            if (product == null) return BadRequest("Problen updateing product");
            _logic.UpdateProduct(product);
            return Ok();
        }
    }
}
