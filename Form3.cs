using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PictureView
{
    public partial class FormMatchingGame : Form
    {
        public FormMatchingGame()
        {
            this.Text = "Matching Game";
            this.Width = 800;
            this.Height = 600;

            Label label = new Label();
            label.Text = "Siin tuleb Matching Game!";
            label.Font = new Font("Arial", 20, FontStyle.Bold);
            label.AutoSize = true;
            label.Location = new Point(200, 250);
            this.Controls.Add(label);
        }
    }
}
