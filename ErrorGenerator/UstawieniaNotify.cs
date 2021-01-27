using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorGenerator
{
    public partial class UstawieniaNotify : Form
    {
        static Properties.Settings settings = new Properties.Settings();
        public UstawieniaNotify()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void UstawieniaNotify_Load(object sender, EventArgs e)
        {
            textBox1.Text = settings.Ikona;
            textBox2.Text = settings.TytulIkony;
            if (settings.Klikniecie == 0)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            settings.Ikona = textBox1.Text;
            settings.TytulIkony = textBox2.Text;
            if (radioButton1.Checked)
                settings.Klikniecie = 0;
            else
                settings.Klikniecie = 1;

            settings.Save();
            MessageBox.Show("Ustawienia Notify zostały zapisane", "Zapisano!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
