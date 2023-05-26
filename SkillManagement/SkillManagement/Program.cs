using Microsoft.EntityFrameworkCore;
using SkillEntities.DataModels;
using SkillRepositories.Interfaces;
using SkillRepositories.Repositories;
using SkillServices;
using SkillServices.IServices;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using SkillEntities.DTOs;
using Newtonsoft.Json;
using DemoMvcCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<ManagementContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISkillService, SkillService>();

var app = builder.Build();

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .MinimumLevel.Debug()
    .WriteTo.File("log.txt", LogEventLevel.Error)
    .CreateLogger();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithReExecute("/Error/NotFound/{0}");
    
    app.UseHsts();
}
//app.UseExceptionHandler(
//             builder =>
//             {
//                 builder.Run(
//                 async context =>
//                 {
//                     context.Response.StatusCode =
//                  (int)HttpStatusCode.InternalServerError;
//                     context.Response.ContentType =
//                     "application/json";
//                     var exception =
//                     context.Features.Get
//                     <IExceptionHandlerFeature>();
//                     if (exception != null)
//                     {
//                         var error = new ErrorMessage()
//                         {
//                             Stacktrace =
//                             exception.Error.StackTrace,
//                             Message = exception.Error.Message
//                         };
//                         var errObj =
//                         JsonConvert.SerializeObject(error);
//                         await context.Response.WriteAsync
//                         (errObj).ConfigureAwait(false);
//                     }
//                 });
//             }
//        );
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseMiddleware<AuthorizationMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
