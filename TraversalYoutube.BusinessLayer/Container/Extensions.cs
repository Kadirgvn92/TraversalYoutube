using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.BusinessLayer.Container;
public static class Extensions
{
    public static void ContainerDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICommentService, CommentManager>();
        services.AddScoped<ICommentDal, EfCommentDal>();

        services.AddScoped<IDestinationService, DestinationManager>();
        services.AddScoped<IDestinationDal, EfDestinationDal>();

        services.AddScoped<IAppUserService, AppUserManager>();
        services.AddScoped<IAppUserDal, EfAppUserDal>();

        services.AddScoped<IReservationService, ReservationManager>();
        services.AddScoped<IReservationDal,EfReservationDal>();

        services.AddScoped<IGuideService, GuideManager>();
        services.AddScoped<IGuideDal, EfGuideDal>();

        services.AddScoped<IExcelService, ExcelManager>();

        services.AddScoped<IPdfService, PdfManager>();

        services.AddScoped<IContactUsService, ContactUsManager>();
        services.AddScoped<IContactUsDal, EfContactUsDal>();

        services.AddScoped<IAnnouncementService, AnnouncementManager>();
        services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
    }
}
