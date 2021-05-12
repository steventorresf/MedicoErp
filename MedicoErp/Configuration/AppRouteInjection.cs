using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Configuration
{
    public static class AppRouteInjection
    {
        public static IApplicationBuilder UseMvcInjection(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: "areas",
                    areaName: "areas",
                    template: "{area:exists}/{controller=Login}/{action=Index}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });

            return app;
        }
    }
}
