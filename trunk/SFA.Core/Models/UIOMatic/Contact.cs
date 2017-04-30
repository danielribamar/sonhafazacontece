using UIOMatic.Attributes;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;
namespace SFA.Core.Models.UIOMatic
{
    [UIOMatic("contact", "Contacts", "Contact", FolderIcon = "icon-users", ItemIcon = "icon-user")]
    [TableName("sfa_Contact")]
    public class Contact
    {
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [UIOMaticField(Name = "Email", Description = "Email")]
        public string Email { get; set; }

        [UIOMaticField(Name = "Name", Description = "Name")]
        public string Name { get; set; }

        [UIOMaticField(Name = "Message", Description = "Message")]
        public string Message { get; set; }


        [UIOMaticField(Name = "CreateDate", Description = "CreateDate")]
        public string CreateDate { get; set; }

        public override string ToString()
        {
            return Email;
        }
    }
}
