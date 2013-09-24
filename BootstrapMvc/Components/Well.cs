using BootstrapMvc.Base.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BootstrapMvc.Components
{
    public enum WellOption
    {
        Small,
        Normal,
        Large
    }

    public class Well : Div
    {
        public Well(WellOption option)
        {
            base.AddCss(String.Format("well{0}", option == WellOption.Small ? " well-sm" : option == WellOption.Large ? " well-lg" : ""));
        }
    }
}
