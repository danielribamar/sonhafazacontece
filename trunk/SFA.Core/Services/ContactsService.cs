using SFA.Core.Entities;
using SFA.Core.Models;
using System;

namespace Sfa.Core.DataAccess
{
    public static class ContactsService
    {
        public static void Add(EmailForm model)
        {
            using (var dbContext = new SFAEntities())
            {
                var contact = new sfa_Contact
                {
                    CreateDate = DateTime.Now,
                    Email = model.email,
                    Message = model.message,
                    Name = model.name
                };

                dbContext.sfa_Contact.Add(contact);
                dbContext.SaveChanges();
            }
        }
    }
}
