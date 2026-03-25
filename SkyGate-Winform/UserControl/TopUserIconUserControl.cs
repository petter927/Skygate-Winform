using System;
using System.Windows.Forms;

namespace SkyGate_ADONET
{
    public partial class TopUserIconUserControl : UserControl
    {
        public event EventHandler LogoutClicked;
        public TopUserIconUserControl()
        {
            InitializeComponent();
            InitializeControls();
            InitializeUserInfo();
        }

        private void InitializeControls()
        {
            btnUserIcon.FlatAppearance.BorderSize = 0;
            btnUserIcon.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Visible = false;
        }
        private void InitializeUserInfo()
        {
            string welcome = $"{UserInfo.EmpName}";
            lblUserName.Text = welcome;
            lblUserName.ForeColor = System.Drawing.Color.White;
        }

        private void TopUserIconUserControl_Load(object sender, EventArgs e)
        {
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {            
            LogoutClicked?.Invoke(this, EventArgs.Empty);



        }

        private void btnUserIcon_Click(object sender, EventArgs e)
        {
            btnLogout.Visible = !btnLogout.Visible;
        }
    }
}
