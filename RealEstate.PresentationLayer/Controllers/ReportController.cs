using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

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
    }
}
