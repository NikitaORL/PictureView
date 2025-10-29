using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureView
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            this.Height = 750;
            this.Width = 1200;
            this.Text = "Pilt";

            // Time Label рамочка
            Label TimeLabel = new Label();
            TimeLabel.Location = new Point(965, 20);
            TimeLabel.Size = new Size(200, 30);
            TimeLabel.BorderStyle = BorderStyle.FixedSingle;
            TimeLabel.Font = new Font("Arial", 15.75f, FontStyle.Bold);
            this.Controls.Add(TimeLabel);

            // Time Label текст возле рамочки
            Label TimeLabelText = new Label();
            TimeLabelText.Location = new Point(840, 23);
            TimeLabelText.Size = new Size(200, 30);
            TimeLabelText.Font = new Font("Arial", 15.75f, FontStyle.Bold);
            TimeLabelText.Text = "Time Label";
            this.Controls.Add(TimeLabelText);


            //PlusLeftLabel - знак вопроса слева 1 ряд
            Label PlusLeftLabel1 = new Label();
            PlusLeftLabel1.Text = "?";
            PlusLeftLabel1.Size = new Size(60, 50);
            PlusLeftLabel1.TextAlign = ContentAlignment.MiddleCenter;
            PlusLeftLabel1.Location = new Point(50, 70);
            PlusLeftLabel1.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(PlusLeftLabel1);


            //PlusRightLabel - знак вопроса справа 1 ряд
            Label PlusRightLabel1 = new Label();
            PlusRightLabel1.Text = "?";
            PlusRightLabel1.Size = new Size(60, 50);
            PlusRightLabel1.TextAlign = ContentAlignment.MiddleCenter;
            PlusRightLabel1.Location = new Point(300, 70);
            PlusRightLabel1.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(PlusRightLabel1);


            //Плюс знак 1 ряд
            Label Plus = new Label();
            Plus.Text = "+";
            Plus.Size = new Size(60, 50);
            Plus.TextAlign = ContentAlignment.MiddleCenter;
            Plus.Location = new Point(175, 70);
            Plus.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(Plus);

            ////////////////////2 ряд/////////////////////
            //PlusLeftLabel - знак вопроса слева 2 ряд
            Label PlusLeftLabel2 = new Label();
            PlusLeftLabel2.Text = "?";
            PlusLeftLabel2.Size = new Size(60, 50);
            PlusLeftLabel2.TextAlign = ContentAlignment.MiddleCenter;
            PlusLeftLabel2.Location = new Point(50, 70);
            PlusLeftLabel2.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(PlusLeftLabel1);

            //PlusRightLabel - знак вопроса справа 1 ряд
            Label PlusRightLabel2 = new Label();
            PlusRightLabel2.Text = "?";
            PlusRightLabel2.Size = new Size(60, 50);
            PlusRightLabel2.TextAlign = ContentAlignment.MiddleCenter;
            PlusRightLabel2.Location = new Point(300, 70);
            PlusRightLabel2.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(PlusRightLabel2);


            //Плюс знак 1 ряд
            Label Plus = new Label();
            Plus.Text = "+";
            Plus.Size = new Size(60, 50);
            Plus.TextAlign = ContentAlignment.MiddleCenter;
            Plus.Location = new Point(175, 70);
            Plus.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(Plus);
        }
    }
}
