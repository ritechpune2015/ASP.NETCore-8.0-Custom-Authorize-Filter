using Custom_Authorize_Filter.Models;
using Custom_Authorize_Filter.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<CompanyContext>(
     options=> options.UseSqlServer(builder.Configuration.GetConnectionString("scon"))
    );
builder.Services.AddScoped<IProduct, ProductRepo>();
builder.Services.AddScoped<IUser,UserRepo>();

var app = builder.Build();
app.MapControllerRoute(name:"area",pattern:"{area:exists}/{controller=UserHome}/{action=Index}");
//app.MapDefaultControllerRoute();
app.MapControllerRoute(name: "default", pattern: "{controller=ManageUsers}/{action=Login}");
app.Run();
