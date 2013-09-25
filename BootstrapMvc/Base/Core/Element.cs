using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BootstrapMvc.Base.Core
{
    public class Element<T> : IElement, IHtmlString
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

        public virtual string Render()
        {
            if (!String.IsNullOrEmpty(id))
                Wrapper.Attributes.Add("id", id);

            if (!String.IsNullOrEmpty(css))
                Wrapper.AddCssClass(css);

            Wrapper.MergeAttributes(htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);

            return Wrapper.ToString();
        }

        public T Id(string id)
        {
            this.id = id;
            return default(T);
        }

        public virtual T Attributes(object htmlAttributes)
        {
            this.htmlAttributes = htmlAttributes;
            return default(T);
        }

        public virtual T AddCss(string css)
        {
            this.css = css;
            return default(T);
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
