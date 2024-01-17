using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract.AbstractUow;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.UnitOfWork;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete.ConcereteUoW;
public class AccountManager : IAccountService
{
    private readonly IAccountDal _accounDal;
    private readonly IUoWDal _uowDal;

    public AccountManager(IAccountDal accounDal, IUoWDal uowDal)
    {
        _accounDal = accounDal;
        _uowDal = uowDal;
    }

    public Account TGetByID(int id)
    {
       return    _accounDal.GetByID(id);
    }

    public void TInsert(Account t)
    {
        _accounDal.Insert(t);
        _uowDal.Save();
    }

    public void TMultiUpdate(List<Account> t)
    {
        _accounDal.MultiUpdate(t);
        _uowDal.Save();
    }

    public void TUpdate(Account t)
    {
        _accounDal.Update(t);
        _uowDal.Save();
    }
}
