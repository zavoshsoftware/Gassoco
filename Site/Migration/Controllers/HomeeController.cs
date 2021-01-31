using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MashadCarpet.Classes;
using LinqToExcel;
using ExcelDataReader;
using Models;

namespace Migration.Controllers
{
    public class HomeeController : Controller
    {
        // GET: Home
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            List<Product> products = db.Products.Where(a => a.ImageUrl.Contains('/')).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase upload)
        {
            //string pathToExcelFile = @"C:\Users\MASOUD\Desktop\ExcelFile.xlsx";
            string pathToExcelFile = Server.MapPath("~/GassoCo.xlsx");
            var excel = new ExcelQueryFactory(pathToExcelFile);

            string sheetName = "special";
            Guid productGroupId = new Guid("7a5a646f-3eb7-4c00-8922-87df92b1a819");

            var persons = from a in excel.Worksheet(sheetName) select a;

            Guid detailId = new Guid("2be0a03b-4495-4fc2-bab3-be4d72e8ab1f");
            Guid technicalplanId = new Guid("70d6da13-e72f-453c-a981-e5cc5283cfa2");

            foreach (var a in persons)
            {
                if (!string.IsNullOrEmpty(a["Title"]))
                {
                    Models.Product p = new Models.Product()
                    {
                        Id = Guid.NewGuid(),
                        Title = a["Title"],
                        Body = a["Description"],
                        TitleEn = a["Title-En"],
                        BodyEn = a["Description-en"],
                        ProductGroupId = productGroupId,
                        ImageUrl = "/Uploads/Product/" + a["photo"],
                        FlashImageUrl = "/Uploads/Product/" + a["3Dview"],

                        IsDelete = false,
                        SubmitDate = DateTime.Now,
                    };

                    db.Products.Add(p);

                    if (!string.IsNullOrEmpty(a["details"]))
                    {
                        string[] items = a["details"].ToString().Split('/');

                        foreach (string item in items)
                        {
                            ProducImage pi = new ProducImage()
                            {
                                Id = Guid.NewGuid(),
                                ProductId = p.Id,
                                ProductImageTypeId = detailId,
                                ImageUrl = "/Uploads/Product/ProductImage/" + item,

                                IsDelete = false,
                                SubmitDate = DateTime.Now,
                            };
                            db.ProducImages.Add(pi);
                        }
                    }

                    if (!string.IsNullOrEmpty(a["technicalplan"]))
                    {
                        string[] items = a["technicalplan"].ToString().Split('/');

                        foreach (string item in items)
                        {
                            ProducImage pi = new ProducImage()
                            {
                                Id = Guid.NewGuid(),
                                ProductId = p.Id,
                                ProductImageTypeId = technicalplanId,
                                ImageUrl = "/Uploads/Product/ProductImage/" + item,

                                IsDelete = false,
                                SubmitDate = DateTime.Now,
                            };

                            db.ProducImages.Add(pi);
                        }
                    }
                }
            }

            db.SaveChanges();


            //FileInfo file = new FileInfo(fileUpload.FileName);
            //ExcelPackage package = new ExcelPackage(file);

            //DataTable datasource = package.ToDataTable();

            //// List<string> newproList = new List<string>();

            //foreach (DataRow dr in datasource.Rows)
            //{

            //    string ProductName = dr["FldNaghshe"].ToString();
            //    string colortoret = dr["FldZamine"].ToString();

            //}

            return View();
        }
    }
}