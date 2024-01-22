using AutoMapper;
using TraversalYoutube.DataAccessLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Models;

public class ReportModel
{
    private readonly IMapper _mapper;

    public ReportModel(IMapper mapper)
    {
        _mapper = mapper;
    }


}
