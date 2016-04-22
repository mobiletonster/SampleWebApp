using SampleWebApp.Models;
using SampleWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebApp.Controllers
{
    public class ValuesController : ApiController
    {
        public string GetStuff()
        {
            var user = ControllerContext.RequestContext.Principal as Lds.Stack.Security.LdsAccountUser;
            var headers = Request.Headers;
            
            string message = $"test. Logged in as: {user.PreferredName} ";
            return message;
        } 

        [Route("api/email/sendtojef")]
        [HttpGet]
        public IHttpActionResult SendEmailToJef()
        {
            var emailService = new EmailService();
            var message = emailService.CreateMailMessage("tony@ldschurch.org", "jljones@ldschurch.org", "Hello From the Other Side", "This is a cool test.");
            emailService.SendMailMessage(message);
            return Ok();
        }

        [Route("api/persons")]
        [HttpGet]
        public IHttpActionResult GetPersons(int page=0, int pageSize =0)
        {
            var dataService = new DataService();

            if(page > 0 && pageSize >0)
            {
                var pagedList = new PagedList();
                pagedList.Page = page;
                pagedList.PageSize = pageSize;
                pagedList.TotalRecords = dataService.GetPersons().Count;

                var persons = dataService.GetPersons().Skip((page-1) * pageSize).Take(pageSize).ToList();
                pagedList.Result = persons;
                return Ok(persons);
            }else
            {
                var persons = dataService.GetPersons();
                return Ok(persons);
            }
        }
    }
}
