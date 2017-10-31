using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    public enum Locator
    {
        None = 0,
        Name,
        LinkText,
        CssSelector,
        XPath,
        TagName
    }
    public class Llocator
    {
        public Llocator(Locator type, string targetText)
        {
            Type = type;
            TargetText = targetText;
        }
        public Locator Type { get; set; }
        public string TargetText { get; set; }
    }
}
