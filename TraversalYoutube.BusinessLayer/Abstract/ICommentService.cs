using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Abstract;
public interface ICommentService : IGenericService<Comment>
{
    List<Comment> TGetDestinationByID(int id);
    List<Comment> TGetListCommentWithDestinationAndUser(int id);
    List<Comment> TGetListCommentWithUser(int id);
}
