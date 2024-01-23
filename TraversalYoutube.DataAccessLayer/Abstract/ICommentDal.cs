using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.DataAccessLayer.Abstract;
public interface ICommentDal : IGenericDal<Comment>
{
    public List<Comment> GetListCommentWithDestinationAndUser(int id);
    public List<Comment> GetListCommentWithUser(int id);
}
