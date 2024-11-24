using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;

namespace API.BusinessLayer
{
    public class BusinessLogic
    {
        private readonly DataContext _context;

        public BusinessLogic(DataContext context)
        {
            _context = context;
        }
        //--------------------------------------------Product Logik-----------------------------------
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Set<Product>().ToList();
        }

        public Product GetProduct(int id)
        {
            var query = "SELECT * FROM Aruk WHERE Id = @id";
            var parameter = new MySqlParameter("@id", id);

            return _context.Aruk.FromSqlRaw(query, parameter).FirstOrDefault();
        }

        public void AddProduct(Product product)
        {
            _context.Aruk.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Set<Product>().Attach(product);
            _context.Entry(product).State = EntityState.Modified;
        }


        //--------------------------------------------Role Logik-----------------------------------
        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Set<Role>().ToList();
        }

        public IEnumerable<Warehouse> GetAllWarehouse()
        {
            return _context.Set<Warehouse>().ToList();

        }
        public IEnumerable<AppUser> GetAllUsers()
        {
            return _context.Set<AppUser>().ToList();

        }
        //-----------------------------------------készlet logika----------------
        public IEnumerable<Stock> GetAllStock()
        {
            return _context.Set<Stock>().ToList();
        }

        public Stock GetOneStock(string WarehouseId, int productId)
        {
            return GetAllStock().FirstOrDefault(x => x.WarehouseId == WarehouseId && x.ProductId == productId);
        }
        public IEnumerable<Stock> GetStockbyWh(string WarehouseId)
        {
            return GetAllStock().Where(x => x.WarehouseId == WarehouseId);
        }

        public IEnumerable<Stock> GetStockbyProduct(int ProductId)
        {
            return GetAllStock().Where(x => x.ProductId == ProductId);
        }

        public void AddStock(Stock stock)
        {
            _context.Keszlet.Add(stock);
            _context.SaveChanges();
        }

        public void UpdateStock(string warehouseId, int productId, Stock stock)
        {
            var old = GetOneStock(warehouseId, productId);
            if(old != null)
            {
                
            }
            
            _context.Update(stock);
            _context.SaveChanges();
        }

        publi

        //---------------------------------------mozgatás logika--------------------
        public IEnumerable<Logistic> GetAllLogistics()
        {
            return _context.Set<Logistic>().ToList();
        }

        //--------------------Egyébb -----------------------


    }

}
