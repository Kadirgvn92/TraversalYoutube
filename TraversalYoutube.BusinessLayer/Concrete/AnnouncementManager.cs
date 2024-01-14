using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class AnnouncementManager : IAnnouncementService
{
    private readonly IAnnouncementDal _announcementDal;

    public AnnouncementManager(IAnnouncementDal announcementDal)
    {
        _announcementDal = announcementDal;
    }

    public void TAdd(Announcement entity)
    {
        _announcementDal.Insert(entity);
    }

    public void TDelete(Announcement entity)
    {
        _announcementDal.Delete(entity);
    }

    public List<Announcement> TGetAll()
    {
        return _announcementDal.GetAll();   
    }

    public Announcement TGetByID(int id)
    {
        return _announcementDal.GetByID(id);
    }

    public void TUpdate(Announcement entity)
    {
        _announcementDal.Update(entity);
    }
}
