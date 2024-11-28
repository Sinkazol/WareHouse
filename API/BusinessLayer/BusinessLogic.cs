using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net;

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
            if (GetProduct(product.Id) != null)
            {
                var query = "UPDATE `Aruk` SET `Description` = @description, `Price` = @price WHERE `Id` = @id";
                var parameters = new[]
                {
                    new MySqlParameter("@id", product.Id),
                    new MySqlParameter("@price", product.Price),
                    new MySqlParameter("@description", product.Description),
                };
                _context.Database.ExecuteSqlRaw(query, parameters);
            }
        }


        //--------------------------------------------Role Logik-----------------------------------
        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Set<Role>().ToList();
        }
        public Role GetOneRole(int id) { 
        return GetAllRoles().SingleOrDefault(x => x.Id == id);
        }

        public void  AddUser(AppUser user)
        {

        }

        //--------------------------------------------WareHouse Logik-----------------------------------
        public IEnumerable<Warehouse> GetAllWarehouse()
        {
            return _context.Set<Warehouse>().ToList();
        }
        public Warehouse GetOneWarehouse(string warehouseId)
        {
            return GetAllWarehouse().FirstOrDefault(x => x.Id == warehouseId);
        }

        public void CreateWarehouse(Warehouse warehouse)
        {
            _context.Add(warehouse);
            _context.SaveChanges();
        }
        public void UpdateWarehouse(Warehouse warehouse)
        {
            if (GetOneWarehouse(warehouse.Id) != null)
            {
                var query = "UPDATE `telephelyek` SET `Address` = @address WHERE `Id` = @id";
                var parameters = new[] {
                        new MySqlParameter("@address", warehouse.Address),
                        new MySqlParameter("@id", warehouse.Id)
                        };
                _context.Database.ExecuteSqlRaw(query, parameters);
            }
        }

        public void DeleteWarehouse(Warehouse warehouse)
        {
            _context.Remove(warehouse);
            _context.SaveChanges();
        }

        //--------------------------------------------User Logik-----------------------------------
        public IEnumerable<AppUser> GetAllUsers()
        {
            return _context.Set<AppUser>().ToList();
        }

        public AppUser GetOneUser(string email)
        {
          return  GetAllUsers().FirstOrDefault(x => x.Email == email);
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
        

        public void AddStock(Stock stock)
        {
            _context.Keszlet.Add(stock);
            _context.SaveChanges();
        }

        public void UpdateStock(string warehouseId, int productId, Stock stock)
        {
            var old = GetOneStock(warehouseId, productId);
            if (old != null)
            {
                DeleteStock(old);
                _context.Add(stock);
                _context.SaveChanges();
            }
        }

        public void DeleteStock(Stock stock)
        {
            _context.Remove(stock);
            _context.SaveChanges();
        }

        //-----------------------------view mmodel logika-------------------------

        //public List<ViewModelKeszlet> GetInventoryList()
        //{
        //    var query = from k in _context.Keszlet
        //                join a in _context.Aruk on k.ProductId equals a.Id
        //                join t in _context.Telephelyek on k.WarehouseId equals t.Id
        //                select new ViewModelKeszlet
        //                {
        //                    TermekNev = a.Name,
        //                    TermekLeiras = a.Description,
        //                    TermekAra = a.Price,
        //                    TermekMennyisege = k.Quantity,
        //                    TelephelyCime = t.Address
        //                };

        //    return query.ToList();
        //}

        public List<ViewModelKeszlet> GetInventoryList()
        {
            const string sql = @"
                                SELECT 
                                    a.Name AS TermekNev,
                                    a.Description AS TermekLeiras,
                                    a.Price AS TermekAra,
                                    k.Quantity AS TermekMennyisege,
                                    t.Address AS TelephelyCime
                                FROM 
                                    Keszlet k
                                INNER JOIN 
                                    Aruk a ON k.ProductId = a.Id
                                INNER JOIN 
                                    Telephelyek t ON k.WarehouseId = t.Id";

            // SQL lekérdezés futtatása a DbContext-en keresztül
            var inventoryList = _context.ViewModelKeszlet.FromSqlRaw(sql).ToList();

            return inventoryList;

        }



        public ViewModelKeszlet? GetOneInventory(string warehouseId, int productId)
        {
            const string sql = @"
                                SELECT 
                                    a.Name AS TermekNev,
                                    a.Description AS TermekLeiras,
                                    a.Price AS TermekAra,
                                    k.Quantity AS TermekMennyisege,
                                    t.Address AS TelephelyCime
                                FROM 
                                    Keszlet k
                                INNER JOIN 
                                    Aruk a ON k.ProductId = a.Id
                                INNER JOIN 
                                    Telephelyek t ON k.WarehouseId = t.Id
                                WHERE 
                                    k.WarehouseId = {0} AND k.ProductId = {1}";

            // SQL lekérdezés futtatása a DbContext-en keresztül
            var inventory = _context.ViewModelKeszlet
                .FromSqlRaw(sql, warehouseId, productId)
                .FirstOrDefault(); // Egy elem visszaadása, vagy null ha nincs találat.

            return inventory;
        }

        public IEnumerable<ViewModelKeszlet> GetInventorybyWh(string WarehouseId)
        {
            const string sql = @"
                                SELECT 
                                    a.Name AS TermekNev,
                                    a.Description AS TermekLeiras,
                                    a.Price AS TermekAra,
                                    k.Quantity AS TermekMennyisege,
                                    t.Address AS TelephelyCime
                                FROM 
                                    Keszlet k
                                INNER JOIN 
                                    Aruk a ON k.ProductId = a.Id
                                INNER JOIN 
                                    Telephelyek t ON k.WarehouseId = t.Id
                                WHERE
                                    k.WarehouseId = {0}";

            // SQL lekérdezés futtatása a DbContext-en keresztül
            var inventoryList = _context.ViewModelKeszlet.FromSqlRaw(sql, WarehouseId).ToList();

            return inventoryList;
        }

        public IEnumerable<ViewModelKeszlet> GetInventorybyProduct(int ProductId)
        {
            const string sql = @"
                                SELECT 
                                    a.Name AS TermekNev,
                                    a.Description AS TermekLeiras,
                                    a.Price AS TermekAra,
                                    k.Quantity AS TermekMennyisege,
                                    t.Address AS TelephelyCime
                                FROM 
                                    Keszlet k
                                INNER JOIN 
                                    Aruk a ON k.ProductId = a.Id
                                INNER JOIN 
                                    Telephelyek t ON k.WarehouseId = t.Id
                                WHERE
                                    k.ProductId = {0}";

            // SQL lekérdezés futtatása a DbContext-en keresztül
            var inventoryList = _context.ViewModelKeszlet.FromSqlRaw(sql, ProductId).ToList();

            return inventoryList;
        }

        //---------------------------------------mozgatás logika--------------------
        public IEnumerable<Logistic> GetAllLogistics()
        {
            return _context.Set<Logistic>().ToList();
        }

        //--------------------Egyébb -----------------------


    }

}
