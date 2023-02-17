using Microsoft.Extensions.FileProviders;

namespace Abc.Northwind.Mvc.WebUI.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        //Client side Frameworklerinin eklendiği dosyanın yolunu programcs üzerinde belirmek için extensions method yazıldı.
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var provider=new PhysicalFileProvider(path);

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider=provider;

            app.UseStaticFiles(options);
            return app;
        }
    }
}
