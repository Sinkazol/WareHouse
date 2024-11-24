using API.BusinessLayer;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class StocksController : BaseApiController
    {


        private readonly BusinessLogic _logic;

        public StocksController(BusinessLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<Stock>> GetKeszletList()
        {
            return Ok(_logic.GetAllStock());
        }

        [HttpGet("{warehouseId}-{productId:int}")]
        public ActionResult<Stock> GetStock(string warehouseId, int productId)
        {
            var stock = _logic.GetOneStock(warehouseId, productId);
            if (stock == null) return NotFound("Product not found in the specified warehouse.");
            return Ok(stock);
        }

        [HttpGet("{warehouseId}")]
        public ActionResult<IReadOnlyList<Stock>> GetStockbyWareHouse(string warehouseId)
        {
            return Ok(_logic.GetStockbyWh(warehouseId));
        }
        [HttpGet("{productId:int}")]
        public ActionResult<IReadOnlyList<Stock>> GetStockbyProduct(int productId)
        {
            return Ok(_logic.GetStockbyProduct(productId));
        }
        [HttpPost]
        public ActionResult<Stock> CreateStock(Stock stock)
        {
            _logic.AddStock(stock);
            return CreatedAtAction("GetStock", new { warehouseId = stock.WarehouseId, productId = stock.ProductId }, stock);
        }

        [HttpPut("{warehouseId}-{productId:int}")]
        public ActionResult UpdateStock(string warehouseId, int productId,Stock stock) {
            if (stock == null || warehouseId == null) return NotFound();
            if (_logic.GetOneStock(warehouseId, productId) == null) return NotFound();
                _logic.UpdateStock(stock);

            return Ok();
        
        }
    }
}
