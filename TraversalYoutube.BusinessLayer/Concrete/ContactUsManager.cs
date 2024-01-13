using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class ContactUsManager : IContactUsService
{
    private readonly IContactUsDal _contactUsDal;

    public ContactUsManager(IContactUsDal contactUsDal)
    {
        _contactUsDal = contactUsDal;
    }

    public void ContactUsStatusChangeToFalse(int id)
    {
        _contactUsDal.ContactUsStatusChangeToFalse(id);
    }

    public List<ContactUs> GetListContactUsByFalse()
    {
       return _contactUsDal.GetListContactUsByFalse();
    }

    public List<ContactUs> GetListContactUsByTrue()
    {
        return _contactUsDal.GetListContactUsByTrue();
    }

    public void TAdd(ContactUs entity)
    {
        _contactUsDal.Insert(entity);
    }

    public void TDelete(ContactUs entity)
    {
        _contactUsDal.Delete(entity);
    }

    public List<ContactUs> TGetAll()
    {
        return _contactUsDal.GetAll();
    }

    public ContactUs TGetByID(int id)
    {
      return  _contactUsDal.GetByID(id);
    }

    public void TUpdate(ContactUs entity)
    {
        _contactUsDal.Update(entity);
    }
}
