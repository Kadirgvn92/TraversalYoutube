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
        _commentDal.Delete(entity);
    }

    public List<Comment> TGetAll()
    {
        return _commentDal.GetAll();
    }

    public Comment TGetByID(int id)
    {
       return _commentDal.GetByID(id);
    }
    public List<Comment> TGetDestinationByID (int id)
    {
        return _commentDal.GetListByFilter(x => x.DestinationID == id);
    }

    public List<Comment> TGetListCommentWithDestinationAndUser(int id)
    {
        return _commentDal.GetListCommentWithDestinationAndUser(id);
    }

    public List<Comment> TGetListCommentWithUser(int id)
    {
        return _commentDal.GetListCommentWithUser(id);
    }

    public void TUpdate(Comment entity)
    {
       _commentDal.Update(entity);
    }
}
