namespace TestParseFiles
{
    partial class FileparsingForm
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
            this.fp.Dispose();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(173, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "Clean && Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Click open file button to clean another file";
            this.label1.Visible = false;
            // 
            // FileparsingForm
            // 
            this.ClientSize = new System.Drawing.Size(744, 447);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FileparsingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeComponent2()
        {
            OpenFileButton=new System.Windows.Forms.Button();
            OpenFileButton.Name = "OpenFileButton";
            OpenFileButton.Size = new System.Drawing.Size(75,23);
            int left = this.Left + 10;
            int top = this.Top + (int)(this.Size.Height * 0.9);
            this.OpenFileButton.Location = new System.Drawing.Point(left,top );
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.Text = "OpenFile";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            OpenFileButton.Visible = true;
            this.Controls.Add(OpenFileButton);
        }
        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}

