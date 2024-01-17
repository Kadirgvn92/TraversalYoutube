using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalYoutube.DataAccessLayer.Abstract;
public  interface IGenericUoWDal<T> where T : class
{
    void Insert(T item);    
    void Update(T item);
    void MultiUpdate(List<T> items);    
    T GetByID(int id);    

}

