
using project_tracker_application.Implementations.ProjectService;
using project_tracker_application.Interfaces;
using project_tracker_application.Interfaces.Service_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace project_tracker_application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IProjectService, ProjectService>();

            return services;
        }
    }
}
