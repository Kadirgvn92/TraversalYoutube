using Microsoft.EntityFrameworkCore;
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
public class EfCommentDal : GenericRepository<Comment>, ICommentDal
{
    public List<Comment> GetAll()
    {
        using var context = new Context();
        return context.Comments.Include(x => x.Destination)
                                   .ToList();
    }

    public List<Comment> GetListCommentWithDestinationAndUser(int id)
    {
        using var context = new Context();
        return context.Comments.Where(x => x.DestinationID == id).Include(x => x.AppUser)
                                   .ToList();
    }
}
