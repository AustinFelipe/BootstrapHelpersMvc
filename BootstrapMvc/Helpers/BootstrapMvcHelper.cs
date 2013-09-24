using BootstrapMvc.Base.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BootstrapMvc.Helpers
{
    public static class BootstrapMvcHelper
    {
        public static Bootstrap Bootstrap (this HtmlHelper htmlHelper)
        {
            return new Bootstrap();
        }
    }
}
