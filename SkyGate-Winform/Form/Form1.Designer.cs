using System.Windows.Forms;

namespace SkyGate_ADONET
{
    partial class Form1
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.flowLayoutButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLeftTop = new System.Windows.Forms.Panel();
            this.panelLeftBottom = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelContentTop = new System.Windows.Forms.Panel();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.flowLayoutButtons);
            this.panelLeft.Controls.Add(this.panelLeftTop);
            this.panelLeft.Controls.Add(this.panelLeftBottom);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(133, 707);
            this.panelLeft.TabIndex = 0;
            // 
            // flowLayoutButtons
            // 
            this.flowLayoutButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(50)))));
            this.flowLayoutButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutButtons.Location = new System.Drawing.Point(0, 50);
            this.flowLayoutButtons.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutButtons.Name = "flowLayoutButtons";
            this.flowLayoutButtons.Padding = new System.Windows.Forms.Padding(0, 33, 0, 0);
            this.flowLayoutButtons.Size = new System.Drawing.Size(133, 607);
            this.flowLayoutButtons.TabIndex = 2;
            // 
            // panelLeftTop
            // 
            this.panelLeftTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(50)))));
            this.panelLeftTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLeftTop.BackgroundImage")));
            this.panelLeftTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftTop.Location = new System.Drawing.Point(0, 0);
            this.panelLeftTop.Name = "panelLeftTop";
            this.panelLeftTop.Size = new System.Drawing.Size(133, 50);
            this.panelLeftTop.TabIndex = 0;
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(50)))));
            this.panelLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 657);
            this.panelLeftBottom.Name = "panelLeftBottom";
            this.panelLeftBottom.Size = new System.Drawing.Size(133, 50);
            this.panelLeftBottom.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(133, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(734, 657);
            this.panelContent.TabIndex = 1;
            // 
            // panelContentTop
            // 
            this.panelContentTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(50)))));
            this.panelContentTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContentTop.Location = new System.Drawing.Point(133, 0);
            this.panelContentTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelContentTop.Name = "panelContentTop";
            this.panelContentTop.Size = new System.Drawing.Size(734, 50);
            this.panelContentTop.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(850, 850);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelContentTop);
            this.Controls.Add(this.panelLeft);
            this.Name = "Form1";
            this.Text = "員工出勤系統";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelLeftTop;
        private System.Windows.Forms.Panel panelLeftBottom;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutButtons;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelContentTop;

        #endregion
    }
}

