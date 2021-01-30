using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
namespace ErrorGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void generate_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                timer1.Start();

            Thread.Sleep(Convert.ToInt32(numericUpDown1.Value * 1000));
            Repeat(Convert.ToInt32(numericUpDown2.Value), () => showMessage(title.Text, text.Text, buttons.SelectedIndex, type.SelectedIndex));
        }

        public static void Repeat(int times, Action action)
        {
            for(int i = 0; i < times; i++)
            {
                action();
            }
        }

        void showMessage(string title, string text, int buttons, int types)
        {
            var button = new MessageBoxButtons();
            var type = new MessageBoxIcon();

            #region Przyciski
            if (buttons == 0)
                button = MessageBoxButtons.AbortRetryIgnore;
            else if (buttons == 1)
                button = MessageBoxButtons.OK;
            else if (buttons == 2)
                button = MessageBoxButtons.OKCancel;
            else if (buttons == 3)
                button = MessageBoxButtons.RetryCancel;
            else if (buttons == 4)
                button = MessageBoxButtons.YesNo;
            else if (buttons == 5)
                button = MessageBoxButtons.YesNoCancel;
            else
                button = MessageBoxButtons.OK;
            #endregion
            #region Ikona
            if (types == 0)
                type = MessageBoxIcon.Error;
            else if (types == 1)
                type = MessageBoxIcon.Information;
            else if (types == 2)
                type = MessageBoxIcon.Warning;
            else if (types == 3)
                type = MessageBoxIcon.Question;
            else
                type = MessageBoxIcon.Information;
            #endregion

            Thread.Sleep(Convert.ToInt32(numericUpDown3.Value * 1000));
            MessageBox.Show(text, title, button, type);
        }

        private void linkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/KrzysiekSiemv");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings settings = new Properties.Settings();
            if(settings.Ikona != "")
                notifyIcon1.Icon = new Icon(settings.Ikona);

            notifyIcon1.Text = settings.TytulIkony;

            if (checkBox1.Checked)
            {
                notifyIcon1.Visible = true;
                button2.Enabled = true;
            }
            else
            {
                notifyIcon1.Visible = false;
                button2.Enabled = false;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Klikniecie == 1)
            {
                if (checkBox2.Checked)
                    timer1.Start();

                Repeat(Convert.ToInt32(numericUpDown2.Value), () => showMessage(title.Text, text.Text, buttons.SelectedIndex, type.SelectedIndex));
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Klikniecie == 0)
            {
                if (checkBox2.Checked)
                    timer1.Start();

                Repeat(Convert.ToInt32(numericUpDown2.Value), () => showMessage(title.Text, text.Text, buttons.SelectedIndex, type.SelectedIndex));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UstawieniaNotify ustawienia = new UstawieniaNotify();
            ustawienia.Show();
        }

        private void button2_Click(object sender, EventArgs e) { this.Visible = false; }
        private void wyłaczToolStripMenuItem_Click(object sender, EventArgs e) { this.Close(); }
        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e) { this.Visible = true;  }

        private void timer1_Tick(object sender, EventArgs e)
        {
            showMessage(title.Text, text.Text, buttons.SelectedIndex, type.SelectedIndex);
            timer1.Stop();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                numericUpDown2.Value = 1;
                numericUpDown2.Enabled = false;
            }
            else
            {
                numericUpDown2.Enabled = true;
            }
        }
    }
}
