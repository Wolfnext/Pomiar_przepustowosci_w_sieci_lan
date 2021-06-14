namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.ip_list_component = new System.Windows.Forms.ComboBox();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.upload_packet_size = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.download_packet_size = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.packet_size = new System.Windows.Forms.TextBox();
            this.avg_speed = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(879, 511);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Download TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ip_list_component
            // 
            this.ip_list_component.FormattingEnabled = true;
            this.ip_list_component.Location = new System.Drawing.Point(21, 41);
            this.ip_list_component.Margin = new System.Windows.Forms.Padding(4);
            this.ip_list_component.Name = "ip_list_component";
            this.ip_list_component.Size = new System.Drawing.Size(160, 24);
            this.ip_list_component.TabIndex = 1;
            // 
            // refresh_btn
            // 
            this.refresh_btn.Location = new System.Drawing.Point(189, 38);
            this.refresh_btn.Margin = new System.Windows.Forms.Padding(4);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(78, 28);
            this.refresh_btn.TabIndex = 2;
            this.refresh_btn.Text = "Odśwież";
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.AutoArrange = false;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(18, 30);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(653, 425);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(879, 475);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Upload TEST";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(707, 519);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ip_list_component);
            this.tabPage1.Controls.Add(this.refresh_btn);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(699, 490);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ustawienia serwera";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adres IP serwera";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(699, 490);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ustawienia pomiaru";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.upload_packet_size);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(16, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 255);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.download_packet_size);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(356, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(331, 255);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Wysyłanie (upload)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Pobieranie (download)";
            // 
            // upload_packet_size
            // 
            this.upload_packet_size.Location = new System.Drawing.Point(19, 82);
            this.upload_packet_size.Name = "upload_packet_size";
            this.upload_packet_size.Size = new System.Drawing.Size(108, 22);
            this.upload_packet_size.TabIndex = 2;
            this.upload_packet_size.Text = "10485760";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Wielkość pakieu [bajtów]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Wielkość pakieu [bajtów]";
            // 
            // download_packet_size
            // 
            this.download_packet_size.Location = new System.Drawing.Point(20, 82);
            this.download_packet_size.Name = "download_packet_size";
            this.download_packet_size.Size = new System.Drawing.Size(108, 22);
            this.download_packet_size.TabIndex = 4;
            this.download_packet_size.Text = "10485760";
            this.download_packet_size.TextChanged += new System.EventHandler(this.download_packet_size_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(699, 490);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Wyniki";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 548);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1035, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 7;
            // 
            // packet_size
            // 
            this.packet_size.Location = new System.Drawing.Point(754, 78);
            this.packet_size.Name = "packet_size";
            this.packet_size.ReadOnly = true;
            this.packet_size.Size = new System.Drawing.Size(241, 22);
            this.packet_size.TabIndex = 8;
            // 
            // avg_speed
            // 
            this.avg_speed.Location = new System.Drawing.Point(756, 138);
            this.avg_speed.Name = "avg_speed";
            this.avg_speed.ReadOnly = true;
            this.avg_speed.Size = new System.Drawing.Size(241, 22);
            this.avg_speed.TabIndex = 9;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(751, 58);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(150, 17);
            this.name.TabIndex = 10;
            this.name.Text = "Wielkość pakietu (bits)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(753, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Średnia prędkość (Kbps)";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Log";
            this.columnHeader1.Width = 600;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 576);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.name);
            this.Controls.Add(this.avg_speed);
            this.Controls.Add(this.packet_size);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Pomiar przepstowości w sieci LAN";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ip_list_component;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox download_packet_size;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox upload_packet_size;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox packet_size;
        private System.Windows.Forms.TextBox avg_speed;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

