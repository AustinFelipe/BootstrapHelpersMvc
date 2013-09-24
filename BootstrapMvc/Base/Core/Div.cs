using BootstrapMvc.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BootstrapMvc.Base.Core
{
    public class Div : Element<Div>, IElement, IHtmlString
    {
        private GridResponsive size { get; set; }
        private bool rowFluid { get; set; }
        private string divContainer;
        private object htmlAttributes;
        private string id;
        private string css;

        public Div()
        {
            size = GridResponsive.GridResponsiveWithoutCol();
        }

        public Div Id(string id)
        {
            this.id = id;
            return this;
        }

        public Div Size(GridResponsive size)
        {
            this.size = size;
            return this;
        }

        public Div AddElement(IElement element)
        {
            divContainer += element.Render();
            return this;
        }

        public Div IsRowFluid(bool rowFluid)
        {
            this.rowFluid = rowFluid;
            return this;
        }

        public override Div Attributes(object htmlAttributes)
        {
            this.htmlAttributes = htmlAttributes;
            return this;
        }

        public override Div AddCss(string css)
        {
            this.css = css;
            return this;
        }

        public override string Render()
        {
            var wrapper = new TagBuilder("div");
            wrapper.AddCssClass(size.ToString());

            if (rowFluid)
                wrapper.AddCssClass("row");

            wrapper.InnerHtml = divContainer;

            if (!String.IsNullOrEmpty(id))
                wrapper.Attributes.Add("id", id);

            wrapper.MergeAttributes(htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);

            if (!String.IsNullOrEmpty(css))
                wrapper.AddCssClass(css);

            return wrapper.ToString();
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
