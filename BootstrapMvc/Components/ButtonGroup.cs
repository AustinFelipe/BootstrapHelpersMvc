using System.Web;
using System.Web.Mvc;
using System;

namespace BootstrapMvc.Components
{
    public class ButtonGroup : IHtmlString
    {
        private ButtonContainer buttonContainer;
        private bool vertical;

        public ButtonGroup(Action<ButtonContainer> reference)
        {
            vertical = false;
            buttonContainer = new ButtonContainer();
            reference(buttonContainer);
        }

        public ButtonGroup Vertical(bool vertical = false)
        {
            this.vertical = vertical;
            return this;
        }

        private string RenderButtonGroup()
        {
            var wrapper = new TagBuilder("div");

            wrapper.AddCssClass("btn-group");

            if (vertical)
                wrapper.AddCssClass("btn-group-vertical");

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
