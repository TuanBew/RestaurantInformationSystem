namespace RestaurantSystem
{
    partial class Employee_LeftControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee_LeftControl));
            this.add_button = new System.Windows.Forms.Button();
            this.remove_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // add_button
            // 
            this.add_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_button.Location = new System.Drawing.Point(83, 224);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(181, 46);
            this.add_button.TabIndex = 0;
            this.add_button.Text = "ADD";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // remove_button
            // 
            this.remove_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove_button.Location = new System.Drawing.Point(83, 362);
            this.remove_button.Name = "remove_button";
            this.remove_button.Size = new System.Drawing.Size(181, 46);
            this.remove_button.TabIndex = 1;
            this.remove_button.Text = "REMOVE";
            this.remove_button.UseVisualStyleBackColor = true;
            this.remove_button.Click += new System.EventHandler(this.remove_button_Click);
            // 
            // edit_button
            // 
            this.edit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_button.Location = new System.Drawing.Point(83, 497);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(181, 47);
            this.edit_button.TabIndex = 2;
            this.edit_button.Text = "EDIT";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Employee_LeftControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.remove_button);
            this.Controls.Add(this.add_button);
            this.Name = "Employee_LeftControl";
            this.Size = new System.Drawing.Size(340, 630);
            this.Load += new System.EventHandler(this.Employee_LeftControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button remove_button;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
