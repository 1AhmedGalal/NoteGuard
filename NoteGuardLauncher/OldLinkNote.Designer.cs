namespace NoteGuardLauncher
{
    partial class OldLinkNote
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
            button4 = new Button();
            label2 = new Label();
            button3 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            textBox1 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Location = new Point(304, 228);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 21;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 165);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 18;
            label2.Text = "Website";
            // 
            // button3
            // 
            button3.Location = new Point(404, 228);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 17;
            button3.Text = "Go Back";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(204, 228);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 16;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(204, 161);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(381, 28);
            comboBox1.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(591, 161);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 12;
            button1.Text = "Display";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(591, 198);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(76, 20);
            linkLabel1.TabIndex = 22;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Click Here";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(204, 195);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(381, 27);
            textBox1.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(163, 198);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 25;
            label3.Text = "Link";
            // 
            // OldLinkNote
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(linkLabel1);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Name = "OldLinkNote";
            Text = "OldLinkNote";
            Load += OldLinkNote_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private Label label2;
        private Button button3;
        private Button button2;
        private ComboBox comboBox1;
        private Button button1;
        private LinkLabel linkLabel1;
        private TextBox textBox1;
        private Label label3;
    }
}