using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class ExcelController : Controller
{
    public IActionResult Index()
    {
        return View();  
    }
    public List<DestinationModel> DestinationList()
    {
        List<DestinationModel> destinationModels = new List<DestinationModel>();
        using var context = new Context();
        destinationModels = context.Destinations.Select(x => new DestinationModel
        {
            City = x.City,
            DayNight = x.DayNight,
            Price = x.Price,
            Capacity = x.Capacity
        }).ToList();
        return destinationModels;
    }

    public IActionResult StaticExcelReport()
    {
        ExcelPackage excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("Sayfa-1");
        workSheet.Cells[1, 1].Value = "Rota";
        workSheet.Cells[1, 2].Value = "Rehber";
        workSheet.Cells[1, 3].Value = "Kontenjan";

        workSheet.Cells[2, 1].Value = "Gürcistan/Batum";
        workSheet.Cells[2, 2].Value = "Can Yıldız";
        workSheet.Cells[2, 3].Value = "50";

        workSheet.Cells[3, 1].Value = "Sırbistan";
        workSheet.Cells[3, 2].Value = "Gamze ULAŞ";
        workSheet.Cells[3, 3].Value = "35";

        var bytes = excel.GetAsByteArray();
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya1.xlsx");
    }

    public IActionResult DestinationExcelReport()
    {
        using (var workbook = new XLWorkbook())
        {
            var workSheet = workbook.Worksheets.Add("Tur Listesi");
            workSheet.Cell(1, 1).Value = "Tur";
            workSheet.Cell(1, 2).Value = "Konaklama Süresi";
            workSheet.Cell(1, 3).Value = "Fiyat";
            workSheet.Cell(1, 4).Value = "Kapasite";

            int rowCount = 2;
            foreach(var item in DestinationList())
            {
                workSheet.Cell(rowCount,1).Value = item.City;
                workSheet.Cell(rowCount,2).Value = item.DayNight;
                workSheet.Cell(rowCount,3).Value = item.Price;
                workSheet.Cell(rowCount,4).Value = item.Capacity;
                rowCount++;
            }

            using (var steam = new MemoryStream())
            {
                workbook.SaveAs(steam);
                var content = steam.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TurListesi.xlsx");
            }

        }
    }
}
