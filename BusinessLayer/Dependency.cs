using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class Dependency
    {
        public static void AddApplication(this IServiceCollection Services)
        {
            Services.AddScoped<IAnnouncementService, AnnouncementManager>();
            Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

            Services.AddScoped<IAboutService, AboutManager>();
            Services.AddScoped<IAboutDal, EfAboutDal>();

            Services.AddScoped<IMessageService, MessageManager>();
            Services.AddScoped<IMessageDal, EfMessageDal>();

            Services.AddScoped<IExperienceService, ExperienceManager>();
            Services.AddScoped<IExperienceDal, EfExperienceDal>();

            Services.AddScoped<IFeatureService, FeatureManager>();
            Services.AddScoped<IFeatureDal, EfFeatureDal>();

            Services.AddScoped<IPortfolioService, PortfolioManager>();
            Services.AddScoped<IPortfolioDal, EfPortfolioDal>();

            Services.AddScoped<IServiceService, ServiceManager>();
            Services.AddScoped<IServiceDal, EfServiceDal>();

            Services.AddScoped<ISkillService, SkillManager>();
            Services.AddScoped<ISkillDal, EfSkillDal>();

            Services.AddScoped<IContactService, ContactManager>();
            Services.AddScoped<IContactDal, EfContactDal>();

            Services.AddScoped<IToDoListService, ToDoListManager>();
            Services.AddScoped<IToDoListDal, EfToDoListDal>();

            Services.AddScoped<ITestimonialService, TestimonialManager>();
            Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

            Services.AddScoped<IWriterMessageService, WriterMessageManager>();
            Services.AddScoped<IWriterMessageDal, EfWriterMessageDal>();

            Services.AddScoped<ISocialMediaService, SocialMediaManager>();
            Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

            Services.AddScoped<IWriterService, WriterManager>();
            Services.AddScoped<IWriterDal, EfWriterDal>();
        }
    }
}
