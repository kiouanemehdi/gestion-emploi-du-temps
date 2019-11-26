namespace gestion_emploi_du_temps
{
    partial class LoginAcceuill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginAcceuill));
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.eseignantLogin1 = new gestion_emploi_du_temps.EseignantLogin();
            this.chefLogincs2 = new gestion_emploi_du_temps.ChefLogincs();
            this.chefLogincs1 = new gestion_emploi_du_temps.ChefLogincs();
            this.adminLogin1 = new gestion_emploi_du_temps.AdminLogin();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Admin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 450);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(0, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "Enseignant";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "Chef";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 59);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(727, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // eseignantLogin1
            // 
            this.eseignantLogin1.Location = new System.Drawing.Point(350, 137);
            this.eseignantLogin1.Name = "eseignantLogin1";
            this.eseignantLogin1.Size = new System.Drawing.Size(408, 285);
            this.eseignantLogin1.TabIndex = 6;
            this.eseignantLogin1.Load += new System.EventHandler(this.eseignantLogin1_Load);
            // 
            // chefLogincs2
            // 
            this.chefLogincs2.Location = new System.Drawing.Point(350, 137);
            this.chefLogincs2.Name = "chefLogincs2";
            this.chefLogincs2.Size = new System.Drawing.Size(408, 285);
            this.chefLogincs2.TabIndex = 5;
            this.chefLogincs2.Load += new System.EventHandler(this.chefLogincs2_Load);
            // 
            // chefLogincs1
            // 
            this.chefLogincs1.Location = new System.Drawing.Point(406, 165);
            this.chefLogincs1.Name = "chefLogincs1";
            this.chefLogincs1.Size = new System.Drawing.Size(8, 13);
            this.chefLogincs1.TabIndex = 4;
            // 
            // adminLogin1
            // 
            this.adminLogin1.BackColor = System.Drawing.SystemColors.Control;
            this.adminLogin1.Location = new System.Drawing.Point(336, 137);
            this.adminLogin1.Name = "adminLogin1";
            this.adminLogin1.Size = new System.Drawing.Size(408, 285);
            this.adminLogin1.TabIndex = 7;
            this.adminLogin1.Load += new System.EventHandler(this.adminLogin1_Load_1);
            // 
            // LoginAcceuill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.adminLogin1);
            this.Controls.Add(this.eseignantLogin1);
            this.Controls.Add(this.chefLogincs2);
            this.Controls.Add(this.chefLogincs1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginAcceuill";
            this.Text = "LoginAcceuill";
            this.Load += new System.EventHandler(this.LoginAcceuill_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ChefLogincs chefLogincs1;
        private ChefLogincs chefLogincs2;
        private EseignantLogin eseignantLogin1;
        private AdminLogin adminLogin1;
    }
}