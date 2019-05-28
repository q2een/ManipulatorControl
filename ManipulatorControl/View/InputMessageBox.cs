using System.Windows.Forms;

namespace ManipulatorControl
{
    public partial class InputMessageBox : Form
    {
        public InputMessageBox()
        {
            InitializeComponent();
            Validate();
        }

        public string Input
        {
            get
            {
                return tbText.Text;
            }
            set
            {
                tbText.Text = value;
            }
        }

        public new void Show()
        {
            this.ShowDialog();
        }

        private void tbText_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbText.Text.Trim().Replace("\n", "").Length < 3)
                errorProvider.SetError(tbText, "Имя должно состоять как минимум из трех символов");
            else
                errorProvider.Clear();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (errorProvider.GetError(tbText) != "")
                return;

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
