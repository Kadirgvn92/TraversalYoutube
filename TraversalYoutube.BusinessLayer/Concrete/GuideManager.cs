using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class GuideManager : IGuideService
{
    private readonly IGuideDal _guideDal;

    public GuideManager(IGuideDal guideDal)
    {
        _guideDal = guideDal;
    }

    public void TAdd(Guide entity)
    {
       _guideDal.Insert(entity);
    }

    public void TChangeToFalseByGuide(int id)
    {
        _guideDal.ChangeToFalseByGuide(id);
    }

    public void TChangeToTrueByGUide(int id)
    {
        _guideDal.ChangeToTrueByGUide(id);
    }

    public void TDelete(Guide entity)
    {
        _guideDal.Delete(entity);
    }

    public List<Guide> TGetAll()
    {
       return _guideDal.GetAll();
    }

    public Guide TGetByID(int id)
    {
        return _guideDal.GetByID(id);
    }

    public void TUpdate(Guide entity)
    {
        _guideDal.Update(entity);
    }
}
