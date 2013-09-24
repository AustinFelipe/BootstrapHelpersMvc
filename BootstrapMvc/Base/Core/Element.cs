using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapMvc.Base.Core
{
    public abstract class Element<T> where T : class, IElement
    {
        public abstract string Render();
        public abstract T Attributes(object htmlAttributes);
        public abstract T AddCss(string css);
    }
}
