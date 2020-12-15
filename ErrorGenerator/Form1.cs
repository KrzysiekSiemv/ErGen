using System;
using System.Windows.Forms;

namespace ErrorGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generate_Click(object sender, EventArgs e)
        {
            showMessage(title.Text, text.Text, buttons.SelectedIndex, type.SelectedIndex);
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

            MessageBox.Show(text, title, button, type);
        }

        private void linkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/KrzysiekSiemv");
        }
    }
}
