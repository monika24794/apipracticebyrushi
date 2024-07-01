using DemoShopApiProject.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoShopApiProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // key copy [ShopDB] from appssetting cnString key
            String ConString = builder.Configuration.GetConnectionString("ShopDB");
            // mysql accept 2 parameter string and version
            builder.Services.AddDbContext<ShopDBContext>
            (option => option.UseMySql(ConString ,ServerVersion.AutoDetect(ConString)));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
