using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class TestimonailManager : ITestimonailService
{
    private readonly ITestimonailDal _testimonailDal;

    public TestimonailManager(ITestimonailDal testimonailDal)
    {
        _testimonailDal = testimonailDal;
    }

    public void TAdd(Testimonail entity)
    {
        throw new NotImplementedException();
    }

    public void TDelete(Testimonail entity)
    {
        throw new NotImplementedException();
    }

    public List<Testimonail> TGetAll()
    {
       return _testimonailDal.GetAll();
    }

    public Testimonail TGetByID(int id)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(Testimonail entity)
    {
        throw new NotImplementedException();
    }
}
