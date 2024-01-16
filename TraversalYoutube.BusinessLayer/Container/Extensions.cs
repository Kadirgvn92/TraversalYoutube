using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.BusinessLayer.ValidationRules;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.EntityFramework;
using TraversalYoutube.EntityLayer.Concrete;

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
        services.AddScoped<IReservationDal, EfReservationDal>();

        services.AddScoped<IGuideService, GuideManager>();
        services.AddScoped<IGuideDal, EfGuideDal>();

        services.AddScoped<IExcelService, ExcelManager>();

        services.AddScoped<IPdfService, PdfManager>();

        services.AddScoped<IContactUsService, ContactUsManager>();
        services.AddScoped<IContactUsDal, EfContactUsDal>();

        services.AddScoped<IAnnouncementService, AnnouncementManager>();
        services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

    }

    public static void RegisterValidator(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(config =>
        {
            config.DisableDataAnnotationsValidation = true;
        });

        services.AddValidatorsFromAssemblyContaining<AnnouncementValidator>();

        
    }
}
