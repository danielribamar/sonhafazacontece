using UIOMatic.Attributes;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;
namespace SFA.Core.Models.UIOMatic
{
    [UIOMatic("newsletter", "Newsletters", "Newsletter", FolderIcon = "icon-users", ItemIcon = "icon-user")]
    [TableName("sfa_Newsletter")]
    public class Newsletter
    {
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [UIOMaticField(Name = "Email", Description = "")]
        public string Email { get; set; }

        [UIOMaticField(Name = "Name", Description = "")]
        public string Name { get; set; }


        public override string ToString()
        {
            return Email;
        }
    }
}
