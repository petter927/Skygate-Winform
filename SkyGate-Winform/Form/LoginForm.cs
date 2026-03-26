using SkyGate_Winform.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SkyGate_ADONET
{

    public partial class LoginForm : Form
    {
        private string connectionString = ConnectionStringHelper.GetConnectionString();


        public LoginForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            btnLogin.ForeColor = System.Drawing.Color.White;
            //btnLogin.BackColor = System.Drawing.Color.Green;
        }


        private bool VerifyLogin(string account, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {                    
                    string sql = @"SELECT sa.Password, sa.IsActive, sa.AccountID, e.EmpID, e.EmpName, sa.Account, sr.RoleName 
                                            FROM Employee e JOIN SysAccount sa ON e.EmpID = sa.EmpID 
                                            LEFT JOIN SysUserRole sur ON e.EmpID = sur.EmpID 
                                            LEFT JOIN SysRole sr ON sur.RoleID = sr.RoleID 
                                            WHERE Account = @Account ";

                    // 1. 參數化查詢：這是為了防止惡意代碼從帳號輸入框注入資料庫 (SQL Injection)
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Account", account);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {                                
                                bool isActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                                
                                if (!isActive)
                                {
                                    errorMessage = "帳號已停用，請聯繫管理員";
                                    return false;
                                }
                                
                                string storedPassword = reader["Password"].ToString();
                                // 2. 雜湊比對：資料庫不存明碼密碼。比對時先將使用者輸入雜湊化，再跟 DB 裡的雜湊值比對。
                                // 這確保了就算資料庫管理員也看不到使用者的原始密碼。
                                string encryptedPassword = EncryptPassword(password);

                                if (storedPassword == encryptedPassword)
                                {                                    
                                    string empID = reader["EmpID"].ToString();
                                    string accountID = reader["AccountID"].ToString();
                                    string EmpName = reader["EmpName"].ToString();
                                    string RoleName = reader["RoleName"].ToString();
                                    
                                    UpdateLastLogin(accountID);

                                    // 3. 全域狀態：將成功登入者的資訊暫存，讓後續 UserControl (如請假、加班) 能識別操作者。
                                    UserInfo.EmpID = empID;
                                    UserInfo.EmpName = EmpName;
                                    UserInfo.RoleName = RoleName;
                                    //UserInfo.RoleID = "員工";
                                    //UserInfo.RoleID = "主管";
                                    //UserInfo.RoleID = "人事";
                                    //UserInfo.RoleID = "系統管理員";

                                    return true;
                                }
                                else
                                {
                                    errorMessage = "密碼錯誤，請重新輸入";
                                    return false;
                                }
                            }
                            else
                            {
                                errorMessage = "帳號不存在，請檢查帳號是否正確";
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"登入過程中發生錯誤：{ex.Message}";
                return false;
            }
        }

        private string EncryptPassword(string password)
        {
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        private void UpdateLastLogin(string accountID)
        {
            string sql = "UPDATE SysAccount SET LastLogin = GETDATE(), UpdatedAt = GETDATE() WHERE AccountID = @AccountID";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@AccountID", accountID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string account = txtAccount.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("請輸入帳號和密碼", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccount.Focus();
                return;
            }

            // 驗證方法
            string errorMessage;
            bool isSuccess = VerifyLogin(account, password, out errorMessage);

            if (isSuccess)
            {
                // 登入成功，設定對話結果為 OK
                //this.DialogResult = DialogResult.OK;
                //this.Close();

                // 設定一個 Tag 標誌，讓 Context 知道接下來要開主畫面
                this.Tag = "LoggedIn";

                // 關閉登入表單。當它關閉時，MainApplicationContext 會捕捉到事件並切換到 Form1
                this.Close();
            }
            else
            {
                // 登入失敗，顯示錯誤訊息並停留在登入畫面
                MessageBox.Show(errorMessage, "登入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }        
    }
}
