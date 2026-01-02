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

        int moves = 0; // счетчик ходов
        int seconds = 0; // счетчик секунд
        Label movesLabel;
        Label timerLabel;
        Button restartButton;
        Timer gameTimer = new Timer();

        public FormMatchingGame()
        {
            InitializeComponent();
            AssignIconsToSquares();

            this.Text = "Matching Game";
            this.Width = 800;
            this.Height = 600;

            // Главный Label
            Label label = new Label();
            label.Text = "Siin tuleb Matching Game!";
            label.Font = new Font("Arial", 20, FontStyle.Bold);
            label.AutoSize = true;
            label.Location = new Point(200, 150);
            this.Controls.Add(label);

            // Label для ходов
            movesLabel = new Label();
            movesLabel.Text = "Hoidud: 0";
            movesLabel.Font = new Font("Arial", 14, FontStyle.Regular);
            movesLabel.AutoSize = true;
            movesLabel.Location = new Point(200, 220);
            this.Controls.Add(movesLabel);

            // Label для таймера
            timerLabel = new Label();
            timerLabel.Text = "Aeg: 0s";
            timerLabel.Font = new Font("Arial", 14, FontStyle.Regular);
            timerLabel.AutoSize = true;
            timerLabel.Location = new Point(400, 220);
            this.Controls.Add(timerLabel);

            // Кнопка "Начать заново"
            restartButton = new Button();
            restartButton.Text = "Alusta uuesti";
            restartButton.Location = new Point(600, 20);
            restartButton.Click += RestartButton_Click;
            this.Controls.Add(restartButton);

            // Настройка игрового таймера
            gameTimer.Interval = 1000; // 1 секунда
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

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

                    // Подключаем обработчик Click ко всем меткам
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

                // Увеличиваем счетчик ходов
                moves++;
                movesLabel.Text = $"Hoidud: {moves}";

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

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            seconds++;
            timerLabel.Text = $"Aeg: {seconds}s";
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            // Сбрасываем иконки
            icons = new List<string>()
            {
                "!", "!", "N", "N", ",", ",", "k", "k",
                "b", "b", "v", "v", "w", "w", "z", "z"
            };

            firstClicked = null;
            secondClicked = null;
            moves = 0;
            seconds = 0;
            movesLabel.Text = "Hoidud: 0";
            timerLabel.Text = "Aeg: 0s";

            AssignIconsToSquares();
            gameTimer.Start();
        }

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

            gameTimer.Stop();
            MessageBox.Show($"Sa leidsid koik paarid! 🎉\nAeg: {seconds} sekundit, Hoidud: {moves}", "Vaha hea!");
            Close();
        }
    }
}
