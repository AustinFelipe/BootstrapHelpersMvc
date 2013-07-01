using System.Web;
using System.Web.Mvc;
using System;

namespace BootstrapMvc.Components
{
    public class ButtonGroup : IHtmlString
    {
        ButtonContainer buttonContainer;

        public ButtonGroup(Action<ButtonContainer> reference)
        {
            buttonContainer = new ButtonContainer();
            reference(buttonContainer);
        }

        private string RenderButtonGroup()
        {
            var wrapper = new TagBuilder("div");

            wrapper.AddCssClass("btn-group");

            foreach (var button in buttonContainer.Buttons)
            {
                wrapper.InnerHtml += button.ToString();
            }

            return wrapper.ToString();
        }

        public override string ToString()
        {
            return RenderButtonGroup();
        }

        public string ToHtmlString()
        {
            return ToString();
        }
    }
}
