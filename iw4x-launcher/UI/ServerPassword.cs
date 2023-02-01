using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iw4x_launcher.UI
{
    public partial class ServerPassword : Form
    {
        private readonly Localization l = Localization.Languages;
        private readonly Functions f = Functions.Methods;
        public ServerPassword()
        {
            InitializeComponent();
        }

        private void ServerPassword_Load(object sender, EventArgs e)
        {
            SetLanguage();
        }
        private void SetLanguage()
        {
            if(f.SelectedLanguage == Functions.Language.English)
            {
                this.Text = "Set Server Password";
                groupBox1.Text = "Password";
                btnConfirm.Text = "Confirm";
            }else if(f.SelectedLanguage == Functions.Language.Russian)
            {
                this.Text = "Установите пароль сервера";
                groupBox1.Text = "Пароль";
                btnConfirm.Text = "Подтвердить";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                f.SelectedServerPassword = textBox1.Text;
                this.Close();
            }
        }
    }
}
