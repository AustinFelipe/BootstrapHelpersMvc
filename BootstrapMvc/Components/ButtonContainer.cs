using BootstrapMvc.Base.Button;
using System.Collections.Generic;

namespace BootstrapMvc.Components
{
    public class ButtonContainer
    {
        public List<Button> Buttons { get; set; }

        public ButtonContainer()
        {
            Buttons = new List<Button>();
        }

        public Button Button(string text)
        {
            Button b = new Button(text);
            Buttons.Add(b);
            return b;
        }
    }
}
