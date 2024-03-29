﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.DataAccessLayer.Abstract;
public interface IGuideDal : IGenericDal<Guide>
{
    void ChangeToTrueByGUide(int id);
    void ChangeToFalseByGuide(int id);
}
