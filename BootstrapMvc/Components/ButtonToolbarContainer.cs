using System;
using System.Collections.Generic;

namespace BootstrapMvc.Components
{
    public class ButtonToolbarContainer
    {
        public List<ButtonGroup> ButtonGroups { get; set; }

        public ButtonToolbarContainer()
        {
            ButtonGroups = new List<ButtonGroup>();
        }

        public ButtonGroup ButtonGroup(Action<ButtonContainer> reference)
        {
            ButtonGroup bg = new ButtonGroup(reference);
            ButtonGroups.Add(bg);
            return bg;
        }
    }
}
