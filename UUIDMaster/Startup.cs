using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using UUIDMaster.Models;
using UUIDMaster.Models.Repository;
using UUIDMaster.Models.Repository.Invoice;

namespace UUIDMaster
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
            services.AddMvc();

            //add db context
            services.AddDbContext<UUIDContext>(options => options.UseMySQL(
                Configuration.GetConnectionString("DefaultConnection"), 
                x => x.MigrationsHistoryTable("__UUIDMigrationsHistory")));
            services.AddScoped<IUserUUIDRecordRepository, UserUUIDRecordManager>();
            services.AddScoped<IEventUUIDRecordRepository, EventUUIDRecordManager>();
            services.AddScoped<IActivityUUIDRecordRepository, ActivityUUIDRecordManager>();
            services.AddScoped<IReservationUUIDRecordRepository, ReservationUUIDRecordManager>();
            services.AddScoped<IInvoiceUUIDRecordRepository, InvoiceUUIDRecordRepository>();

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "UUIDMaster",
                    Description = "UUIDMaster for Integration Project",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Jan Moriaux", Email = "jan.moriaux@student.ehb.be", Url = "" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
