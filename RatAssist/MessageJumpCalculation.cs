using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatAssist
{
    internal class MessageJumpCalculation
    {
        public Panel Background { get; internal set; }
        public Label Foreground { get; internal set; }
        public FormMain Form { get; internal set; }

        internal void Hide() => Hide(true);
        internal void Hide(bool update)
        {
            Background.Visible = false;
            Foreground.Visible = false;
            Form.Update();
        }

        internal void Show()
        {
            Hide(false);
            Background.Visible = true;
            Background.BackColor = Color.Gray;
            Foreground.Visible = true;
            Foreground.BackColor = Background.BackColor;
            Foreground.ForeColor = Color.Black;
            Foreground.Text = "Updating route...";
            Form.Update();
        }

        internal void Error()
        {
            Hide(false);
            Background.Visible = true;
            Background.BackColor = Color.DarkRed;
            Foreground.Visible = true;
            Foreground.BackColor = Background.BackColor;
            Foreground.ForeColor = Color.White;
            Foreground.Text = "Unable to update route";
            Form.Update();
        }
    }
}
