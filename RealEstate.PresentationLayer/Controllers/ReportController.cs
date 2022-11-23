using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using RealEstate.DataAccessLayer.Concrete;
using RealEstate.PresentationLayer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RealEstate.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class ReportController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticExcelList()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1");

            workSheet.Cells[1, 1].Value = "Personel ID";
            workSheet.Cells[1, 2].Value = "Personel Adı";
            workSheet.Cells[1, 3].Value = "Personel Soyadı";
            workSheet.Cells[1, 4].Value = "Personel Şehri";

            workSheet.Cells[2, 1].Value = "0001";
            workSheet.Cells[2, 2].Value = "Ezgi";
            workSheet.Cells[2, 3].Value = "Pektaş";
            workSheet.Cells[2, 4].Value = "Tekirdağ";

            workSheet.Cells[3, 1].Value = "0002";
            workSheet.Cells[3, 2].Value = "Emre";
            workSheet.Cells[3, 3].Value = "Ulusoy";
            workSheet.Cells[3, 4].Value = "Bursa";

            workSheet.Cells[4, 1].Value = "0003";
            workSheet.Cells[4, 2].Value = "Melek";
            workSheet.Cells[4, 3].Value = "Sungur";
            workSheet.Cells[4, 4].Value = "Ankara";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "akademi.xlsx");

        }

        public List<ProductReportViewModel> ProductList()
        {
            List<ProductReportViewModel> models = new List<ProductReportViewModel>();
            using (var c = new Context())
            {
                models = c.Products.Select(x => new ProductReportViewModel
                {
                    ProductTitle = x.Title,
                    ProductPrice = x.Price,
                    ProductDate = x.Date
                }).ToList();
            }

            return models;
        }

        public IActionResult ExcelDynamic()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("İlan Listesi");
                workSheet.Cell(1, 1).Value = "İlan Başlığı";
                workSheet.Cell(1, 2).Value = "İlan Fiyatı";
                workSheet.Cell(1, 3).Value = "İlan Tarihi";

                int rowCount = 2;
                foreach (var item in ProductList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.ProductTitle;
                    workSheet.Cell(rowCount, 2).Value = item.ProductPrice;
                    workSheet.Cell(rowCount, 3).Value = item.ProductDate;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "İlan_Listesi.xlsx");
                }
            }
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreport/" + "yenidosya.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("AspNet Core Real Estate Projesi");
            document.Add(paragraph);
            document.Close();
            return File("/pdfreport/yenidosya.pdf", "application/pdf", "yenidosya.pdf");
        }
    }
}
