namespace MeyileBogh
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_reset_settings = new System.Windows.Forms.Button();
            this.lbl_manuelArsiv = new System.Windows.Forms.Label();
            this.tb_manuelArsivKotasi = new System.Windows.Forms.TextBox();
            this.cb_manuelArsiv = new System.Windows.Forms.CheckBox();
            this.btn_kaydet = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_sleepingTime = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.cb_otoArsiv = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tb_BrowsedOft = new System.Windows.Forms.TextBox();
            this.lbl_otoArsiv = new System.Windows.Forms.Label();
            this.tb_BrowsedExcel = new System.Windows.Forms.TextBox();
            this.tb_otoArsivKota = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_arsivlenecekMail = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_arsivlenenMail = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_CC = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_testing = new System.Windows.Forms.Button();
            this.cb_autoCC = new System.Windows.Forms.CheckBox();
            this.cb_autoSubject = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.tb_MailSubject = new System.Windows.Forms.TextBox();
            this.tb_mailSender = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tb_LogPanel = new System.Windows.Forms.RichTextBox();
            this.btn_pause = new System.Windows.Forms.Button();
            this.lbl_n_tobeSent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_n_kalan = new System.Windows.Forms.Label();
            this.lbl_n_sent = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_gecen_dk = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_kalan_tahmini = new System.Windows.Forms.Label();
            this.lbl_yuzde = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(101)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(592, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 59);
            this.button1.TabIndex = 13;
            this.button1.Text = "Maile Boğ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(420, 636);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "©2021 Turkish Technic - İKB - İş Geliştirme Şefliği";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_reset_settings);
            this.panel1.Controls.Add(this.lbl_manuelArsiv);
            this.panel1.Controls.Add(this.tb_manuelArsivKotasi);
            this.panel1.Controls.Add(this.cb_manuelArsiv);
            this.panel1.Controls.Add(this.btn_kaydet);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tb_sleepingTime);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.cb_otoArsiv);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.tb_BrowsedOft);
            this.panel1.Controls.Add(this.lbl_otoArsiv);
            this.panel1.Controls.Add(this.tb_BrowsedExcel);
            this.panel1.Controls.Add(this.tb_otoArsivKota);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(10, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 596);
            this.panel1.TabIndex = 5;
            // 
            // btn_reset_settings
            // 
            this.btn_reset_settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_reset_settings.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset_settings.ForeColor = System.Drawing.SystemColors.Info;
            this.btn_reset_settings.Location = new System.Drawing.Point(76, 494);
            this.btn_reset_settings.Name = "btn_reset_settings";
            this.btn_reset_settings.Size = new System.Drawing.Size(108, 31);
            this.btn_reset_settings.TabIndex = 45;
            this.btn_reset_settings.Text = "Reset";
            this.btn_reset_settings.UseVisualStyleBackColor = false;
            this.btn_reset_settings.Click += new System.EventHandler(this.btn_reset_settings_Click);
            this.btn_reset_settings.MouseEnter += new System.EventHandler(this.btn_reset_settings_MouseEnter);
            this.btn_reset_settings.MouseLeave += new System.EventHandler(this.btn_reset_settings_MouseLeave);
            // 
            // lbl_manuelArsiv
            // 
            this.lbl_manuelArsiv.AutoSize = true;
            this.lbl_manuelArsiv.Enabled = false;
            this.lbl_manuelArsiv.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_manuelArsiv.Location = new System.Drawing.Point(19, 447);
            this.lbl_manuelArsiv.Name = "lbl_manuelArsiv";
            this.lbl_manuelArsiv.Size = new System.Drawing.Size(187, 18);
            this.lbl_manuelArsiv.TabIndex = 44;
            this.lbl_manuelArsiv.Text = "Kaç mailde bir arşivlesin?";
            // 
            // tb_manuelArsivKotasi
            // 
            this.tb_manuelArsivKotasi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_manuelArsivKotasi.Enabled = false;
            this.tb_manuelArsivKotasi.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_manuelArsivKotasi.Location = new System.Drawing.Point(300, 441);
            this.tb_manuelArsivKotasi.Multiline = true;
            this.tb_manuelArsivKotasi.Name = "tb_manuelArsivKotasi";
            this.tb_manuelArsivKotasi.Size = new System.Drawing.Size(120, 31);
            this.tb_manuelArsivKotasi.TabIndex = 43;
            this.tb_manuelArsivKotasi.TextChanged += new System.EventHandler(this.tb_manuelArsivKotasi_TextChanged);
            // 
            // cb_manuelArsiv
            // 
            this.cb_manuelArsiv.AutoSize = true;
            this.cb_manuelArsiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_manuelArsiv.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cb_manuelArsiv.Location = new System.Drawing.Point(23, 401);
            this.cb_manuelArsiv.Name = "cb_manuelArsiv";
            this.cb_manuelArsiv.Size = new System.Drawing.Size(199, 24);
            this.cb_manuelArsiv.TabIndex = 42;
            this.cb_manuelArsiv.Text = "Manuel Arşivleme Kapalı";
            this.cb_manuelArsiv.UseVisualStyleBackColor = true;
            this.cb_manuelArsiv.CheckedChanged += new System.EventHandler(this.cb_manuelArsiv_CheckedChanged);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_kaydet.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_kaydet.ForeColor = System.Drawing.SystemColors.Info;
            this.btn_kaydet.Location = new System.Drawing.Point(230, 494);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(108, 31);
            this.btn_kaydet.TabIndex = 41;
            this.btn_kaydet.Text = "Kaydet";
            this.btn_kaydet.UseVisualStyleBackColor = false;
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            this.btn_kaydet.MouseEnter += new System.EventHandler(this.btn_kaydet_MouseEnter);
            this.btn_kaydet.MouseLeave += new System.EventHandler(this.btn_kaydet_MouseLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(256, 19);
            this.label7.TabIndex = 40;
            this.label7.Text = "Mail Başına Bekleme Süresi (ms)";
            // 
            // tb_sleepingTime
            // 
            this.tb_sleepingTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_sleepingTime.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_sleepingTime.Location = new System.Drawing.Point(300, 262);
            this.tb_sleepingTime.Multiline = true;
            this.tb_sleepingTime.Name = "tb_sleepingTime";
            this.tb_sleepingTime.Size = new System.Drawing.Size(120, 31);
            this.tb_sleepingTime.TabIndex = 39;
            this.tb_sleepingTime.Text = "2300";
            this.tb_sleepingTime.TextChanged += new System.EventHandler(this.tb_sleepingTime_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(15, 165);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(475, 13);
            this.label27.TabIndex = 21;
            this.label27.Text = "______________________________________________________________________________";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.Info;
            this.button5.Location = new System.Drawing.Point(355, 114);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 31);
            this.button5.TabIndex = 4;
            this.button5.Text = "OFT Ekle";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.button5.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            // 
            // cb_otoArsiv
            // 
            this.cb_otoArsiv.AutoSize = true;
            this.cb_otoArsiv.Checked = true;
            this.cb_otoArsiv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_otoArsiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_otoArsiv.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cb_otoArsiv.Location = new System.Drawing.Point(23, 312);
            this.cb_otoArsiv.Name = "cb_otoArsiv";
            this.cb_otoArsiv.Size = new System.Drawing.Size(198, 24);
            this.cb_otoArsiv.TabIndex = 37;
            this.cb_otoArsiv.Text = "Otomatik Arşivleme Açık";
            this.cb_otoArsiv.UseVisualStyleBackColor = true;
            this.cb_otoArsiv.CheckedChanged += new System.EventHandler(this.cb_otoArsiv_CheckedChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.Info;
            this.button4.Location = new System.Drawing.Point(355, 62);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 31);
            this.button4.TabIndex = 2;
            this.button4.Text = "Excel Ekle";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            this.button4.MouseEnter += new System.EventHandler(this.button4_MouseEnter);
            this.button4.MouseLeave += new System.EventHandler(this.button4_MouseLeave);
            // 
            // tb_BrowsedOft
            // 
            this.tb_BrowsedOft.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_BrowsedOft.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_BrowsedOft.Location = new System.Drawing.Point(111, 113);
            this.tb_BrowsedOft.Multiline = true;
            this.tb_BrowsedOft.Name = "tb_BrowsedOft";
            this.tb_BrowsedOft.Size = new System.Drawing.Size(222, 31);
            this.tb_BrowsedOft.TabIndex = 3;
            // 
            // lbl_otoArsiv
            // 
            this.lbl_otoArsiv.AutoSize = true;
            this.lbl_otoArsiv.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_otoArsiv.Location = new System.Drawing.Point(19, 357);
            this.lbl_otoArsiv.Name = "lbl_otoArsiv";
            this.lbl_otoArsiv.Size = new System.Drawing.Size(195, 18);
            this.lbl_otoArsiv.TabIndex = 35;
            this.lbl_otoArsiv.Text = "Kaç mailde bir arşivlensin?";
            // 
            // tb_BrowsedExcel
            // 
            this.tb_BrowsedExcel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_BrowsedExcel.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_BrowsedExcel.Location = new System.Drawing.Point(111, 62);
            this.tb_BrowsedExcel.Multiline = true;
            this.tb_BrowsedExcel.Name = "tb_BrowsedExcel";
            this.tb_BrowsedExcel.Size = new System.Drawing.Size(222, 31);
            this.tb_BrowsedExcel.TabIndex = 1;
            // 
            // tb_otoArsivKota
            // 
            this.tb_otoArsivKota.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_otoArsivKota.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_otoArsivKota.Location = new System.Drawing.Point(300, 352);
            this.tb_otoArsivKota.Multiline = true;
            this.tb_otoArsivKota.Name = "tb_otoArsivKota";
            this.tb_otoArsivKota.Size = new System.Drawing.Size(120, 31);
            this.tb_otoArsivKota.TabIndex = 26;
            this.tb_otoArsivKota.Text = "50";
            this.tb_otoArsivKota.TextChanged += new System.EventHandler(this.tb_otoArsivKota_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(15, 118);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 18);
            this.label26.TabIndex = 16;
            this.label26.Text = "Oft Dosyası";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(15, 71);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 18);
            this.label25.TabIndex = 15;
            this.label25.Text = "Excel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "Kaynak Ekle";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(13, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 26);
            this.label8.TabIndex = 6;
            this.label8.Text = "Gelişmiş Ayarlar";
            // 
            // lbl_arsivlenecekMail
            // 
            this.lbl_arsivlenecekMail.AutoSize = true;
            this.lbl_arsivlenecekMail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_arsivlenecekMail.Location = new System.Drawing.Point(265, 279);
            this.lbl_arsivlenecekMail.Name = "lbl_arsivlenecekMail";
            this.lbl_arsivlenecekMail.Size = new System.Drawing.Size(17, 18);
            this.lbl_arsivlenecekMail.TabIndex = 39;
            this.lbl_arsivlenecekMail.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(11, 278);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(191, 19);
            this.label14.TabIndex = 38;
            this.label14.Text = "Arşivlenecek Mail Sayısı";
            // 
            // lbl_arsivlenenMail
            // 
            this.lbl_arsivlenenMail.AutoSize = true;
            this.lbl_arsivlenenMail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_arsivlenenMail.Location = new System.Drawing.Point(265, 315);
            this.lbl_arsivlenenMail.Name = "lbl_arsivlenenMail";
            this.lbl_arsivlenenMail.Size = new System.Drawing.Size(17, 18);
            this.lbl_arsivlenenMail.TabIndex = 27;
            this.lbl_arsivlenenMail.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(11, 314);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(174, 19);
            this.label21.TabIndex = 25;
            this.label21.Text = "Arşivlenen Mail Sayısı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mail Ayarları";
            // 
            // tb_CC
            // 
            this.tb_CC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_CC.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_CC.Location = new System.Drawing.Point(93, 165);
            this.tb_CC.Multiline = true;
            this.tb_CC.Name = "tb_CC";
            this.tb_CC.Size = new System.Drawing.Size(399, 31);
            this.tb_CC.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_testing);
            this.panel2.Controls.Add(this.cb_autoCC);
            this.panel2.Controls.Add(this.cb_autoSubject);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.tb_MailSubject);
            this.panel2.Controls.Add(this.tb_mailSender);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tb_CC);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(515, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(737, 224);
            this.panel2.TabIndex = 6;
            // 
            // btn_testing
            // 
            this.btn_testing.BackColor = System.Drawing.Color.Turquoise;
            this.btn_testing.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_testing.ForeColor = System.Drawing.Color.White;
            this.btn_testing.Location = new System.Drawing.Point(592, 78);
            this.btn_testing.Name = "btn_testing";
            this.btn_testing.Size = new System.Drawing.Size(122, 59);
            this.btn_testing.TabIndex = 44;
            this.btn_testing.Text = "Test Yap";
            this.btn_testing.UseVisualStyleBackColor = false;
            this.btn_testing.Click += new System.EventHandler(this.btn_testing_Click);
            this.btn_testing.MouseEnter += new System.EventHandler(this.btn_testing_MouseEnter);
            this.btn_testing.MouseLeave += new System.EventHandler(this.btn_testing_MouseLeave);
            // 
            // cb_autoCC
            // 
            this.cb_autoCC.AutoSize = true;
            this.cb_autoCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_autoCC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cb_autoCC.Location = new System.Drawing.Point(502, 167);
            this.cb_autoCC.Name = "cb_autoCC";
            this.cb_autoCC.Size = new System.Drawing.Size(90, 24);
            this.cb_autoCC.TabIndex = 42;
            this.cb_autoCC.Text = "Oto OFF";
            this.cb_autoCC.UseVisualStyleBackColor = true;
            this.cb_autoCC.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // cb_autoSubject
            // 
            this.cb_autoSubject.AutoSize = true;
            this.cb_autoSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_autoSubject.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cb_autoSubject.Location = new System.Drawing.Point(502, 60);
            this.cb_autoSubject.Name = "cb_autoSubject";
            this.cb_autoSubject.Size = new System.Drawing.Size(90, 24);
            this.cb_autoSubject.TabIndex = 40;
            this.cb_autoSubject.Text = "Oto OFF";
            this.cb_autoSubject.UseVisualStyleBackColor = true;
            this.cb_autoSubject.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(607, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 45);
            this.button2.TabIndex = 28;
            this.button2.Text = "Reset All";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(16, 169);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(39, 19);
            this.label29.TabIndex = 27;
            this.label29.Text = "CC:";
            // 
            // tb_MailSubject
            // 
            this.tb_MailSubject.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_MailSubject.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MailSubject.Location = new System.Drawing.Point(92, 56);
            this.tb_MailSubject.Multiline = true;
            this.tb_MailSubject.Name = "tb_MailSubject";
            this.tb_MailSubject.Size = new System.Drawing.Size(400, 31);
            this.tb_MailSubject.TabIndex = 10;
            // 
            // tb_mailSender
            // 
            this.tb_mailSender.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_mailSender.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_mailSender.Location = new System.Drawing.Point(92, 112);
            this.tb_mailSender.Multiline = true;
            this.tb_mailSender.Name = "tb_mailSender";
            this.tb_mailSender.Size = new System.Drawing.Size(400, 31);
            this.tb_mailSender.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "From:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Subject:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbl_arsivlenecekMail);
            this.panel3.Controls.Add(this.tb_LogPanel);
            this.panel3.Controls.Add(this.btn_pause);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.lbl_n_tobeSent);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lbl_n_kalan);
            this.panel3.Controls.Add(this.lbl_n_sent);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.lbl_gecen_dk);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.lbl_kalan_tahmini);
            this.panel3.Controls.Add(this.lbl_yuzde);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.lbl_arsivlenenMail);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Location = new System.Drawing.Point(515, 239);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(737, 366);
            this.panel3.TabIndex = 7;
            // 
            // tb_LogPanel
            // 
            this.tb_LogPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_LogPanel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tb_LogPanel.Location = new System.Drawing.Point(377, 3);
            this.tb_LogPanel.Name = "tb_LogPanel";
            this.tb_LogPanel.ReadOnly = true;
            this.tb_LogPanel.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tb_LogPanel.Size = new System.Drawing.Size(354, 358);
            this.tb_LogPanel.TabIndex = 31;
            this.tb_LogPanel.Text = "İşlem Logları:";
            // 
            // btn_pause
            // 
            this.btn_pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_pause.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pause.ForeColor = System.Drawing.Color.White;
            this.btn_pause.Location = new System.Drawing.Point(268, 6);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(98, 36);
            this.btn_pause.TabIndex = 43;
            this.btn_pause.Text = "||    Pause";
            this.btn_pause.UseVisualStyleBackColor = false;
            // 
            // lbl_n_tobeSent
            // 
            this.lbl_n_tobeSent.AutoSize = true;
            this.lbl_n_tobeSent.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_n_tobeSent.Location = new System.Drawing.Point(265, 103);
            this.lbl_n_tobeSent.Name = "lbl_n_tobeSent";
            this.lbl_n_tobeSent.Size = new System.Drawing.Size(44, 18);
            this.lbl_n_tobeSent.TabIndex = 30;
            this.lbl_n_tobeSent.Text = "3234";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 19);
            this.label3.TabIndex = 29;
            this.label3.Text = "Gönderilecek Toplam Mail";
            // 
            // lbl_n_kalan
            // 
            this.lbl_n_kalan.AutoSize = true;
            this.lbl_n_kalan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_n_kalan.Location = new System.Drawing.Point(265, 172);
            this.lbl_n_kalan.Name = "lbl_n_kalan";
            this.lbl_n_kalan.Size = new System.Drawing.Size(35, 18);
            this.lbl_n_kalan.TabIndex = 24;
            this.lbl_n_kalan.Text = "738";
            // 
            // lbl_n_sent
            // 
            this.lbl_n_sent.AutoSize = true;
            this.lbl_n_sent.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_n_sent.Location = new System.Drawing.Point(265, 137);
            this.lbl_n_sent.Name = "lbl_n_sent";
            this.lbl_n_sent.Size = new System.Drawing.Size(44, 18);
            this.lbl_n_sent.TabIndex = 23;
            this.lbl_n_sent.Text = "3243";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(11, 172);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(143, 19);
            this.label18.TabIndex = 22;
            this.label18.Text = "Kalan Mail Sayısı:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(11, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(183, 19);
            this.label17.TabIndex = 21;
            this.label17.Text = "Gönderilen Mail Sayısı:";
            // 
            // lbl_gecen_dk
            // 
            this.lbl_gecen_dk.AutoSize = true;
            this.lbl_gecen_dk.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_gecen_dk.Location = new System.Drawing.Point(233, 242);
            this.lbl_gecen_dk.Name = "lbl_gecen_dk";
            this.lbl_gecen_dk.Size = new System.Drawing.Size(101, 18);
            this.lbl_gecen_dk.TabIndex = 20;
            this.lbl_gecen_dk.Text = "00:00:00:000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 241);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 19);
            this.label13.TabIndex = 19;
            this.label13.Text = "Geçen Süre";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 206);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(157, 19);
            this.label16.TabIndex = 11;
            this.label16.Text = "Kalan Tahmini Süre";
            // 
            // lbl_kalan_tahmini
            // 
            this.lbl_kalan_tahmini.AutoSize = true;
            this.lbl_kalan_tahmini.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_kalan_tahmini.Location = new System.Drawing.Point(214, 206);
            this.lbl_kalan_tahmini.Name = "lbl_kalan_tahmini";
            this.lbl_kalan_tahmini.Size = new System.Drawing.Size(139, 18);
            this.lbl_kalan_tahmini.TabIndex = 18;
            this.lbl_kalan_tahmini.Text = "5 dakika 35 saniye";
            // 
            // lbl_yuzde
            // 
            this.lbl_yuzde.AutoSize = true;
            this.lbl_yuzde.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_yuzde.Location = new System.Drawing.Point(9, 62);
            this.lbl_yuzde.Name = "lbl_yuzde";
            this.lbl_yuzde.Size = new System.Drawing.Size(40, 18);
            this.lbl_yuzde.TabIndex = 14;
            this.lbl_yuzde.Text = "%69";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(58, 49);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(314, 41);
            this.progressBar1.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(13, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(216, 26);
            this.label11.TabIndex = 14;
            this.label11.Text = "Mail Gönderim Durumu";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Maile Boğ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_CC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lbl_n_kalan;
        private System.Windows.Forms.Label lbl_n_sent;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_gecen_dk;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbl_kalan_tahmini;
        private System.Windows.Forms.Label lbl_yuzde;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_arsivlenenMail;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tb_BrowsedOft;
        private System.Windows.Forms.TextBox tb_BrowsedExcel;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_MailSubject;
        private System.Windows.Forms.TextBox tb_mailSender;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lbl_n_tobeSent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_otoArsiv;
        private System.Windows.Forms.TextBox tb_otoArsivKota;
        private System.Windows.Forms.CheckBox cb_otoArsiv;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_arsivlenecekMail;
        private System.Windows.Forms.Label label14;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cb_autoCC;
        private System.Windows.Forms.CheckBox cb_autoSubject;
        private System.Windows.Forms.RichTextBox tb_LogPanel;
        private System.Windows.Forms.Button btn_testing;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_kaydet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_sleepingTime;
        private System.Windows.Forms.CheckBox cb_manuelArsiv;
        private System.Windows.Forms.Label lbl_manuelArsiv;
        private System.Windows.Forms.TextBox tb_manuelArsivKotasi;
        private System.Windows.Forms.Button btn_reset_settings;
    }
}

