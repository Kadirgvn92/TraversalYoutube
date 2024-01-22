using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.DTOLayer.DTOs.DestinationDTOs;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class ExcelController : Controller
{
    private readonly IMapper _mapper;

    public ExcelController(IMapper mapper)
    {
        _mapper = mapper;
    }
    public List<DestinationDTO> DestinationList()
    {
        List<DestinationDTO> destinationModels = new List<DestinationDTO>();
        using var context = new Context();

        var destinations = context.Destinations.ToList();

        destinationModels = _mapper.Map<List<DestinationDTO>>(destinations);

        return destinationModels;
    }

    public List<UserModel> GuestList()
    {
        List<UserModel> guestModels = new List<UserModel>();
        using var context = new Context();

        var guests = context.Users.ToList();
        guestModels = _mapper.Map<List<UserModel>>(guests);
        return guestModels;
    }
    public List<GuideModel> GuideList()
    {
        List<GuideModel> guideModels = new List<GuideModel>();
        using var context = new Context();

        var guides = context.Guides.ToList();
        guideModels = _mapper.Map<List<GuideModel>>(guides);
        return guideModels;
    }
    public List<CommentModel> CommentList()
    {
        List<CommentModel> commentModels = new List<CommentModel>();
        using var context = new Context();
        commentModels = context.Comments.Select(x => new CommentModel
        {
            Username = x.AppUser.UserName,
            Comment = x.CommentContent,
            Date = x.CommentDate,
            Destination = x.Destination.City

        }).ToList();
        return commentModels;
    }
    public IActionResult Index()
    {
        return View();  
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
            workSheet.Column(1).Width = 30;
            workSheet.Column(2).Width = 30;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 30;

            workSheet.RowHeight = 20;

            using (var steam = new MemoryStream())
            {
                workbook.SaveAs(steam);
                var content = steam.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TurListesi.xlsx");
            }

        }
    }
    public IActionResult GuestExcelReport()
    {
        using (var workbook = new XLWorkbook())
        {
            var workSheet = workbook.Worksheets.Add("Misafir Listesi");
            workSheet.Cell(1, 1).Value = "Ad";
            workSheet.Cell(1, 2).Value = "Soyad";
            workSheet.Cell(1, 3).Value = "Kullanıcı Adı";
            workSheet.Cell(1, 4).Value = "Mail Adresi";
            workSheet.Cell(1, 5).Value = "Telefon Numarası";

            int rowCount = 2;
            foreach (var item in GuestList())
            {
                workSheet.Cell(rowCount, 1).Value = item.Name;
                workSheet.Cell(rowCount, 2).Value = item.Surname;
                workSheet.Cell(rowCount, 3).Value = item.Username;
                workSheet.Cell(rowCount, 4).Value = item.Email;
                workSheet.Cell(rowCount, 5).Value = item.PhoneNumber;
                rowCount++;
            }

            workSheet.Column(1).Width = 30;
            workSheet.Column(2).Width = 30;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 30;
            workSheet.Column(5).Width = 30;


            workSheet.RowHeight = 20;


            using (var steam = new MemoryStream())
            {
                workbook.SaveAs(steam);
                var content = steam.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MisafirListesi.xlsx");
            }

        }
    }
    public IActionResult GuideExcelReport()
    {
        using (var workbook = new XLWorkbook())
        {
            var workSheet = workbook.Worksheets.Add("Rehber Listesi");
            workSheet.Cell(1, 1).Value = "Ad Soyad";
            workSheet.Cell(1, 2).Value = "Açıklama";
            workSheet.Cell(1, 3).Value = "2. Açıklama";
            workSheet.Cell(1, 4).Value = "Durum";

            int rowCount = 2;
            foreach (var item in GuideList())
            {
                workSheet.Cell(rowCount, 1).Value = item.Name;
                workSheet.Cell(rowCount, 2).Value = item.Description;
                workSheet.Cell(rowCount, 3).Value = item.Description2;
                workSheet.Cell(rowCount, 4).Value = item.Status ? "Aktif" : "Pasif";
                rowCount++;
            }

            workSheet.Column(1).Width = 30;
            workSheet.Column(2).Width = 30;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 30;


            workSheet.RowHeight = 20;


            using (var steam = new MemoryStream())
            {
                workbook.SaveAs(steam);
                var content = steam.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RehberListesi.xlsx");
            }
        }
    }
    public IActionResult CommentExcelReport()
    {
        using (var workbook = new XLWorkbook())
        {
            var workSheet = workbook.Worksheets.Add("Yorum Listesi");
            workSheet.Cell(1, 1).Value = "Kullanıcı Adı";
            workSheet.Cell(1, 2).Value = "Tur Rotası";
            workSheet.Cell(1, 3).Value = "Yorum";
            workSheet.Cell(1, 4).Value = "Yorum Tarihi";


            int rowCount = 2;
            foreach (var item in CommentList())
            {
                workSheet.Cell(rowCount, 1).Value = item.Username;
                workSheet.Cell(rowCount, 2).Value = item.Destination;
                workSheet.Cell(rowCount, 3).Value = item.Comment;
                workSheet.Cell(rowCount, 4).Value = item.Date;
                rowCount++;
            }

            workSheet.RowHeight = 20;

            workSheet.Column(1).Width = 30;  
            workSheet.Column(2).Width = 30;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 30;

            var range = workSheet.RangeUsed();
            range.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

            using (var steam = new MemoryStream())
            {
                workbook.SaveAs(steam);
                var content = steam.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YorumListesi.xlsx");
            }
        }
    }
}
