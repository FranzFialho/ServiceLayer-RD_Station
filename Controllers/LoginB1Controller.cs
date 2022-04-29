using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Data;
using ServiceLayer.Model;
using System;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginB1Controller : ControllerBase
    {

        // POST: api/LoginB1
        [HttpPost]
        public async Task<ActionResult<LoginB1>> PostLoginB1(LoginB1 loginB1)
        {
            InfoLogin infoLogin = new InfoLogin();
            try
            {
                var serviceLayer  = await SL.Connection.Request("Login").PostAsync<LoginB1>(loginB1);

                SL.Connection.AfterCall(async call =>

                {

                    infoLogin.Message = await call.HttpResponseMessage?.Content?.ReadAsStringAsync();

                });


                await SL.Connection.LoginAsync(true);

            }

            catch (Exception)
            {
                throw new Exception();
            }

            return Ok(infoLogin);

        }

        public class InfoLogin
        {
            public string Message { get; set; }
        }

    }
}
