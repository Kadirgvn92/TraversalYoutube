using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class CommentManager : ICommentService
{
    private readonly ICommentDal _commentDal;

    public CommentManager(ICommentDal commentDal)
    {
        _commentDal = commentDal;
    }

    public void TAdd(Comment entity)
    {
        _commentDal.Insert(entity);
    }

    public void TDelete(Comment entity)
    {
        throw new NotImplementedException();
    }

    public List<Comment> TGetAll()
    {
        throw new NotImplementedException();
    }

    public Comment TGetByID(int id)
    {
        throw new NotImplementedException();
    }
    public List<Comment> TGetDestinationByID (int id)
    {
        return _commentDal.GetListByFilter(x => x.DestinationID == id);
    }

    public void TUpdate(Comment entity)
    {
        throw new NotImplementedException();
    }
}
