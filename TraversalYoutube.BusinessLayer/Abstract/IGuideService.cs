using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Abstract;
public interface IGuideService : IGenericService<Guide>
{
    void TChangeToTrueByGUide(int id);
    void TChangeToFalseByGuide(int id);
}
