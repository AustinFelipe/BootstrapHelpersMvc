using BootstrapMvc.Base.Button;
using BootstrapMvc.Components;
using System;
using System.Web.Mvc;

namespace BootstrapMvc.Helpers
{
    public static class ButtonHtmlHelper
    {
        public static Button Button(this HtmlHelper html, string text, ButtonType buttonType = ButtonType.Default, 
            ButtonSize buttonSize = ButtonSize.Default, ButtonTag buttonTag = ButtonTag.Button, bool disabled = false, 
            bool block = false, object htmlAttributes = null)
        {
            return new Button(text, buttonType, buttonSize, buttonTag, disabled, block, htmlAttributes);
        }

        public static ButtonGroup ButtonGroup(this HtmlHelper html, Action<ButtonContainer> reference)
        {
            return new ButtonGroup(reference);
        }

        public static ButtonToolbar ButtonToolbar(this HtmlHelper html, Action<ButtonToolbarContainer> reference)
        {
            return new ButtonToolbar(reference);
        }
    }
}
