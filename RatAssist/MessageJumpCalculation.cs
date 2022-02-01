using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatAssist
{
    internal class MessageJumpCalculation
    {
        public PictureBox Background { get; internal set; }
        public Label Foreground { get; internal set; }
        public FormMain Form { get; internal set; }

        internal void Hide()
        {
            Background.Visible = false;
            Foreground.Visible = false;
            Form.Update();
        }

        internal void Show()
        {
            Background.Visible = true;
            Foreground.Visible = true;
            Form.Update();
        }
    }
}
