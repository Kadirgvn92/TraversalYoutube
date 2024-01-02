using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class SubAboutManager : ISubAboutService
{
    private readonly ISubAboutDal _subAboutDal;

    public SubAboutManager(ISubAboutDal subAboutDal)
    {
        _subAboutDal = subAboutDal;
    }

    public void TAdd(SubAbout entity)
    {
        throw new NotImplementedException();
    }

    public void TDelete(SubAbout entity)
    {
        throw new NotImplementedException();
    }

    public List<SubAbout> TGetAll()
    {
       return _subAboutDal.GetAll();
    }

    public SubAbout TGetByID(int id)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(SubAbout entity)
    {
        throw new NotImplementedException();
    }
}
