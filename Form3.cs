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
        Label firstClicked = null;
        Label secondClicked = null;

        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        public FormMatchingGame()
        {
            InitializeComponent();
            AssignIconsToSquares();
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

        /// <summary>
        /// Assign each icon from the list of icons to a random square
        /// </summary>
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor; // скрываем иконку
                    icons.RemoveAt(randomNumber);

                    // Подключаем один и тот же обработчик Click ко всем меткам
                    iconLabel.Click += label1_Click;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) return; // Игнорируем клики, пока таймер работает

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return; // Уже открытая иконка

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                // Вторая иконка
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                // Проверяем победу
                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    // Совпали — оставляем открытыми
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                // Не совпали — запускаем таймер
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            // Скрываем несовпавшие иконки
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        /// <summary>
        /// Проверка победы — если все иконки открыты, поздравляем игрока
        /// </summary>
        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return; // Есть ещё закрытые иконки
                }
            }

            // Все иконки открыты — игрок выиграл
            MessageBox.Show("Sa leidsid koik paarid!", "Vaha hea! 🎉");
            Close();
        }
    }
}
