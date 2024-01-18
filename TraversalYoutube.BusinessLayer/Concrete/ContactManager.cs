using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public void TAdd(Contact entity)
    {
        throw new NotImplementedException();
    }

    public void TDelete(Contact entity)
    {
        throw new NotImplementedException();
    }

    public List<Contact> TGetAll()
    {
        return _contactDal.GetAll();
    }

    public Contact TGetByID(int id)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(Contact entity)
    {
        throw new NotImplementedException();
    }
}
