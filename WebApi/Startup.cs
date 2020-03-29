using AutoMapper;
using Contracts.Contact;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Services.Contact;
using Services.Mapper;

namespace WebApi
{
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
            services.AddControllers();

            // Repository Config
            services.AddEntityFrameworkNpgsql().AddDbContext<ContactContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("PostgreConnection")));
            
            services.AddDbContext<ContactContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("PostgreConnection")));

            // Auto Mapper Configurations
            services.AddAutoMapper(typeof(Startup));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ContactProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // ContactService
            services.Add(new ServiceDescriptor(typeof(IContactService), new ContactService(mapper, new ContactContext())));            
        }        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // TODO: See this
                //using var context = new ContactContext();
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
