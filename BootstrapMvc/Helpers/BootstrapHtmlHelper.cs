using BootstrapMvc.Base.Button;
using BootstrapMvc.Base.Core;
using BootstrapMvc.Components;
using BootstrapMvc.Extends;
using System;
using System.Web.Mvc;

namespace BootstrapMvc.Helpers
{
    public static class BootstrapHtmlHelper
    {
        #region Constructor
        public static Bootstrap Bootstrap(this HtmlHelper htmlHelper)
        {
            return new Bootstrap();
        }
        #endregion

        #region Components
        public static ButtonGroup ButtonGroup(this Bootstrap html, Action<ButtonContainer> reference)
        {
            return new ButtonGroup(reference);
        }

        public static ButtonToolbar ButtonToolbar(this Bootstrap html, Action<ButtonToolbarContainer> reference)
        {
            return new ButtonToolbar(reference);
        }
        #endregion

        #region Base
        public static Button Button(this Bootstrap html, string text, ButtonType buttonType = ButtonType.Default,
            ButtonSize buttonSize = ButtonSize.Default, ButtonTag buttonTag = ButtonTag.Button, bool disabled = false,
            bool block = false, bool submit = true, object htmlAttributes = null)
        {
            return new Button(text, buttonType, buttonSize, buttonTag, disabled, block, submit);
        }

        public static Div Div(this Bootstrap html)
        {
            return new Div();
        }

        public static Well Well(this Bootstrap html, WellOption option = WellOption.Normal)
        {
            return new Well(option);
        }
        #endregion

        #region Extends
        public static CollapsableMenu CollapsableMenu(this Bootstrap html)
        {
            return new CollapsableMenu();
        }
        #endregion
    }
}
