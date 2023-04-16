using Assignment_2.Repositories;
using Assignment_2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Assignment_2
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IActorService, ActorService>();
            services.AddSingleton<IActorRepository, ActorRepository>();

            services.AddSingleton<IProducerService, ProducerService>();
            services.AddSingleton<IProducerRepository, ProducerRepository>();

            services.AddSingleton<IMovieService, MovieService>();
            services.AddSingleton<IMovieRepository, MovieRepository>();

            services.AddSingleton<IGenreService, GenreService>();
            services.AddSingleton<IGenreRepository, GenreRepository>();

            services.AddSingleton<IReviewService, ReviewService>();
            services.AddSingleton<IReviewRepository, ReviewRepository>();

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}