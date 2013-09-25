using BootstrapMvc.Base.Core;
using System;
using System.Web;
using System.Web.Mvc;

namespace BootstrapMvc.Base.Button
{
    public class Button : Element<Button>
    {
        private readonly string text;
        private ButtonType buttonType;
        private ButtonSize buttonSize;
        private ButtonTag buttonTag;
        private bool disabled;
        private bool block;
        private bool submit;

        public Button(string text, ButtonType buttonType = ButtonType.Default, ButtonSize buttonSize = ButtonSize.Default,
            ButtonTag buttonTag = ButtonTag.Button, bool disabled = false, bool block = false, bool submit = true) 
            : base("button")
        {
            this.text = text;
            this.buttonType = buttonType;
            this.buttonSize = buttonSize;
            this.buttonTag = buttonTag;
            this.disabled = disabled;
            this.block = block;
            this.submit = submit;
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
            //var wrapper = new TagBuilder("button");

            // Tag
            switch (buttonTag)
            {
                case ButtonTag.Link: 
                    ChangeWrapperType("a");
                    break;
                case ButtonTag.Input:
                    ChangeWrapperType("input");
                    break;
            }

            Wrapper.AddCssClass("btn");

            // Type
            switch (buttonType)
            {
                case ButtonType.Default:
                    Wrapper.AddCssClass("btn-default");
                    break;
                case ButtonType.Primary:
                    Wrapper.AddCssClass("btn-primary");
                    break;
                case ButtonType.Info:
                    Wrapper.AddCssClass("btn-info");
                    break;
                case ButtonType.Success:
                    Wrapper.AddCssClass("btn-success");
                    break;
                case ButtonType.Warning:
                    Wrapper.AddCssClass("btn-warning");
                    break;
                case ButtonType.Danger:
                    Wrapper.AddCssClass("btn-danger");
                    break;
                case ButtonType.Link:
                    Wrapper.AddCssClass("btn-link");
                    break;
            }

            // Size
            switch (buttonSize)
            {
                case ButtonSize.Large:
                    Wrapper.AddCssClass("btn-lg");
                    break;
                case ButtonSize.Small:
                    Wrapper.AddCssClass("btn-sm");
                    break;
                case ButtonSize.ExtraSmall:
                    Wrapper.AddCssClass("btn-xs");
                    break;
            }

            if (block)
                Wrapper.AddCssClass("btn-block");

            if (disabled)
            {
                if (buttonTag == ButtonTag.Link)
                    Wrapper.AddCssClass("disabled");
                else
                    Wrapper.Attributes.Add("disabled", "disabled");
            }

            if (submit)
                Wrapper.Attributes.Add("type", "submit");
            else
                Wrapper.Attributes.Add("type", "button");

            if (buttonTag == ButtonTag.Input)
                Wrapper.Attributes.Add("value", text);
            else
                Wrapper.InnerHtml = text;

            return base.Render();
        }
    }
}
