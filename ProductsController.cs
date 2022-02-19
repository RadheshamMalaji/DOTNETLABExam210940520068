using LabExam210940520068.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabExam210940520068.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            SqlConnection sqlcn = new SqlConnection();
            sqlcn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LabExam210940520068;Integrated Security=True;";
            sqlcn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcn;
            cmd.CommandText = "Select * from Products";
            SqlDataReader data = cmd.ExecuteReader();
            while(data.Read())
            {
                Product p = new Product();
                p.ProductId = (int)data["ProductId"];
                p.ProductName = data["ProductName"].ToString();
                p.Description = data["Description"].ToString();
                p.Rate = (decimal)data["Rate"];
                p.CategoryName = data["CategoryName"].ToString();
                ViewBag.id = data["ProductId"];
                products.Add(p);
            }
            sqlcn.Close();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Product p)
        {
            try
            {
                List<Product> products = new List<Product>();
                SqlConnection sqlcn = new SqlConnection();
                sqlcn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LabExam210940520068;Integrated Security=True;";
                sqlcn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcn;
                cmd.CommandText = "update Products set ProductName=@ProductName,Description=@Description,Rate=@Rate,CategoryName=@CategoryName where ProductId=@ProductId";
                cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                cmd.Parameters.AddWithValue("@Description", p.Description);
                cmd.Parameters.AddWithValue("@Rate", p.Rate);
                cmd.Parameters.AddWithValue("@CategoryName", p.CategoryName);
                cmd.Parameters.AddWithValue("@ProductId", id);
                cmd.ExecuteNonQuery();
                sqlcn.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
