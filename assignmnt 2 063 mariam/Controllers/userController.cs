using assignmnt_2_063_mariam.Data;
using assignmnt_2_063_mariam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace assignmnt_2_063_mariam.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class userController : Controller
    {
        private readonly appDb db;
        public userController(appDb DB)
        {
            db = DB;
        }
        [HttpPost("signup")]
        public IActionResult signup(user us)
        {
            if(ModelState.IsValid)
            {
                try {
                    db.Add(us);
                    db.SaveChanges();
                    return new JsonResult(new { message = " data has been saved" });
                }
                catch (Exception e)
                {
                    return new JsonResult(new { message = e });

                }

            }
            return new JsonResult(new { message = " data not saved" });
        }
        [HttpGet("alluser")]
        public IActionResult getall()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<user> l1=db.users.ToList();
                    if (l1.Count>0)
                    {
                        return Ok(l1);

                    }
                    else
                    {
                        return new JsonResult(new {message = "no data"});
                    }
                }
                catch (Exception e)
                {
                    return new JsonResult(new { message = e });

                }

            }
            return new JsonResult(new { message = " data not saved" });
        }
        [HttpPost("login")]
        public IActionResult login(login us)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    user u1 = db.users.Where(uss => uss.email == us.email && uss.Password == us.password).ToList().FirstOrDefault();
                    if (u1 != null)
                    {
                        return new JsonResult(new { message = u1.email });
                    }
                    else
                    {
                        return new JsonResult(new { message = "user name and password not match" });
                    }
                }
                catch (Exception e)
                {
                    return new JsonResult(new { message = e });

                }

            }
            return new JsonResult(new { message = " data not saved" });
        }
        [HttpPut("password reset")]
        public IActionResult resetpassword(string email, string pass, string newpass)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    user u1 = db.users.Where(user => user.email==email && user.Password== pass).First();

                    if (u1 != null)
                    {
                        u1.Password = newpass;
                        db.SaveChanges();
                        return new JsonResult(new { message = "password successfully changes" });
                    }
                    else
                    {
                        return new JsonResult(new { message = "user name and password not match" });
                    }
                }
                catch (Exception e)
                {
                    return new JsonResult(new { message = e });

                }

            }
            return new JsonResult(new { message = " data not saved" });
        }
    }
}
