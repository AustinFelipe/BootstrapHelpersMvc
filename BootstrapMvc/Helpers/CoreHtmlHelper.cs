using BootstrapMvc.Base.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapMvc.Helpers
{
    public static class CoreHtmlHelper
    {
        public static Div Div(this Bootstrap html)
        {
            return new Div();
        }
    }
}
