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
        throw new NotImplementedException();
    }

    public void TDelete(Guide entity)
    {
        throw new NotImplementedException();
    }

    public List<Guide> TGetAll()
    {
       return _guideDal.GetAll();
    }

    public Guide TGetByID(int id)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(Guide entity)
    {
        throw new NotImplementedException();
    }
}
