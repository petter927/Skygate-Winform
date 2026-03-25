namespace SkyGate_ADONET
{
    partial class TopUserIconUserControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnUserIcon = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(543, 13);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(50, 20);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "登出";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnUserIcon
            // 
            this.btnUserIcon.Image = global::SkyGate_ADONET.Properties.Resources.man_3535;
            this.btnUserIcon.Location = new System.Drawing.Point(497, 3);
            this.btnUserIcon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUserIcon.Name = "btnUserIcon";
            this.btnUserIcon.Size = new System.Drawing.Size(41, 35);
            this.btnUserIcon.TabIndex = 0;
            this.btnUserIcon.UseVisualStyleBackColor = true;
            this.btnUserIcon.Click += new System.EventHandler(this.btnUserIcon_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUserName.Location = new System.Drawing.Point(399, 12);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 29);
            this.lblUserName.TabIndex = 2;
            // 
            // TopUserIconUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnUserIcon);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TopUserIconUserControl";
            this.Size = new System.Drawing.Size(595, 79);
            this.Load += new System.EventHandler(this.TopUserIconUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUserIcon;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUserName;
    }
}
