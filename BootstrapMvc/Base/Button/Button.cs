using BootstrapMvc.Base.Core;
using System;
using System.Web;
using System.Web.Mvc;

namespace BootstrapMvc.Base.Button
{
    public class Button : Element<Button>, IHtmlString, IElement
    {
        private readonly string text;
        private ButtonType buttonType;
        private ButtonSize buttonSize;
        private ButtonTag buttonTag;
        private bool disabled;
        private bool block;
        private bool submit;
        private string css;
        private object htmlAttributes;

        public Button(string text, ButtonType buttonType = ButtonType.Default, ButtonSize buttonSize = ButtonSize.Default,
            ButtonTag buttonTag = ButtonTag.Button, bool disabled = false, bool block = false, bool submit = true,
            object htmlAttributes = null)
        {
            this.text = text;
            this.buttonType = buttonType;
            this.buttonSize = buttonSize;
            this.buttonTag = buttonTag;
            this.disabled = disabled;
            this.block = block;
            this.submit = submit;
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

        public Button Submit(bool submit)
        {
            this.submit = submit;
            return this;
        }

        public override Button Attributes(object htmlAttributes)
        {
            this.htmlAttributes = htmlAttributes;
            return this;
        }

        public override string Render()
        {
            var wrapper = new TagBuilder("button");

            // Tag
            switch (buttonTag)
            {
                case ButtonTag.Link: 
                    wrapper = new TagBuilder("a");
                    break;
                case ButtonTag.Input:
                    wrapper = new TagBuilder("input");
                    break;
            }

            wrapper.AddCssClass("btn");

            // Type
            switch (buttonType)
            {
                case ButtonType.Default:
                    wrapper.AddCssClass("btn-default");
                    break;
                case ButtonType.Primary:
                    wrapper.AddCssClass("btn-primary");
                    break;
                case ButtonType.Info:
                    wrapper.AddCssClass("btn-info");
                    break;
                case ButtonType.Success:
                    wrapper.AddCssClass("btn-success");
                    break;
                case ButtonType.Warning:
                    wrapper.AddCssClass("btn-warning");
                    break;
                case ButtonType.Danger:
                    wrapper.AddCssClass("btn-danger");
                    break;
                case ButtonType.Link:
                    wrapper.AddCssClass("btn-link");
                    break;
            }

            // Size
            switch (buttonSize)
            {
                case ButtonSize.Large:
                    wrapper.AddCssClass("btn-lg");
                    break;
                case ButtonSize.Small:
                    wrapper.AddCssClass("btn-sm");
                    break;
                case ButtonSize.ExtraSmall:
                    wrapper.AddCssClass("btn-xs");
                    break;
            }

            if (block)
                wrapper.AddCssClass("btn-block");

            if (disabled)
            {
                if (buttonTag == ButtonTag.Link)
                    wrapper.AddCssClass("disabled");
                else
                    wrapper.Attributes.Add("disabled", "disabled");
            }

            if (submit)
                wrapper.Attributes.Add("type", "submit");
            else
                wrapper.Attributes.Add("type", "button");

            if (buttonTag == ButtonTag.Input)
                wrapper.Attributes.Add("value", text);
            else
                wrapper.InnerHtml = text;

            wrapper.MergeAttributes(htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);

            if (!String.IsNullOrEmpty(css))
                wrapper.AddCssClass(css);

            return wrapper.ToString();
        }

        public override Button AddCss(string css)
        {
            this.css = css;
            return this;
        }

        public override string ToString()
        {
            return Render();
        }

        public string ToHtmlString()
        {
            return ToString();
        }
    }
}
