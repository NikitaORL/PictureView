using System;
using System.Drawing;
using System.Windows.Forms;

namespace PictureView
{
    public partial class Form2 : Form
    {
        // Create a Random object called randomizer 
        // to generate random numbers.
        Random randomizer = new Random();

        // These integer variables store the numbers 
        // for the addition problem. 
        int addend1;
        int addend2;

        // These integer variables store the numbers 
        // for the subtraction problem. 
        int minuend;
        int subtrahend;

        // These integer variables store the numbers 
        // for the multiplication problem. 
        int multiplicand;
        int multiplier;

        // These integer variables store the numbers 
        // for the division problem. 
        int dividend;
        int divisor;

        // This integer variable keeps track of the 
        // remaining time.
        int timeLeft;

        Label plusLeftLabel;
        Label plusRightLabel;
        NumericUpDown sum;

        Label PlusLeftLabel2;
        Label PlusRightLabel2;
        NumericUpDown answer2; 

        Label PlusLeftLabel3;
        Label PlusRightLabel3;
        NumericUpDown answer3; 

        Label PlusLeftLabel4;
        Label PlusRightLabel4;
        NumericUpDown answer4; 

        Label timeLabel;

        Button StartButton;

        Timer timer1;

        public Form2()
        {
            this.Height = 750;
            this.Width = 1200;
            this.Text = "Pilt";

            // Time Label рамочка
            timeLabel = new Label();
            timeLabel.Location = new Point(965, 20);
            timeLabel.Size = new Size(200, 30);
            timeLabel.BorderStyle = BorderStyle.FixedSingle;
            timeLabel.Font = new Font("Arial", 15.75f, FontStyle.Bold);
            this.Controls.Add(timeLabel);

            // Time Label текст возле рамочки
            Label TimeLabelText = new Label();
            TimeLabelText.Location = new Point(840, 23);
            TimeLabelText.Size = new Size(200, 30);
            TimeLabelText.Font = new Font("Arial", 15.75f, FontStyle.Bold);
            TimeLabelText.Text = "Time Label";
            this.Controls.Add(TimeLabelText);

            //////////////////////////////////////////////////////////////////////////////////////////
            // 1 ряд
            plusLeftLabel = new Label();
            plusLeftLabel.Text = "?";
            plusLeftLabel.Size = new Size(60, 50);
            plusLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
            plusLeftLabel.Location = new Point(50, 70);
            plusLeftLabel.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(plusLeftLabel);

            plusRightLabel = new Label();
            plusRightLabel.Text = "?";
            plusRightLabel.Size = new Size(60, 50);
            plusRightLabel.TextAlign = ContentAlignment.MiddleCenter;
            plusRightLabel.Location = new Point(300, 70);
            plusRightLabel.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(plusRightLabel);

            Label Plus = new Label();
            Plus.Text = "+";
            Plus.Size = new Size(60, 50);
            Plus.TextAlign = ContentAlignment.MiddleCenter;
            Plus.Location = new Point(175, 70);
            Plus.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(Plus);

            Label Ravno = new Label();
            Ravno.Text = "=";
            Ravno.Size = new Size(60, 50);
            Ravno.TextAlign = ContentAlignment.MiddleCenter;
            Ravno.Location = new Point(400, 70);
            Ravno.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(Ravno);

            sum = new NumericUpDown();
            sum.Size = new Size(80, 50);
            sum.Location = new Point(500, 77);
            sum.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(sum);

            //////////////////// 2 ряд/////////////////////////////////////////////////////////
            PlusLeftLabel2 = new Label();
            PlusLeftLabel2.Text = "?";
            PlusLeftLabel2.Size = new Size(60, 50);
            PlusLeftLabel2.TextAlign = ContentAlignment.MiddleCenter;
            PlusLeftLabel2.Location = new Point(50, 160);
            PlusLeftLabel2.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(PlusLeftLabel2);

            PlusRightLabel2 = new Label();
            PlusRightLabel2.Text = "?";
            PlusRightLabel2.Size = new Size(60, 50);
            PlusRightLabel2.TextAlign = ContentAlignment.MiddleCenter;
            PlusRightLabel2.Location = new Point(300, 160);
            PlusRightLabel2.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(PlusRightLabel2);

            Label Plus2 = new Label();
            Plus2.Text = "-";
            Plus2.Size = new Size(60, 50);
            Plus2.TextAlign = ContentAlignment.MiddleCenter;
            Plus2.Location = new Point(175, 160);
            Plus2.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(Plus2);

            Label Ravno2 = new Label();
            Ravno2.Text = "=";
            Ravno2.Size = new Size(60, 50);
            Ravno2.TextAlign = ContentAlignment.MiddleCenter;
            Ravno2.Location = new Point(400, 160);
            Ravno2.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(Ravno2);

            answer2 = new NumericUpDown();
            answer2.Size = new Size(80, 50);
            answer2.Location = new Point(500, 166);
            answer2.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(answer2);

            //////////////////// 3 ряд////////////////////////////////
            PlusLeftLabel3 = new Label();
            PlusLeftLabel3.Text = "?";
            PlusLeftLabel3.Size = new Size(60, 50);
            PlusLeftLabel3.TextAlign = ContentAlignment.MiddleCenter;
            PlusLeftLabel3.Location = new Point(50, 250);
            PlusLeftLabel3.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(PlusLeftLabel3);

            PlusRightLabel3 = new Label();
            PlusRightLabel3.Text = "?";
            PlusRightLabel3.Size = new Size(60, 50);
            PlusRightLabel3.TextAlign = ContentAlignment.MiddleCenter;
            PlusRightLabel3.Location = new Point(300, 250);
            PlusRightLabel3.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(PlusRightLabel3);

            Label Plus3 = new Label();
            Plus3.Text = "×";
            Plus3.Size = new Size(60, 50);
            Plus3.TextAlign = ContentAlignment.MiddleCenter;
            Plus3.Location = new Point(175, 250);
            Plus3.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(Plus3);

            Label Ravno3 = new Label();
            Ravno3.Text = "=";
            Ravno3.Size = new Size(60, 50);
            Ravno3.TextAlign = ContentAlignment.MiddleCenter;
            Ravno3.Location = new Point(400, 250);
            Ravno3.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(Ravno3);

            answer3 = new NumericUpDown();
            answer3.Size = new Size(80, 50);
            answer3.Location = new Point(500, 258);
            answer3.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(answer3);

            //////////////////// 4 ряд///////////////////////////////////////////
            PlusLeftLabel4 = new Label();
            PlusLeftLabel4.Text = "?";
            PlusLeftLabel4.Size = new Size(60, 50);
            PlusLeftLabel4.TextAlign = ContentAlignment.MiddleCenter;
            PlusLeftLabel4.Location = new Point(50, 340);
            PlusLeftLabel4.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(PlusLeftLabel4);

            Label Plus4 = new Label();
            Plus4.Text = "÷";
            Plus4.Size = new Size(60, 50);
            Plus4.TextAlign = ContentAlignment.MiddleCenter;
            Plus4.Location = new Point(175, 340);
            Plus4.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(Plus4);

            PlusRightLabel4 = new Label();
            PlusRightLabel4.Text = "?";
            PlusRightLabel4.Size = new Size(60, 50);
            PlusRightLabel4.TextAlign = ContentAlignment.MiddleCenter;
            PlusRightLabel4.Location = new Point(300, 340);
            PlusRightLabel4.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(PlusRightLabel4);

            Label Ravno4 = new Label();
            Ravno4.Text = "=";
            Ravno4.Size = new Size(60, 50);
            Ravno4.TextAlign = ContentAlignment.MiddleCenter;
            Ravno4.Location = new Point(400, 340);
            Ravno4.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(Ravno4);

            answer4 = new NumericUpDown();
            answer4.Size = new Size(80, 50);
            answer4.Location = new Point(500, 347);
            answer4.Font = new Font("Arial", 18, FontStyle.Bold);
            this.Controls.Add(answer4);

            // Кнопка запуска
            StartButton = new Button();
            StartButton.Text = "Start mang";
            StartButton.Size = new Size(180, 50);
            AutoSize = true;
            StartButton.Font = new Font("Arial", 14, FontStyle.Bold);
            StartButton.Location = new Point(200, 450);
            StartButton.Click += startButton_Click;
            this.Controls.Add(StartButton);

            // Таймер
            timer1 = new Timer();
            timer1.Interval = 1000; // 1 секунда
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        
        public void StartTheQuiz()
        {
           
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            // Вычитание
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            PlusLeftLabel2.Text = minuend.ToString();
            PlusRightLabel2.Text = subtrahend.ToString();
            answer2.Value = 0;

            // Умножение
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            PlusLeftLabel3.Text = multiplicand.ToString();
            PlusRightLabel3.Text = multiplier.ToString();
            answer3.Value = 0;

            // Деление
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            PlusLeftLabel4.Text = dividend.ToString();
            PlusRightLabel4.Text = divisor.ToString();
            answer4.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 secondid";
            timer1.Start();
        }

        
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == answer2.Value)
                && (multiplicand * multiplier == answer3.Value)
                && (dividend / divisor == answer4.Value))
                return true;
            else
                return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
               
                timer1.Stop();
                MessageBox.Show("Koik vastused on oige!", "Vaha hea!");
                StartButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
              
                
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " secundid";
            }
            else
            {
               
                timer1.Stop();
                timeLabel.Text = "Aeg lopp!";
                MessageBox.Show("Sa ei kirjutanud koik vastused!");
                sum.Value = addend1 + addend2;
                answer2.Value = minuend - subtrahend;
                answer3.Value = multiplicand * multiplier;
                answer4.Value = dividend / divisor;
                StartButton.Enabled = true;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            StartButton.Enabled = false;
        }
    }
}
