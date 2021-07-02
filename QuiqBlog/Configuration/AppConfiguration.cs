using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiqBlog.Configuration
{
    public static class AppConfiguration
    {
        public static void AddDefaultConfiguration( this IApplicationBuilder aplicationBuilder, IWebHostEnvironment webHostEnviromment)
        {
            if (webHostEnviromment.IsDevelopment())
            {
                aplicationBuilder.UseDeveloperExceptionPage();
                aplicationBuilder.UseDatabaseErrorPage();
            }
            else
            {
                aplicationBuilder.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                aplicationBuilder.UseHsts();
            }
            aplicationBuilder.UseHttpsRedirection();
            aplicationBuilder.UseStaticFiles();

            aplicationBuilder.UseRouting();

            aplicationBuilder.UseAuthentication();
            aplicationBuilder.UseAuthorization();

            aplicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
