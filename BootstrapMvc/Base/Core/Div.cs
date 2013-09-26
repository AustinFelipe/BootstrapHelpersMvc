using BootstrapMvc.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BootstrapMvc.Base.Core
{
    public class Div : GenericElement<Div>
    {
        private GridResponsive size { get; set; }
        private bool rowFluid { get; set; }
        private string divContainer;

        public Div() 
            : base("div")
        {
            size = GridResponsive.GridResponsiveWithoutCol();
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

        public override string Render()
        {
            if (!String.IsNullOrEmpty(size.ToString()))
                Wrapper.AddCssClass(size.ToString());

            if (rowFluid)
                Wrapper.AddCssClass("row");

            if (!String.IsNullOrEmpty(divContainer))
                Wrapper.InnerHtml = divContainer;

            return base.Render();
        }
    }
}
