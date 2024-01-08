using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Abstract;
public interface IReservationService : IGenericService<Reservation>
{
    List<Reservation> GetListApprovalReservation(int id);
}
