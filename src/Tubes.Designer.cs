using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tubes3_let_me_seedik
{
    partial class Tubes
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
            buttonCitra = new System.Windows.Forms.Button();
            buttonKMP = new System.Windows.Forms.Button();
            buttonBM = new System.Windows.Forms.Button();
            buttonSearch = new System.Windows.Forms.Button();
            pictureBoxbiodata = new PictureBox();
            labelWaktu = new Label();
            pictureBoxOutput = new PictureBox();
            labelJudul = new Label();
            labelNilaiWaktu = new Label();
            labelPersen = new Label();
            pictureBoxInput = new PictureBox();
            labelNilaiKemiripan = new Label();
            labelFormat = new Label();
            labelData = new Label();
            buttonAboutUs = new System.Windows.Forms.Button();
            backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            Bonus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxbiodata).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOutput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxInput).BeginInit();
            SuspendLayout();
            // 
            // buttonCitra
            // 
            buttonCitra.Anchor = AnchorStyles.None;
            buttonCitra.Location = new Point(37, 466);
            buttonCitra.Margin = new Padding(3, 4, 3, 4);
            buttonCitra.Name = "buttonCitra";
            buttonCitra.Size = new Size(160, 55);
            buttonCitra.TabIndex = 0;
            buttonCitra.Text = "Pilih Citra";
            buttonCitra.UseVisualStyleBackColor = true;
            buttonCitra.Click += buttonCitra_Click;
            // 
            // buttonKMP
            // 
            buttonKMP.Anchor = AnchorStyles.None;
            buttonKMP.Enabled = false;
            buttonKMP.Location = new Point(224, 466);
            buttonKMP.Margin = new Padding(3, 4, 3, 4);
            buttonKMP.Name = "buttonKMP";
            buttonKMP.Size = new Size(78, 55);
            buttonKMP.TabIndex = 3;
            buttonKMP.Text = "KMP";
            buttonKMP.UseVisualStyleBackColor = true;
            buttonKMP.Click += buttonKMP_Click;
            // 
            // buttonBM
            // 
            buttonBM.Anchor = AnchorStyles.None;
            buttonBM.Location = new Point(301, 466);
            buttonBM.Margin = new Padding(0, 4, 3, 4);
            buttonBM.Name = "buttonBM";
            buttonBM.Size = new Size(78, 55);
            buttonBM.TabIndex = 1;
            buttonBM.Text = "BM";
            buttonBM.UseVisualStyleBackColor = true;
            buttonBM.Click += buttonBM_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Anchor = AnchorStyles.None;
            buttonSearch.Enabled = false;
            buttonSearch.Location = new Point(408, 466);
            buttonSearch.Margin = new Padding(3, 4, 3, 4);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(160, 55);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // pictureBoxbiodata
            // 
            pictureBoxbiodata.Anchor = AnchorStyles.None;
            pictureBoxbiodata.Image = src.Properties.Resources.Screenshot_2024_05_31_140236;
            pictureBoxbiodata.InitialImage = src.Properties.Resources.loading_icon_wait_vector_260nw_1722568561;
            pictureBoxbiodata.Location = new Point(532, 106);
            pictureBoxbiodata.Margin = new Padding(3, 4, 3, 4);
            pictureBoxbiodata.Name = "pictureBoxbiodata";
            pictureBoxbiodata.Size = new Size(343, 268);
            pictureBoxbiodata.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxbiodata.TabIndex = 8;
            pictureBoxbiodata.TabStop = false;
            pictureBoxbiodata.WaitOnLoad = true;
            pictureBoxbiodata.Click += pictureBoxbiodata_Click;
            // 
            // labelWaktu
            // 
            labelWaktu.Anchor = AnchorStyles.None;
            labelWaktu.AutoSize = true;
            labelWaktu.Location = new Point(592, 471);
            labelWaktu.Name = "labelWaktu";
            labelWaktu.Size = new Size(141, 25);
            labelWaktu.TabIndex = 9;
            labelWaktu.Text = "Waktu Pencarian";
            // 
            // pictureBoxOutput
            // 
            pictureBoxOutput.Anchor = AnchorStyles.None;
            pictureBoxOutput.Image = src.Properties.Resources.Screenshot_2024_05_31_140225;
            pictureBoxOutput.InitialImage = src.Properties.Resources.loading_icon_wait_vector_260nw_1722568561;
            pictureBoxOutput.Location = new Point(282, 95);
            pictureBoxOutput.Margin = new Padding(3, 4, 3, 4);
            pictureBoxOutput.Name = "pictureBoxOutput";
            pictureBoxOutput.Size = new Size(210, 299);
            pictureBoxOutput.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOutput.TabIndex = 7;
            pictureBoxOutput.TabStop = false;
            pictureBoxOutput.Click += pictureBoxOutput_Click;
            // 
            // labelJudul
            // 
            labelJudul.Anchor = AnchorStyles.None;
            labelJudul.AutoSize = true;
            labelJudul.Location = new Point(232, 32);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(455, 25);
            labelJudul.TabIndex = 11;
            labelJudul.Text = "Aplikasi C# Tugas Besar 3 Strategi Algoritma 2023/2024";
            // 
            // labelNilaiWaktu
            // 
            labelNilaiWaktu.Anchor = AnchorStyles.None;
            labelNilaiWaktu.AutoSize = true;
            labelNilaiWaktu.Location = new Point(781, 471);
            labelNilaiWaktu.Name = "labelNilaiWaktu";
            labelNilaiWaktu.Size = new Size(74, 25);
            labelNilaiWaktu.TabIndex = 12;
            labelNilaiWaktu.Text = ": xxx ms";
            // 
            // labelPersen
            // 
            labelPersen.Anchor = AnchorStyles.None;
            labelPersen.AutoSize = true;
            labelPersen.Location = new Point(592, 496);
            labelPersen.Name = "labelPersen";
            labelPersen.Size = new Size(179, 25);
            labelPersen.TabIndex = 10;
            labelPersen.Text = "Persentase Kemiripan\r\n";
            // 
            // pictureBoxInput
            // 
            pictureBoxInput.Anchor = AnchorStyles.None;
            pictureBoxInput.Image = src.Properties.Resources.Screenshot_2024_05_31_140208;
            pictureBoxInput.Location = new Point(37, 95);
            pictureBoxInput.Margin = new Padding(3, 4, 3, 4);
            pictureBoxInput.Name = "pictureBoxInput";
            pictureBoxInput.Size = new Size(210, 299);
            pictureBoxInput.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxInput.TabIndex = 6;
            pictureBoxInput.TabStop = false;
            pictureBoxInput.Click += pictureBoxInput_Click;
            // 
            // labelNilaiKemiripan
            // 
            labelNilaiKemiripan.Anchor = AnchorStyles.None;
            labelNilaiKemiripan.AutoSize = true;
            labelNilaiKemiripan.Location = new Point(781, 496);
            labelNilaiKemiripan.Name = "labelNilaiKemiripan";
            labelNilaiKemiripan.Size = new Size(57, 25);
            labelNilaiKemiripan.TabIndex = 13;
            labelNilaiKemiripan.Text = ": xx %";
            // 
            // labelFormat
            // 
            labelFormat.Anchor = AnchorStyles.None;
            labelFormat.AutoSize = true;
            labelFormat.Location = new Point(537, 119);
            labelFormat.Name = "labelFormat";
            labelFormat.Size = new Size(153, 275);
            labelFormat.TabIndex = 14;
            labelFormat.Text = "NIK\r\nNama\r\nTempat Lahir\r\nTanggal Lahir\r\nJenis Kelamin\r\nGolongan Darah\r\nAlamat\r\nAgama\r\nStatus Perkawinan\r\nPekerjaan\r\nKewarganegaraan";
            labelFormat.Visible = false;
            // 
            // labelData
            // 
            labelData.AutoSize = true;
            labelData.Location = new Point(690, 119);
            labelData.Name = "labelData";
            labelData.Size = new Size(59, 25);
            labelData.TabIndex = 15;
            labelData.Text = "label1";
            labelData.Visible = false;
            // 
            // buttonAboutUs
            // 
            buttonAboutUs.Location = new Point(0, -1);
            buttonAboutUs.Margin = new Padding(3, 4, 3, 4);
            buttonAboutUs.Name = "buttonAboutUs";
            buttonAboutUs.Size = new Size(143, 59);
            buttonAboutUs.TabIndex = 16;
            buttonAboutUs.Text = "About us";
            buttonAboutUs.UseVisualStyleBackColor = true;
            // 
            // backgroundWorkerSearch
            // 
            backgroundWorkerSearch.DoWork += backgroundWorkerSearch_DoWork;
            backgroundWorkerSearch.RunWorkerCompleted += backgroundWorkerSearch_RunWorkerCompleted;
            // 
            // Bonus
            // 
            Bonus.Location = new Point(743, 32);
            Bonus.Name = "Bonus";
            Bonus.Size = new Size(112, 36);
            Bonus.TabIndex = 17;
            Bonus.Text = "Enkripsi";
            Bonus.UseVisualStyleBackColor = true;
            Bonus.Click += Bonus_Click;
            // 
            // Tubes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(889, 562);
            Controls.Add(Bonus);
            Controls.Add(buttonAboutUs);
            Controls.Add(labelData);
            Controls.Add(labelFormat);
            Controls.Add(buttonKMP);
            Controls.Add(pictureBoxInput);
            Controls.Add(buttonCitra);
            Controls.Add(labelNilaiKemiripan);
            Controls.Add(buttonBM);
            Controls.Add(pictureBoxbiodata);
            Controls.Add(labelNilaiWaktu);
            Controls.Add(labelPersen);
            Controls.Add(pictureBoxOutput);
            Controls.Add(labelJudul);
            Controls.Add(labelWaktu);
            Controls.Add(buttonSearch);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Tubes";
            Text = "dot";
            Load += Tubes_Load;
            Resize += Tubes_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBoxbiodata).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOutput).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BackgroundWorkerSearch_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button buttonCitra;
        private System.Windows.Forms.Button buttonKMP;
        private System.Windows.Forms.Button buttonBM;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.PictureBox pictureBoxbiodata;
        private System.Windows.Forms.Label labelWaktu;
        private System.Windows.Forms.PictureBox pictureBoxOutput;
        private System.Windows.Forms.Label labelJudul;
        private System.Windows.Forms.Label labelNilaiWaktu;
        private System.Windows.Forms.Label labelPersen;
        private System.Windows.Forms.PictureBox pictureBoxInput;
        private System.Windows.Forms.Label labelNilaiKemiripan;
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Button buttonAboutUs;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.Windows.Forms.Button Bonus;
    }
}


