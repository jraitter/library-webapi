using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using library_webapi.Repositories;
using library_webapi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace library_webapi
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
      // Connection to DB
      services.AddScoped<IDbConnection>(x => CreateDbConnection());

      //Registering Transients for Debendency Injection
      services.AddTransient<BookService>();
      services.AddTransient<BooksRepository>();
      services.AddTransient<MagazineService>();
      services.AddTransient<MagazinesRepository>();
      services.AddTransient<LibraryService>();
      services.AddTransient<LibrariesRepository>();
      services.AddTransient<AuthorService>();
      services.AddTransient<AuthorsRepository>();
      services.AddTransient<BookAuthorService>();
      services.AddTransient<BookAuthorsRepository>();
    }
    private IDbConnection CreateDbConnection()
    {
      var connectionString = Configuration["db:gearhost"];
      return new MySqlConnection(connectionString);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
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
