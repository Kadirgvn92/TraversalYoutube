using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalYoutube.BusinessLayer.Abstract.AbstractUow;
public interface IGenericUoWService<T>
{
    void TInsert(T t);
    void TUpdate(T t);
    void TMultiUpdate(List<T> t);
    T TGetByID(int id);
}
