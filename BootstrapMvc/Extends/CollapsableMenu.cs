using BootstrapMvc.Base.Core;
using BootstrapMvc.Base.Utils;
using BootstrapMvc.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BootstrapMvc.Extends
{
    public class CollapsableMenu : Div
    {
        public override string Render()
        {
            var g = GridResponsive.GridResponsiveWithoutCol();
            g.Add(new GridCol() { GridType = GridOptions.LargeDevices, Size = 3 });

            Well d = new Well(WellOption.Small);

            base.Size(g).AddElement(d);

            return base.Render();
        }
    }
}
