using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RatAssist
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            pictureBox1.Image = Properties.Resources.Rat_Spansh_Tool;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
