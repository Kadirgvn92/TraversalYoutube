using OfficeOpenXml;
using TraversalYoutube.BusinessLayer.Abstract;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class ExcelManager : IExcelService
{
    public byte[] ExcelList<T>(List<T> t) where T : class
    {
        ExcelPackage excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("Sayfa-1");
        workSheet.Cells["A1"].LoadFromCollection(t,true,OfficeOpenXml.Table.TableStyles.Light10);

        return excel.GetAsByteArray();
    }
}
