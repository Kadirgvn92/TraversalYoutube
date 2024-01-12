
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]
public class PdfReportController : Controller
{
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

    public IActionResult StaticCustomerReport()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreport/" + "dosya2.pdf");
        using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            PdfPTable pdfTable = new PdfPTable(3);
            pdfTable.AddCell("Misafir Adı");
            pdfTable.AddCell("Misafir Soyadı");
            pdfTable.AddCell("Misafir TC");

            pdfTable.AddCell("Kadir");
            pdfTable.AddCell("GÜVEN");
            pdfTable.AddCell("123123123123123");

            document.Add(pdfTable);
            document.Close();

        }
        return File("/pdfreport/dosya2.pdf", "application/pdf", "dosya2.pdf");
    }
}
