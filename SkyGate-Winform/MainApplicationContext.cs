using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyGate_ADONET
{
    public class MainApplicationContext : ApplicationContext
    {
        public MainApplicationContext()
        {
            ShowLoginForm();
        }

        public void ShowLoginForm()
        {
            LoginForm loginForm = new LoginForm();
            this.MainForm = loginForm; 

            loginForm.FormClosed += (s, args) =>
            {                
                if (this.MainForm.InvokeRequired)
                {
                    this.MainForm.Invoke(new Action(() =>
                    {
                        // 如果使用者是透過登入按鈕關閉的 (Tag == "LoggedIn")
                        if (loginForm.Tag as string == "LoggedIn")
                        {
                            ShowMainForm();
                        }
                        // 否則，表示使用者點了 X 關閉，結束整個程式
                        else
                        {
                            ExitThread();
                        }
                    }));
                }
                else
                {
                    if (loginForm.Tag as string == "LoggedIn")
                    {
                        ShowMainForm();
                    }
                    else
                    {
                        ExitThread();
                    }
                }
            };

            loginForm.Show();
        }

        public void ShowMainForm()
        {          
            Form1 mainForm = new Form1();
            this.MainForm = mainForm;

            mainForm.FormClosed += (s, args) =>
            {
                /*
                if (this.MainForm.InvokeRequired)
                {
                    this.MainForm.Invoke(new Action(() =>
                    {
                        // Form1 關閉代表登出，切換回登入畫面
                        ShowLoginForm();
                    }));
                }
                else
                {
                    ShowLoginForm();
                }
                */

                // 根據 Form1 關閉時的 Tag 判斷意圖
                if (mainForm.Tag as string == "LoggingOut")
                {                    
                    ShowLoginForm();
                }
                else
                {
                    // 按下了右上角的 X，結束整個應用程式
                    ExitThread();
                }
            };
            mainForm.Show();
        }
    }
}
