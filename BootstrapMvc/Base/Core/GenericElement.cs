using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapMvc.Base.Core
{
    public class GenericElement<T> : Element
    {
        public GenericElement(string wrapperType)
            : base(wrapperType)
        {
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
    }
}
