using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public void TAdd(About entity)
    {
        _aboutDal.Insert(entity);
    }

    public void TDelete(About entity)
    {
        _aboutDal.Delete(entity);
    }

    public List<About> TGetAll()
    {
        return _aboutDal.GetAll();
    }

    public About TGetByID(int id)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(About entity)
    {
       _aboutDal.Update(entity);
    }
}
