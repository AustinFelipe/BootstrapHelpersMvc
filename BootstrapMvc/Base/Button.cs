using System.Web;
using System.Web.Mvc;

namespace BootstrapMvc.Base
{
    public class Button : IHtmlString
    {
        private readonly string text;
        private ButtonType buttonType;
        private ButtonSize buttonSize;
        private ButtonTag buttonTag;
        private bool disabled;
        private bool block;
        private object htmlAttributes;

        public Button(string text, ButtonType buttonType = ButtonType.Default, ButtonSize buttonSize = ButtonSize.Default,
            ButtonTag buttonTag = ButtonTag.Button, bool disabled = false, bool block = false, object htmlAttributes = null)
        {
            this.text = text;
            this.buttonType = buttonType;
            this.buttonSize = buttonSize;
            this.buttonTag = buttonTag;
            this.disabled = disabled;
            this.block = block;
            this.htmlAttributes = htmlAttributes;
        }

        public Button Type(ButtonType buttonType)
        {
            this.buttonType = buttonType;
            return this;
        }

        public Button Size(ButtonSize buttonSize)
        {
            this.buttonSize = buttonSize;
            return this;
        }

        public Button Tag(ButtonTag buttonTag)
        {
            this.buttonTag = buttonTag;
            return this;
        }

        public Button Disabled(bool disabled)
        {
            this.disabled = disabled;
            return this;
        }

        public Button Block(bool block)
        {
            this.block = block;
            return this;
        }

        public Button Attributes(object htmlAttributes)
        {
            this.htmlAttributes = htmlAttributes;
            return this;
        }

        private string RenderButton()
        {
            TagBuilder wrapper = new TagBuilder("button");

            switch (buttonTag)
            {
                case ButtonTag.Anchor: 
                    wrapper = new TagBuilder("a");
                    break;
                case ButtonTag.Input:
                    wrapper = new TagBuilder("input");
                    break;
            }

            wrapper.MergeAttributes(htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);

            wrapper.AddCssClass("btn");

            wrapper.Attributes.Add("type", "button");
            //wrapper.InnerHtml = text;

            return wrapper.ToString();
        }

        public override string ToString()
        {
            return RenderButton();
        }

        public string ToHtmlString()
        {
            return ToString();
        }
    }
}
