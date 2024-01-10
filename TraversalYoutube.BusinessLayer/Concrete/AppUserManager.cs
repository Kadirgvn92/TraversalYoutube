using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class AppUserManager : IAppUserService
{
    private readonly IAppUserDal appUserDal;

    public AppUserManager(IAppUserDal appUserDal)
    {
        this.appUserDal = appUserDal;
    }

    public void TAdd(AppUser entity)
    {
       appUserDal.Insert(entity);
    }

    public void TDelete(AppUser entity)
    {
        appUserDal.Delete(entity);
    }

    public List<AppUser> TGetAll()
    {
       return appUserDal.GetAll();  
    }

    public AppUser TGetByID(int id)
    {
        return appUserDal.GetByID(id);
    }

    public void TUpdate(AppUser entity)
    {
        appUserDal.Update(entity);
    }
}
