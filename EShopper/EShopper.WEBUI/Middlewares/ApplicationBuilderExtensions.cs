using Microsoft.Extensions.FileProviders;

namespace EShopper.WEBUI.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        //Middleware: Bootstrap gibi kütüphaneleri node js sayesinde npm yapısıyla projeye dahile edeceğiz. Static olan bu dosyaların dışarıya açılma işlemidir.

        public static IApplicationBuilder CustomStaticFiles(this IApplicationBuilder app)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "node_modules");
            var options = new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(path),
                RequestPath = "/modules"
            };

            app.UseStaticFiles(options);
            return app;
        }
    }
}
