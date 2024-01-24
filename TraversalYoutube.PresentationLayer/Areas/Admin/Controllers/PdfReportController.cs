using AutoMapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.DTOLayer.DTOs.DestinationDTOs;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class PdfReportController : Controller
{
    private readonly IMapper _mapper;

    public PdfReportController(IMapper mapper)
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

        var guideModels1 = context.Guides.ToList();
        guideModels = _mapper.Map<List<GuideModel>>(guideModels1);
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
    public IActionResult StaticPdfReport()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreport/" + "dosya1.pdf");
        using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");
            document.Add(paragraph);
            document.Close();
            
        }
        return File("/pdfreport/dosya1.pdf", "application/pdf", "dosya1.pdf");
    }
    public IActionResult DestinationPDFReport()
    {

        string pdfDate = DateTime.Now.ToShortDateString();
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreport/" + $"TurRotaları - {pdfDate}.pdf");
        using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            Document document = new Document(PageSize.A4.Rotate()); //Rotate yatay olmasını sağlar
            PdfWriter.GetInstance(document, stream);

            document.Open();


            var image = "Traversal-Liberty/assets/images/tr.png"; 

            IWebHostEnvironment hostingEnvironment = HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();
            string imagePath = Path.Combine(hostingEnvironment.WebRootPath, image);

            Image logo = Image.GetInstance(imagePath);
            logo.ScaleAbsolute(100f, 100f); 
            logo.Alignment = Image.ALIGN_CENTER;

            document.Add(logo);

            Paragraph title = new Paragraph($"Tur Rotaları - {pdfDate}");
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10f; 

            document.Add(title);

            PdfPTable pdfTable = new PdfPTable(4);
            
            pdfTable.AddCell("Sehir");
            pdfTable.AddCell("Konaklama Süresi");
            pdfTable.AddCell("Fiyat");
            pdfTable.AddCell("Kapasite");

            foreach (var item in DestinationList())
            {
                pdfTable.AddCell(item.City);
                pdfTable.AddCell(item.DayNight);
                pdfTable.AddCell(item.Price.ToString());
                pdfTable.AddCell(item.Capacity.ToString());
            }

            document.Add(pdfTable);
            document.Close();

        }
        return File($"/pdfreport/TurRotaları - {pdfDate}.pdf", "application/pdf", $"TurRotaları - {pdfDate}.pdf");
    }
    public IActionResult GuestPDFReport()
    {
        string pdfDate = DateTime.Now.ToShortDateString();
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreport/" + $"Kullanıcılar Listesi - {pdfDate}.pdf");
        using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            Document document = new Document(PageSize.A4.Rotate());
            PdfWriter.GetInstance(document, stream);

            document.Open();

            var image = "Traversal-Liberty/assets/images/tr.png";

            IWebHostEnvironment hostingEnvironment = HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();
            string imagePath = Path.Combine(hostingEnvironment.WebRootPath, image);

            Image logo = Image.GetInstance(imagePath);
            logo.ScaleAbsolute(100f, 100f); // Logo boyutunu ayarla
            logo.Alignment = Image.ALIGN_CENTER;

            // Rapor başına logo ekle
            document.Add(logo);

            Paragraph title = new Paragraph($"Kullanıcı Listesi - {pdfDate}");
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10f; // Başlık ile logo arasında bir boşluk bırak

            document.Add(title);

            PdfPTable pdfTable = new PdfPTable(6);

            float[] columnWidths = new float[] { 1f, 2f, 2f, 2f, 3f, 3f };
            pdfTable.SetWidths(columnWidths);

            pdfTable.AddCell("#");
            pdfTable.AddCell("Ad");
            pdfTable.AddCell("Soyad");
            pdfTable.AddCell("Kullanıcı Adı");
            pdfTable.AddCell("Mail Adresi");
            pdfTable.AddCell("Telefon Numarası");

            int count = 0;

            foreach (var item in GuestList())
            {
                count++;
                pdfTable.AddCell(count.ToString());
                pdfTable.AddCell(item.Name);
                pdfTable.AddCell(item.Surname);
                pdfTable.AddCell(item.Username);
                pdfTable.AddCell(item.Email);
                pdfTable.AddCell(item.PhoneNumber);
            }

            document.Add(pdfTable);
            document.Close();

        }
        return File($"/pdfreport/Kullanıcılar Listesi - {pdfDate}.pdf", "application/pdf", $"Kullanıcılar Listesi - {pdfDate}.pdf");
    }
    public IActionResult GuidePDFReport()
    {
        string pdfDate = DateTime.Now.ToShortDateString();
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreport/" + $"Rehber Listesi - {pdfDate}.pdf");
        using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            Document document = new Document(PageSize.A4.Rotate());
            PdfWriter.GetInstance(document, stream);

            document.Open();

            var image = "Traversal-Liberty/assets/images/tr.png";

            IWebHostEnvironment hostingEnvironment = HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();
            string imagePath = Path.Combine(hostingEnvironment.WebRootPath, image);

            Image logo = Image.GetInstance(imagePath);
            logo.ScaleAbsolute(100f, 100f); 
            logo.Alignment = Image.ALIGN_CENTER;

            document.Add(logo);

            Paragraph title = new Paragraph($"Rehber Listesi - {pdfDate}");
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10f; 

            document.Add(title);

            PdfPTable pdfTable = new PdfPTable(5);

            float[] columnWidths = new float[] { 1f, 2f, 3f, 3f, 1f};
            pdfTable.SetWidths(columnWidths);

            pdfTable.DefaultCell.NoWrap = false; 
            pdfTable.DefaultCell.FixedHeight = 30; 

            pdfTable.AddCell("#");
            pdfTable.AddCell("Ad");
            pdfTable.AddCell("Açıklama ");
            pdfTable.AddCell("2. Açıklama");
            pdfTable.AddCell("Durum");

            int count = 0;

            foreach (var item in GuideList())
            {
                count++;
                pdfTable.AddCell(count.ToString());
                pdfTable.AddCell(item.Name);
                pdfTable.AddCell(item.Description);
                pdfTable.AddCell(item.Description2);
                pdfTable.AddCell(item.Status ? "Aktif" : "Pasif");
            }

            document.Add(pdfTable);
            document.Close();

        }
        return File($"/pdfreport/Rehber Listesi - {pdfDate}.pdf", "application/pdf", $"Rehber Listesi - {pdfDate}.pdf");
    }
    public IActionResult CommentPDFReport()
    {
        string pdfDate = DateTime.Now.ToShortDateString();
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreport/" + $"Yorum Listesi - {pdfDate}.pdf");
        using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            Document document = new Document(PageSize.A4.Rotate());
            PdfWriter.GetInstance(document, stream);

            document.Open();

            var image = "Traversal-Liberty/assets/images/tr.png";

            IWebHostEnvironment hostingEnvironment = HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();
            string imagePath = Path.Combine(hostingEnvironment.WebRootPath, image);

            Image logo = Image.GetInstance(imagePath);
            logo.ScaleAbsolute(100f, 100f);
            logo.Alignment = Image.ALIGN_CENTER;

            document.Add(logo);

            Paragraph title = new Paragraph($"Yorum Listesi - {pdfDate}");
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10f;

            document.Add(title);

            PdfPTable pdfTable = new PdfPTable(5);

            float[] columnWidths = new float[] { 1f, 2f, 2f, 5f, 2f };
            pdfTable.SetWidths(columnWidths);

            pdfTable.DefaultCell.NoWrap = false;
            pdfTable.DefaultCell.FixedHeight = 30;

            pdfTable.AddCell("#");
            pdfTable.AddCell("Kullanıcı Adı");
            pdfTable.AddCell("Tur Rotası ");
            pdfTable.AddCell("Yorum");
            pdfTable.AddCell("Yorum Tarihi");

            int count = 0;

            foreach (var item in CommentList())
            {
                count++;
                pdfTable.AddCell(count.ToString());
                pdfTable.AddCell(item.Username);
                pdfTable.AddCell(item.Destination);
                pdfTable.AddCell(item.Comment);
                pdfTable.AddCell(item.Date.ToShortDateString());
            }

            document.Add(pdfTable);
            document.Close();

        }
        return File($"/pdfreport/Yorum Listesi - {pdfDate}.pdf", "application/pdf", $"Yorum Listesi - {pdfDate}.pdf");
    }
}
