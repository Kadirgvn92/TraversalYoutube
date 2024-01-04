using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalYoutube.DataAccessLayer.Abstract;
public interface IGenericDal<T> where T : class
{
    void Insert(T t);
    void Update(T t);   
    void Delete(T t);
    T GetByID (int id);
    List<T> GetAll();   
}
