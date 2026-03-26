using SkyGate_ADONET.DAL.Repositories;
using SkyGate_ADONET.Services;
using SkyGate_ADONET.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyGate_ADONET
{
    public partial class Form1 : Form
    {
        private Dictionary<string, UserControl> userControls;
        private UserControl currentControl;
        private System.Drawing.Color originalButtonColor;
        private TopUserIconUserControl topUserIconControl;

        // 登出事件，ApplicationContext 會訂閱它
        public event EventHandler LogoutRequested;


        public Form1()
        {
            InitializeComponent();
            InitializeNavigation();
            LoadUserControls();
            ShowTopUserIconUserControl();

            topUserIconControl.LogoutClicked += TopUserIconUserControl_LogoutClicked;
        }

        private void InitializeNavigation()
        {
            var buttons = new[]
            {
                new { Key = "Attendance", Text = "出勤登記" },
                new { Key = "LeaveRequest", Text = "請假申請" },
                new { Key = "LeaveApprove", Text = "請假審核" },
                new { Key = "OTRequest", Text = "加班申請" },
                new { Key = "OTApprove", Text = "加班審核" },
                new { Key = "AttendanceReport", Text = "紀錄查詢" },
                new { Key = "HRManagement", Text = "人事管理" },
                new { Key = "SystemManagement", Text = "系統管理" }
            };
            foreach (var button in buttons)
            {
                string imagePath;

                switch (button.Key)
                {
                    case "Attendance":
                        imagePath = @"..\..\pic\biological-clock.png";
                        break;
                    case "LeaveRequest":
                        imagePath = @"..\..\pic\holiday.png";
                        break;
                    case "LeaveApprove":
                        imagePath = @"..\..\pic\car.png";
                        break;
                    case "OTRequest":
                        imagePath = @"..\..\pic\overtime.png";
                        break;
                    case "OTApprove":
                        imagePath = @"..\..\pic\approved.png";
                        break;
                    case "AttendanceReport":
                        imagePath = @"..\..\pic\hr.png";
                        break;
                    case "HRManagement":
                        imagePath = @"..\..\pic\customer-care.png";
                        break;
                    case "SystemManagement":
                        imagePath = @"..\..\pic\web-settings.png";
                        break;
                    default:
                        imagePath = null; 
                        break;
                }

                Button btn = new Button
                {
                    Text = "",
                    Tag = button.Key,
                    Size = new Size(130, 40),
                    Margin = new Padding(0),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("新細明體", 14, FontStyle.Bold)
                };
                btn.Click += NavigationButton_Click;
                btn.FlatAppearance.BorderSize = 0;

                btn.ImageAlign = ContentAlignment.MiddleCenter; //btn0按鈕圖案對齊位置
                //btn.TextAlign = ContentAlignment.MiddleRight;  //btn0按鈕文字對齊位置
                //btn.ForeColor = System.Drawing.Color.FromArgb(255, 160, 50);
                btn.MouseEnter += new EventHandler(button_MouseEnter);
                btn.MouseLeave += new EventHandler(button_MouseLeave);

                if (!string.IsNullOrEmpty(imagePath))
                {
                    try
                    {
                        btn.Image = Image.FromFile(imagePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"載入圖片失敗: {ex.Message}");
                    }
                }

                flowLayoutButtons.Controls.Add(btn);
            }

            if (flowLayoutButtons.Controls.Count > 0)
            {
                Button firstAddedButton = (Button)flowLayoutButtons.Controls[0];
                originalButtonColor = firstAddedButton.BackColor;
            }
        }
        private void LoadUserControls()
        {
            userControls = new Dictionary<string, UserControl>
            {
                { "Attendance", new AttendanceUserControl() },
                { "LeaveRequest", new LeaveRequestUserControl() },
                { "LeaveApprove", new LeaveApproveUserControl() },
                { "OTRequest", new OTRequestUserControl() },
                { "OTApprove", new OTApproveUserControl() },
                { "AttendanceReport", new AttendanceReportUserControl() },
                { "HRManagement", new HRManagementUserControl() },
                { "SystemManagement", new SystemManagementUserControl() }
            };
            ShowUserControl("Attendance");
        }

        private void InitializeControls()
        {
            
        }

        private void NavigationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            String controlKey = button.Tag.ToString();
            ShowUserControl(controlKey);
        }

        private void ShowUserControl(string controlKey)
        {
            if (userControls.ContainsKey(controlKey))
            {
                if (currentControl != null)
                {
                    currentControl.Visible = false;
                    panelContent.Controls.Remove(currentControl);
                }

                currentControl = userControls[controlKey];
                currentControl.Location = new Point(0, 0);
                currentControl.AutoSize = true;
                panelContent.Controls.Add(currentControl);
                currentControl.Visible = true;
            }
        }

        private void ShowTopUserIconUserControl()
        {
            topUserIconControl = new TopUserIconUserControl();
            topUserIconControl.Dock = DockStyle.Right;
            topUserIconControl.AutoSize = true;
            panelContentTop.Controls.Add(topUserIconControl);
            topUserIconControl.Visible = true;
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;            
            string btnName = "";
            switch (button.Tag)
            {
                case "Attendance":
                    btnName = @"出勤登記";
                    break;
                case "LeaveRequest":
                    btnName = @"請假申請"; ;
                    break;
                case "LeaveApprove":
                    btnName = @"請假審核"; ;
                    break;
                case "OTRequest":
                    btnName = @"加班申請"; ;
                    break;
                case "OTApprove":
                    btnName = @"加班審核"; ;
                    break;
                case "AttendanceReport":
                    btnName = @"紀錄查詢"; ;
                    break;
                case "HRManagement":
                    btnName = @"人事管理"; ;
                    break;
                case "SystemManagement":
                    btnName = @"系統管理"; ;
                    break;
                default:
                    btnName = @""; ; 
                    break;
            }
            button.Text = btnName;
            button.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.TextAlign = ContentAlignment.MiddleRight;
            button.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = originalButtonColor;
            button.ImageAlign = ContentAlignment.MiddleCenter;
            //button.ForeColor = System.Drawing.Color.FromArgb(255, 160, 50);
            button.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ApplyRoleBasedPermissions();
        }

        private void ApplyRoleBasedPermissions()
        {
            String userRole = UserInfo.RoleName;

            foreach (Control control in flowLayoutButtons.Controls)
            {
                if (control is Button button)
                {
                    String controlKey = button.Tag.ToString();
                    button.Visible = HasPermission(userRole, controlKey);
                }
            }
        }

        private bool HasPermission(string role, string permission)
        {
            Dictionary<string, List<string>> permissions = new Dictionary<string, List<string>>
            {
                { "員工", new List<string> { "Attendance", "LeaveRequest", "OTRequest", "AttendanceReport" } },
                { "主管", new List<string> { "Attendance", "LeaveRequest", "LeaveApprove", "OTRequest", "OTApprove", "AttendanceReport" } },
                { "人事", new List<string> { "Attendance", "LeaveRequest", "LeaveApprove", "OTRequest", "OTApprove", "AttendanceReport", "HRManagement" } },
                { "系統管理員", new List<string> { "Attendance", "LeaveRequest", "LeaveApprove", "OTRequest", "OTApprove", "AttendanceReport", "HRManagement", "SystemManagement" } }
            };

            return permissions.ContainsKey(role) && permissions[role].Contains(permission);
        }

        private void TopUserIconUserControl_LogoutClicked(object sender, EventArgs e)
        {
            // 設定 Tag 標誌，告訴 Context 我們是要登出
            this.Tag = "LoggingOut";

            // 關閉 Form1。當它關閉時，MainApplicationContext 會捕捉到事件並切換回 LoginForm
            this.Close();
        }
    }
}
