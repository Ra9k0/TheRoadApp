namespace TheRoadApp
{
    using System.Collections.Generic;
    
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using TheRoadApp.Data;
    using TheRoadApp.Data.Models;
    using TheRoadApp.Data.Models.Enums;
    using TheRoadApp.Services;
    using TheRoadApp.Services.Interfaces;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false; 
                        options.Password.RequireDigit = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredLength = 6;
                    }

                )
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ITourService, TourService>();
            services.AddTransient<IContactService, ContactService>();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                //// Seed Tours
                //dbContext.Tours.AddRangeAsync(new List<Tour>()
                //{
                //    new Tour()
                //    {
                //        Name = "THE WILD FOREST",
                //        DurationInDays = 7,
                //        Capacity = 20,
                //        TourGuidesCount = 4,
                //        SleepConditions = "Sleep in private tents",
                //        Terrain = Difficulty.Medium,
                //        Price = 399M,
                //        ImgUrl = "https://i.ibb.co/JkTfQ4Y/forest.jpg",
                //    },
                //    new Tour()
                //    {
                //        Name = "ALONG THE RIVER",
                //        DurationInDays = 9,
                //        Capacity = 30,
                //        TourGuidesCount = 7,
                //        SleepConditions = "Sleep in private tents",
                //        Terrain = Difficulty.Hard,
                //        Price = 499M,
                //        ImgUrl = "https://i.ibb.co/0rBwTyr/river.jpg",
                //    },
                //    new Tour()
                //    {
                //        Name = "THE ISLAND BEACH",
                //        DurationInDays = 5,
                //        Capacity = 40,
                //        TourGuidesCount = 8,
                //        SleepConditions = "Sleep in hotel",
                //        Terrain = Difficulty.Easy,
                //        Price = 599M,
                //        ImgUrl = "https://i.ibb.co/cFfRvPT/sea.jpg",
                //    },
                //}).GetAwaiter().GetResult();

                //// Seed Comments
                //dbContext.Comments.AddRangeAsync(new List<Comment>()
                //{
                //    new Comment()
                //    {
                //        Title = "THESE WERE THE BEST DAYS OF THIS YEAR",
                //        Content = "From cutting down on stress, to lowering your chances of developing a heart disease, the health benefits of traveling are huge. You may stay sitting on a chair all day long at the workplace: including some walking to your trip is sure to make your body feel better.",
                //        AuthorFullName = "Mirela Stamboliyska",
                //        Email = "Mirela@gmail.com",
                //    },
                //    new Comment()
                //    {
                //        Title = "I ENJOYED THIS GREAT TOUR",
                //        Content = "You might feel like you are stuck in a rut in your daily life. Or you are yearning for something exciting and different. You are craving new experiences and new challenges. Travel is the ideal place to test yourself. Overcoming challenges will bring you joy and energy for future tests. You will realize how capable you are and build your confidence.",
                //        AuthorFullName = "Ivan Ivanov",
                //        Email = "Ivan@gmail.com",
                //    }
                //}).GetAwaiter().GetResult();

                dbContext.SaveChangesAsync().GetAwaiter().GetResult();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "areaRoute",
                    "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
