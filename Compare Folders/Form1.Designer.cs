namespace Compare_Folders
{
	partial class Form1
	{
		///<summary>
		///Required designer variable.
		///</summary>
		private System.ComponentModel.IContainer components = null;
		///<summary>
		///Clean up any resources being used.
		///</summary>
		///<param name = "disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components  !=  null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		#region Windows Form Designer generated code
		///<summary>
		///Required method for Designer support-do not modify
		///the contents of this method with the code editor.
		///</summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnopen1 = new System.Windows.Forms.Button();
            this.btnopen2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileTypes = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lblselectedcompare = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(22, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(938, 225);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(22, 305);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(938, 225);
            this.listBox2.TabIndex = 0;
            // 
            // btnopen1
            // 
            this.btnopen1.Location = new System.Drawing.Point(885, 15);
            this.btnopen1.Name = "btnopen1";
            this.btnopen1.Size = new System.Drawing.Size(75, 23);
            this.btnopen1.TabIndex = 1;
            this.btnopen1.Text = "Open";
            this.btnopen1.UseVisualStyleBackColor = true;
            this.btnopen1.Click += new System.EventHandler(this.btnopen1_Click);
            // 
            // btnopen2
            // 
            this.btnopen2.Location = new System.Drawing.Point(885, 276);
            this.btnopen2.Name = "btnopen2";
            this.btnopen2.Size = new System.Drawing.Size(75, 23);
            this.btnopen2.TabIndex = 1;
            this.btnopen2.Text = "Open";
            this.btnopen2.UseVisualStyleBackColor = true;
            this.btnopen2.Click += new System.EventHandler(this.btnopen2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folder:";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(985, 44);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(528, 485);
            this.listBox3.TabIndex = 0;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            this.listBox3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox3_MouseDoubleClick);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(888, 556);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 25);
            this.btnCompare.TabIndex = 3;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(982, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Differents:";
            // 
            // txtFileTypes
            // 
            this.txtFileTypes.Location = new System.Drawing.Point(89, 556);
            this.txtFileTypes.Name = "txtFileTypes";
            this.txtFileTypes.Size = new System.Drawing.Size(381, 20);
            this.txtFileTypes.TabIndex = 5;
            this.txtFileTypes.Text = "*.c,*.h,*.cs";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 559);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "File types:";
            // 
            // lblselectedcompare
            // 
            this.lblselectedcompare.AutoSize = true;
            this.lblselectedcompare.Location = new System.Drawing.Point(985, 536);
            this.lblselectedcompare.Name = "lblselectedcompare";
            this.lblselectedcompare.Size = new System.Drawing.Size(32, 13);
            this.lblselectedcompare.TabIndex = 8;
            this.lblselectedcompare.Text = "Path:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(880, 536);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Standardize";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(751, 536);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(123, 17);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Compare Keil vs IAR";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(613, 536);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(132, 17);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "Remove Precedences";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(529, 536);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(78, 17);
            this.checkBox4.TabIndex = 11;
            this.checkBox4.Text = "Beautifying";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1532, 611);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblselectedcompare);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFileTypes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnopen2);
            this.Controls.Add(this.btnopen1);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder Comparator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Button btnopen1;
		private System.Windows.Forms.Button btnopen2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBox3;
		private System.Windows.Forms.Button btnCompare;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFileTypes;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblselectedcompare;
		private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
    }
}



