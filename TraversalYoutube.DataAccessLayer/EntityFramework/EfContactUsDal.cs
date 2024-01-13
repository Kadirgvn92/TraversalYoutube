using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.Repository;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.DataAccessLayer.EntityFramework;
public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
{
    public void ContactUsStatusChangeToFalse(int id)
    {
       throw new NotImplementedException();
    }

    public List<ContactUs> GetListContactUsByFalse()
    {
        using (var context = new Context())
        {
            var values = context.ContactUses.Where(X => X.MessageStatus == false).ToList();
            return values;
        };
    }

    public List<ContactUs> GetListContactUsByTrue()
    {
        using (var context = new Context())
        {
            var values = context.ContactUses.Where(X => X.MessageStatus == true).ToList();
            return values;
        };
    }
}
