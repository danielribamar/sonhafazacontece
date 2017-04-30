using Newtonsoft.Json;
using SFA.Core.Models;
using System;
using System.Collections.Generic;
using umbraco.MacroEngines;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace SFA.Core.Helpers
{
    public class GenericHelper
    {
        public static string GetMonthShortName(int monthIndex)
        {
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            return mfi.GetMonthName(8).ToString();
        }

        public static Hyperlink GetHyperlink(IPublishedContent model)
        {
            try
            {
                var result = new Hyperlink();
                if (string.IsNullOrEmpty(model.GetPropertyValue<string>("redirect")))
                {
                    return result;
                }
                foreach (var item in (IEnumerable<dynamic>)JsonConvert.DeserializeObject(model.GetPropertyValue<string>("redirect")))
                {
                    result.Url = (bool)item.isInternal ? new DynamicNode(item["internal"]).Url : item.link;
                    result.Target = (bool)item.newWindow ? "_blank" : null;
                    result.Caption = item.caption;
                }
                return result;
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        public static Hyperlink GetHyperlink(DynamicNode model)
        {
            var result = new Hyperlink();
            if (string.IsNullOrEmpty(model.GetPropertyValue("redirect")))
            {
                return result;
            }
            foreach (var item in (IEnumerable<dynamic>)JsonConvert.DeserializeObject(model.GetPropertyValue("redirect")))
            {
                result.Url = (bool)item.isInternal ? new DynamicNode(item["internal"]).Url : item.link;
                result.Target = (bool)item.newWindow ? "_blank" : null;
                result.Caption = item.caption;
            }
            return result;
        }

        public static List<Hyperlink> GetHyperlinkList(IPublishedContent model)
        {
            var result = new List<Hyperlink>();


            foreach (var item in (IEnumerable<dynamic>)JsonConvert.DeserializeObject(model.GetPropertyValue<string>("redirect")))
            {
                result.Add(new Hyperlink
                {
                    Url = (bool)item.isInternal ? new DynamicNode(item["internal"]).Url : item.link,
                    Target = (bool)item.newWindow ? "_blank" : null,
                    Caption = item.caption
                });
            }
            return result;
        }
    }
}
