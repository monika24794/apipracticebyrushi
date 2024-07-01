using DemoShopApiProject.Data;
using DemoShopApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoShopApiProject.Controllers
{
    //Path/Address of contriller
    [Route("api/[controller]")]
    //restApi
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ShopDBContext _dbContext;

        //dependancy injection becouse controller depends on dbcontext
        public UsersController(ShopDBContext ShopdbContext)
        {
            this._dbContext = ShopdbContext;
        }

        [HttpPost]
        [Route("/add")]

        public async Task<IActionResult> CreateUser(User user)
        {
            //save in application
            await _dbContext.Users.AddAsync(user);
            //save in database
            await _dbContext.SaveChangesAsync();
            //responce
            return Ok(user);
        }
        [HttpGet]
        [Route("/users")]
        public async Task<IActionResult> GetUsers()
        {
            List<User> userlist = await _dbContext.Users.ToListAsync();
            return Ok(userlist);
        }
        [HttpGet]
        [Route("/user/{id}")]
        public async Task<IActionResult> GetUserbyID(int id)
        {
            User newuser = await _dbContext.Users.FindAsync(id);
            if (newuser != null)
            {
                return NotFound();
            }
            return Ok(newuser);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, User user)
        {
            User founduser = await _dbContext.Users.FindAsync(id);
            if (founduser != null)
            {
                founduser.Name = user.Name;
                founduser.Email = user.Email;
                founduser.City = user.City;

                _dbContext.Users.Update(founduser);
                _dbContext.SaveChanges();
                return Ok(founduser);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet]
        [Route("/delete/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            User founduser = await _dbContext.Users.FindAsync(id);
            if (founduser != null)
            {
                _dbContext.Remove(founduser);
                _dbContext.SaveChanges();
                return Ok(id +" is deletead");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
