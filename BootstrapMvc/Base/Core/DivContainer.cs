using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapMvc.Base.Core
{
    public class DivContainer
    {
        public List<Div> Divs { get; set; }

        public DivContainer()
        {
            Divs = new List<Div>();
        }

        public Div Div()
        {
            Div d = new Div();
            Divs.Add(d);
            return d;
        }
    }
}
