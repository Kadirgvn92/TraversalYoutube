using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Ink;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class ExcelController : Controller
{
    private readonly IExcelService _excelService;

    public ExcelController(IExcelService excelService)
    {
        _excelService = excelService;
    }

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
        return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "NewExcel.xlsx");
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
