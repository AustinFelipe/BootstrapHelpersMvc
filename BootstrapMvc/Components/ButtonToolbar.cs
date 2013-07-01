using System;
using System.Web;
using System.Web.Mvc;

namespace BootstrapMvc.Components
{
    public class ButtonToolbar : IHtmlString
    {
        ButtonToolbarContainer buttonGroup;

        public ButtonToolbar(Action<ButtonToolbarContainer> reference)
        {
            buttonGroup = new ButtonToolbarContainer();
            reference(buttonGroup);
        }

        private string RenderButtonToolbar()
        {
            var wrapper = new TagBuilder("div");

            wrapper.AddCssClass("btn-toolbar");

            foreach (var group in buttonGroup.ButtonGroups)
            {
                wrapper.InnerHtml += group.ToString();
            }

            return wrapper.ToString();
        }

        public override string ToString()
        {
            return RenderButtonToolbar();
        }

        public string ToHtmlString()
        {
            return ToString();
        }
    }
}
