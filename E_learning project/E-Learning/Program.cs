using E_Learning.Models;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using E_Learning.Interface;
using E_Learning.Repository;
using E_Learning.ViewModels;
using Stripe;

namespace E_Learning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<E_LearningContext>();

            builder.Services.AddIdentity<App_user, IdentityRole>().AddEntityFrameworkStores<E_LearningContext>();  // identity authentication
            //builder.Services.AddScoped<IGenericRepository<Instructor>, GenericRepository<Instructor>>();
            builder.Services.AddScoped<IGenericRepository<Student>, GenericRepository<Student>>();
            builder.Services.AddScoped<IGenericRepository<Course>, GenericRepository<Course>>();
            builder.Services.AddScoped<IGenericRepository<CourseStudent>, GenericRepository<CourseStudent>>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ICourseStudentRepository, CourseStudentRepository>();
            builder.Services.AddScoped<ILessonRepository, LessonRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            //Stripe
            builder.Services.Configure<StripeViewModel>(builder.Configuration.GetSection("Stripe"));
            StripeConfiguration.SetApiKey(builder.Configuration.GetSection("Stripe")["Secretkey"]);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}