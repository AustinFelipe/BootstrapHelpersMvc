using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BootstrapMvc.Base
{
    public static class ButtonHtmlHelper
    {
        public static Button Button(this HtmlHelper html, string text, ButtonType buttonType = ButtonType.Default, 
            ButtonSize buttonSize = ButtonSize.Default, ButtonTag buttonTag = ButtonTag.Button, bool disabled = false, 
            bool block = false, object htmlAttributes = null)
        {
            return new Button(text, buttonType, buttonSize, buttonTag, disabled, block, htmlAttributes);
        }
    }
}
