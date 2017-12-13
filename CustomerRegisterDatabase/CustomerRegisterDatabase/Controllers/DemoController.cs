using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using CustomerRegisterDatabase.Models;

namespace WebDeploy.Controllers
{
    [Route("")]
    public class DemoController : Controller
    {
        private readonly IHostingEnvironment env;
        private readonly MailConfiguration mail;

        public DemoController(IHostingEnvironment env, MailConfiguration mail)
        {
            this.env = env;
            this.mail = mail;
        }
        [HttpGet, Route("")]
        public IActionResult Demo()
        {
            return Ok(new object[] {
                env.IsDevelopment(),
                env.IsProduction(),
                AppContext.BaseDirectory,
                env.ContentRootPath,
                env.ApplicationName,
                env.EnvironmentName,
                env.WebRootPath,
                mail.BlindCopyAddresses,
                mail.LogEverySentMail,
                mail.MailServerHostName,
                mail.SendMail
            });
        }


    }
}
