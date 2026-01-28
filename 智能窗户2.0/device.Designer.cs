namespace 智能窗户2._0
{
    partial class device
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connect = new System.Windows.Forms.Button();
            this.flash = new System.Windows.Forms.Button();
            this.listDevice = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.connect.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.connect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect.Font = new System.Drawing.Font("思源黑体 CN Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.connect.ForeColor = System.Drawing.Color.Black;
            this.connect.Location = new System.Drawing.Point(188, 458);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(175, 51);
            this.connect.TabIndex = 8;
            this.connect.Text = "连接";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // flash
            // 
            this.flash.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.flash.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.flash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.flash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flash.Font = new System.Drawing.Font("思源黑体 CN Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flash.ForeColor = System.Drawing.Color.Black;
            this.flash.Location = new System.Drawing.Point(18, 458);
            this.flash.Name = "flash";
            this.flash.Size = new System.Drawing.Size(164, 51);
            this.flash.TabIndex = 7;
            this.flash.Text = "刷新";
            this.flash.UseVisualStyleBackColor = true;
            this.flash.Click += new System.EventHandler(this.flash_Click);
            // 
            // listDevice
            // 
            this.listDevice.BackColor = System.Drawing.Color.White;
            this.listDevice.Font = new System.Drawing.Font("思源黑体 CN Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listDevice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listDevice.FormattingEnabled = true;
            this.listDevice.ItemHeight = 33;
            this.listDevice.Location = new System.Drawing.Point(18, 17);
            this.listDevice.MaximumSize = new System.Drawing.Size(400, 500);
            this.listDevice.MinimumSize = new System.Drawing.Size(328, 420);
            this.listDevice.Name = "listDevice";
            this.listDevice.Size = new System.Drawing.Size(345, 433);
            this.listDevice.TabIndex = 6;
            this.listDevice.SelectedIndexChanged += new System.EventHandler(this.listDevice_SelectedIndexChanged);
            // 
            // device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(382, 520);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.flash);
            this.Controls.Add(this.listDevice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(382, 520);
            this.MinimumSize = new System.Drawing.Size(382, 520);
            this.Name = "device";
            this.Text = "device";
            this.Load += new System.EventHandler(this.device_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button flash;
        private System.Windows.Forms.ListBox listDevice;
    }
}