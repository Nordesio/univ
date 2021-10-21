﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLinkor
{
    public partial class FormLinkor : Form
    {
        private ITransport warship;
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormLinkor()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод отрисовки машины
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxLinkor.Width, pictureBoxLinkor.Height);
            Graphics gr = Graphics.FromImage(bmp);
            warship.DrawTransport(gr);
            pictureBoxLinkor.Image = bmp;
        }
/// <summary>
/// Обработка нажатия кнопки "Создать автомобиль"
/// </summary>
/// <param name="sender"></param>



/// <param name="e"></param>
private void buttonCreateWarship_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            warship = new Warship(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Cyan);
            warship.SetPosition(50, 50, pictureBoxLinkor.Width, pictureBoxLinkor.Height);
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать гоночный автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateLinkor_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            warship = new Linkor(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Cyan,
            Color.Brown, true, true, true, true);
            warship.SetPosition(50, 50, pictureBoxLinkor.Width, pictureBoxLinkor.Height);
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    warship.MoveTransport(Directions.Up);

                    break;
                case "buttonDown":
                    warship.MoveTransport(Directions.Down);

                    break;
                case "buttonLeft":
                    warship.MoveTransport(Directions.Left);

                    break;
                case "buttonRight":
                    warship.MoveTransport(Directions.Right);

                    break;

            }
            Draw();
        }


    }
}