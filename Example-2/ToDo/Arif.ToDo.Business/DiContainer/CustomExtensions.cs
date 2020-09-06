using Arif.ToDo.Business.Concrete;
using Arif.ToDo.Business.CustomLogger;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Arif.ToDo.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Arif.ToDo.Business.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<ITaskDal, EfTaskRepository>();
            services.AddScoped<IUrgencyDal, EfUrgencyRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }
    }
}
