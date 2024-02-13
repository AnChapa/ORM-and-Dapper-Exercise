using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            #region Department Section
            //var departmentRepo = new DapperDepartmentRepository(conn);
            //departmentRepo.InsertDepartment("Toys");
            //var departments = departmentRepo.GetAllDepartments();

            //foreach(var department in departments)
            //{
            //    Console.WriteLine($"{department.DepartmentID} - {department.Name}");
            //}
            #endregion

            #region Product Section
            var productRepo = new DapperProductRepository(conn);
            #region Update
            //var productToUpdate = productRepo.GetProduct(940);

            //productToUpdate.Name = "UPDATED!!!";
            //productToUpdate.Price = 999.99;
            //productToUpdate.CategoryID = 1;
            //productToUpdate.OnSale = false;
            //productToUpdate.StockLevel = 1;

            //productRepo.UpdateProduct(productToUpdate);
            #endregion

            #region Delete
            //productRepo.DeleteProduct(940);
            #endregion

            var products = productRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} - {product.Name} - {product.Price} - {product.CategoryID} - {product.OnSale} - {product.StockLevel}");
                Console.WriteLine("---------------------------------------------------");
            }
            #endregion
        }
    }
}
