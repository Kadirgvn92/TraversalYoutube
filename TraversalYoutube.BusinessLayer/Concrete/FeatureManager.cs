using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class FeatureManager : IFeatureService
{
    private readonly IFeatureDal _featureDal;

    public FeatureManager(IFeatureDal featureDal)
    {
        _featureDal = featureDal;
    }

    public void TAdd(Feature entity)
    {
        throw new NotImplementedException();
    }

    public void TDelete(Feature entity)
    {
        throw new NotImplementedException();
    }

    public List<Feature> TGetAll()
    {
       return _featureDal.GetAll();
    }

    public Feature TGetByID(int id)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(Feature entity)
    {
        throw new NotImplementedException();
    }
}
