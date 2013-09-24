using BootstrapMvc.Base.Button;
using BootstrapMvc.Base.Core;
using BootstrapMvc.Components;
using System;
using System.Web.Mvc;

namespace BootstrapMvc.Helpers
{
    public static class ButtonHtmlHelper
    {
        public static Button Button(this Bootstrap html, string text, ButtonType buttonType = ButtonType.Default, 
            ButtonSize buttonSize = ButtonSize.Default, ButtonTag buttonTag = ButtonTag.Button, bool disabled = false, 
            bool block = false, bool submit = true, object htmlAttributes = null)
        {
            return new Button(text, buttonType, buttonSize, buttonTag, disabled, block, submit, htmlAttributes);
        }

        public static ButtonGroup ButtonGroup(this Bootstrap html, Action<ButtonContainer> reference)
        {
            return new ButtonGroup(reference);
        }

        public static ButtonToolbar ButtonToolbar(this Bootstrap html, Action<ButtonToolbarContainer> reference)
        {
            return new ButtonToolbar(reference);
        }
    }
}
