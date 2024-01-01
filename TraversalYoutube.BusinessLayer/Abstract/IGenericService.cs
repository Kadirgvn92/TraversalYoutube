﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalYoutube.BusinessLayer.Abstract;
public interface IGenericService<T>
{
    void TAdd(T entity);
    void TDelete(T entity);
    void TUpdate(T entity);
    List<T> TGetAll();   
    T TGetByID (int id);
}
