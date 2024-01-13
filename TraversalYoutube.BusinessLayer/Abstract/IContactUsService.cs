using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Abstract;
public interface IContactUsService : IGenericService<ContactUs>
{
    List<ContactUs> GetListContactUsByTrue();
    List<ContactUs> GetListContactUsByFalse();
    void ContactUsStatusChangeToFalse(int id);
}
