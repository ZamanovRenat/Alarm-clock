using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // функция PlaySound, обеспечивает воспроизведение wav-файлов, находится в библиотеке winmm.dll подключим эту библиотеку
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern
            Boolean PlaySound(string IpszName, int hModule, int dwFlags);

        //Время сигнала (отображения сообщения)
        private DateTime alarm;

        public Form1()
        {
            InitializeComponent();
            //параметры компонентов
            numricUpDown1.Maximum = 23;
            numricUpDown1.Minimum = 0;

            numricUpDown2.Maximum = 59;
            numricUpDown2.Minimum = 0;

            numricUpDown1.Value = DateTime.Now.Hour;
            numricUpDown2.Value = DateTime.Now.Minute;

            notifyIcon1.Visible = false;

            //Период обработки сигнала от таймера
            timer1.Interval = 1000;
            timer1.Enabled = true;

            label12.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label12.Text = DateTime.Now.ToLongTimeString();
            
            //Будильник установлен
            if (CheckBox1.Checked)
            {
                if (DateTime.Compare(DateTime.alarm) > 0)
                    CheckBox.Checked = false;

            }
        }

    }
}

