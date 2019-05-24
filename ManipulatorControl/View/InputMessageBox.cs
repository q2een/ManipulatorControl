using System.Windows.Forms;

namespace ManipulatorControl
{
    public partial class InputMessageBox : Form
    {
        public InputMessageBox()
        {
            InitializeComponent();
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
    }
}
