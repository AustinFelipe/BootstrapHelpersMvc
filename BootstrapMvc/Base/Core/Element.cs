using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BootstrapMvc.Base.Core
{
    public class Element : IElement, IHtmlString
    {
        protected object htmlAttributes;
        protected string id;
        protected string css;
        protected string WrapperType { get; private set; }
        protected TagBuilder Wrapper { get; private set; }

        public Element(string wrapperType)
        {
            WrapperType = wrapperType;
            Wrapper = new TagBuilder(wrapperType);
        }

        protected void ChangeWrapperType(string newWrapper)
        {
            WrapperType = newWrapper;
            Wrapper = new TagBuilder(newWrapper);
        }

        public void Clear()
        {
            this.id = String.Empty;
            this.css = String.Empty;
            this.htmlAttributes = null;

            Wrapper.Attributes.Clear();
        }

        public virtual string Render()
        {
            if (!String.IsNullOrEmpty(id))
                Wrapper.Attributes.Add("id", id);

            if (!String.IsNullOrEmpty(css))
                Wrapper.AddCssClass(css);

            Wrapper.MergeAttributes(htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);

            return Wrapper.ToString();
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
