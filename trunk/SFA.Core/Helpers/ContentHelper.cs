using System.Collections.Generic;
using System.Linq;
using umbraco.MacroEngines;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace SFA.Core.Helpers
{
    public class ContentHelper
    {
        public static IEnumerable<DynamicNode> GetMainSliderItems(IPublishedContent model)
        {
            var dynamicNode = new DynamicNode(model.Id);
            var items = dynamicNode.ChildrenAsList.Where(p => p.NodeTypeAlias.Equals("genericItem")).ToList();

            return items;
        }

        public static IEnumerable<DynamicNode> GetVerticalContentItems(IPublishedContent model)
        {
            var dynamicNode = new DynamicNode(model.Id);
            var items =
                dynamicNode.ChildrenAsList.Where(
                    p =>
                        p.NodeTypeAlias.Equals("Text") || p.NodeTypeAlias.Equals("Video") ||
                        p.NodeTypeAlias.Equals("ImageSlider")).ToList();
            return items;
        }

        public static IEnumerable<string> GetImagesUrlFromSlider(DynamicNode model, string propertyAlias)
        {
            var umbraco = new UmbracoHelper(UmbracoContext.Current);

            var urls = new List<string>();

            var ids = model.GetPropertyValue(propertyAlias).Split(',');

            if (!ids.Any())
            {
                return new List<string>();
            }

            foreach (var id in ids)
            {
                var media = umbraco.Media(id);
                urls.Add(media.url);
            }

            return urls;

        }

        public static IEnumerable<string> GetTags(IPublishedContent model)
        {
            var listOfTags = new List<string>();

            var images = model.Children.Where(p => p.DocumentTypeAlias.Equals("genericItem") && p.HasValue("tags"));

            foreach (var image in images)
            {
                var tags = image.GetPropertyValue<string>("tags").Split(',');
                foreach (var tag in tags)
                {
                    if (!listOfTags.Contains(tag))
                    {
                        listOfTags.Add(tag);
                    }
                }
            }

            return listOfTags;
        }
    }
}
