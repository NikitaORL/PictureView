using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PictureView
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn1, btn2, btn3, btn4, btn5;
        PictureBox pic;
        CheckBox chkFull;
        Panel line;

        public Form1()
        {
            this.Height = 750;
            this.Width = 1200;
            this.Text = "Vorm elementidega";

            tree = new TreeView();
            tree.Dock = DockStyle.Left;

            // главный узел
            TreeNode tn = new TreeNode("Palun sisesta");
            tn.Nodes.Add(new TreeNode("PictureView"));
            tn.Nodes.Add(new TreeNode("Math Quiz"));
            tn.Nodes.Add(new TreeNode("Matching Game"));
            tree.Nodes.Add(tn);
            tree.ExpandAll();
            this.Controls.Add(tree);

            tree.AfterSelect += Tree_AfterSelect;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Линия
            line = new Panel();
            line.BackColor = Color.Gray;
            line.Size = new Size(1200, 3);     
            line.Location = new Point(120, 560);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Кнопки
            btn1 = new Button();
            btn1.Text = "Show Picture";
            btn1.Location = new Point(250, 600);
            btn1.Size = new Size(120, 30); 
            btn1.Click += Btn_Click_Show;
            btn1.BackColor = Color.LightGray;

            btn2 = new Button();
            btn2.Text = "Set the background color";
            btn2.Location = new Point(400, 600);
            btn2.Size = new Size(180, 30);
            btn2.Click += Btn_Click_SetBackground;
            btn2.BackColor = Color.LightGray;

            btn3 = new Button();
            btn3.Text = "Clear the Picture";
            btn3.Location = new Point(600, 600);
            btn3.Size = new Size(150, 30);
            btn3.Click += Btn_Click_Clear;
            btn3.BackColor = Color.LightGray;

            btn4 = new Button();
            btn4.Text = "Close";
            btn4.Location = new Point(770, 600);
            btn4.Size = new Size(100, 30);
            btn4.Click += Btn_Click_Close;
            btn4.BackColor = Color.LightGray;

            btn5 = new Button();
            btn5.Text = "Close";
            btn5.Location = new Point(770, 600);
            btn5.Size = new Size(100, 30);
            btn5.Click += Btn_Click_Filter;
            btn5.BackColor = Color.LightGray;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Галочка
            chkFull = new CheckBox();
            chkFull.Text = "Strech";
            chkFull.Location = new Point(130, 600);
            chkFull.CheckedChanged += ChkFull_CheckedChanged;
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Картинка
            pic = new PictureBox();
            pic.Size = new Size(800, 500);
            pic.Location = new Point(120, 0);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            try { pic.Image = Image.FromFile(@"..\\..\\ImagesView\\ForView.jpg"); } catch { }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            
            this.Resize += Form1_Resize;
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            foreach (Control c in this.Controls.OfType<Control>().ToList())
            {
                if (c != tree) this.Controls.Remove(c);
            }

            if (e.Node.Text == "PictureView")
            {
                
                this.Controls.Add(line);
                this.Controls.Add(chkFull);
                this.Controls.Add(btn1);
                this.Controls.Add(btn2);
                this.Controls.Add(btn3);
                this.Controls.Add(btn4);
            }

            this.Controls.Add(tree);
        }

        private void ChkFull_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePictureSize();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
           
            UpdatePictureSize();

            
            line.Width = this.ClientSize.Width - 250;
        }
        // 
        private void UpdatePictureSize()
        {
            if (chkFull.Checked)
            {
                pic.Size = new Size(1200, 560);
                pic.Location = new Point(120, 0);
            }
            else
            {
                
                pic.Size = new Size(800, 500);
                pic.Location = new Point(120, 0);
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Функции для PictureView
        private void Btn_Click_Show(object sender, EventArgs e)
        {
            this.Controls.Add(pic);
        }

        private void Btn_Click_Clear(object sender, EventArgs e)
        {
            this.Controls.Remove(pic);
        }

        private void Btn_Click_Close(object sender, EventArgs e)
        {
            this.Close(); 
        }



        private void Btn_Click_SetBackground(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    this.BackColor = colorDialog.Color;                                          
                }
            }
        }

        private void Btn_Click_Filter(object sender, EventArgs e)
        {
            
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
