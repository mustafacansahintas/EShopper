using EShopper.Business.Abstract;
using EShopper.Business.Concrete;
using EShopper.DataAccess.Abstract;
using EShopper.DataAccess.Concrete.EfCore;
using EShopper.WEBUI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Dependency Injection
//AddScoped: Gelen her bir web request için bir instance oluþturur ve gelen her ayný request te ayný instance'ý kullanýlýr,farklý web requestleri içinde yeniden instance alýr.
builder.Services.AddScoped<IProductDal, EfCoreProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();



//MVC Mimarisini Tanýmladým.
builder.Services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    SeedDatabase.Seed();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseStaticFiles();

app.CustomStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");

    endpoints.MapControllerRoute(
        name:"products",
        pattern:"products/{category?}",
        defaults: new {controller="Shop",action="List"}
        );

    endpoints.MapControllerRoute(
        name: "adminProducts",
        pattern: "admin/products",
        defaults: new { controller = "Admin", action = "ProductList" });

    endpoints.MapControllerRoute(
       name: "adminProducts",
       pattern: "admin/products/{id?}",
       defaults: new { controller = "Admin", action = "EditProduct" });


    endpoints.MapControllerRoute(
    name: "adminCategories",
    pattern: "admin/categories",
    defaults: new { controller = "Admin", action = "CategoryList" });

    endpoints.MapControllerRoute(
      name: "adminCategories",
      pattern: "admin/categories/{id?}",
      defaults: new { controller = "Admin", action = "EditCategory" });
});


app.Run();
