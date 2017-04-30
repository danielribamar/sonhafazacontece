using SFA.Core.Entities;
using SFA.Core.Models;
using System;
using MailChimp;
using MailChimp.Lists;
using MailChimp.Helper;
using System.Configuration;
using log4net;

namespace Sfa.Core.DataAccess
{
    public static class NewsletterService
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(NewsletterService));
        public static void Subscribe(Newsletter model)
        {
            using (var dbContext = new SFAEntities())
            {
                var nl = new sfa_Newsletter
                {
                    CreateDate = DateTime.Now,
                    Email = model.Email,
                    Name = model.Name
                };

                dbContext.sfa_Newsletter.Add(nl);
                dbContext.SaveChanges();

                AddRecordToMailChimp(model);
            }
        }

        private static void AddRecordToMailChimp(Newsletter model)
        {
            var mcm = new MailChimpManager(ConfigurationManager.AppSettings["MailChimp.ApiKey"]);

            var email = new EmailParameter
            {
                Email = model.Email
            };

            try
            {
                var result = mcm.Subscribe(ConfigurationManager.AppSettings["MailChimp.List"], email);

            }
            catch (Exception exception)
            {
                Logger.Error(exception);
            }
        }
    }
}
