using Sfa.Core.DataAccess;
using SFA.Core.Helpers;
using SFA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace SFA.Frontend.Controllers
{
    public class NewsletterController : UmbracoApiController
    {
        [HttpPost]
        public HttpResponseMessage Subscribe(Newsletter model)
        {
            try
            {
                NewsletterService.Subscribe(model);
               
                return Request.CreateResponse(HttpStatusCode.OK, "sent");
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message);
            }
        }
    }
}
