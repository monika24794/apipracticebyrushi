using DemoShopApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoShopApiProject.Data
{
    public class ShopDBContext :DbContext
    {
        //base  is used to call the parent class
        public ShopDBContext(DbContextOptions options):base(options) 
        {

        }
        // table create using dataset
        public DbSet<User>Users { get; set; }
        

    }
}
