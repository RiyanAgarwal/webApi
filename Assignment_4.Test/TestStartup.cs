using Assignment_4.Repositories;
using Assignment_4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Assignment_4.Test
{
    public class TestStartup
    {
        public IConfiguration Configuration { get; set; }
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<IActorService, ActorService>();
            services.AddSingleton<IProducerService, ProducerService>();
            services.AddSingleton<IMovieService, MovieService>();
            services.AddSingleton<IGenreService, GenreService>();
            services.AddSingleton<IReviewService, ReviewService>();
            //services.AddSingleton<IProducerRepository, ProducerRepository>();
            //services.AddSingleton<IActorRepository, ActorRepository>();
            //services.AddSingleton<IMovieRepository, MovieRepository>();
            //services.AddSingleton<IGenreRepository, GenreRepository>();
            //services.AddSingleton<IReviewRepository, ReviewRepository>();

            // TODO: Register Mock Implementations
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
