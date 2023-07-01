
namespace CSharpEssentials.Demo
{
    partial class DemoForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CSharpEssentials.Gui.ThemeController themeController1 = new CSharpEssentials.Gui.ThemeController();
            CSharpEssentials.Gui.DarkTheme darkTheme1 = new CSharpEssentials.Gui.DarkTheme();
            this.themeableTextBox1 = new CSharpEssentials.Gui.ThemableTextBox();
            this.themeableWatermarkBox1 = new CSharpEssentials.Gui.ThemableWatermarkBox();
            this.comboBox1 = new CSharpEssentials.Gui.ThemableComboBox();
            this.button1 = new CSharpEssentials.Gui.ThemableButton();
            this.themableButton1 = new CSharpEssentials.Gui.ThemableButton();
            this.listBox1 = new CSharpEssentials.Gui.ThemableListBox();
            this.SuspendLayout();
            // 
            // themeableTextBox1
            // 
            this.themeableTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.themeableTextBox1.ForeColor = System.Drawing.Color.White;
            this.themeableTextBox1.Location = new System.Drawing.Point(564, 415);
            this.themeableTextBox1.Name = "themeableTextBox1";
            this.themeableTextBox1.Size = new System.Drawing.Size(224, 23);
            this.themeableTextBox1.TabIndex = 1;
            themeController1.Theme = darkTheme1;
            this.themeableTextBox1.ThemeController = themeController1;
            // 
            // themeableWatermarkBox1
            // 
            this.themeableWatermarkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.themeableWatermarkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.themeableWatermarkBox1.ForeColor = System.Drawing.Color.White;
            this.themeableWatermarkBox1.Location = new System.Drawing.Point(12, 96);
            this.themeableWatermarkBox1.Name = "themeableWatermarkBox1";
            this.themeableWatermarkBox1.Size = new System.Drawing.Size(224, 23);
            this.themeableWatermarkBox1.TabIndex = 2;
            this.themeableWatermarkBox1.ThemeController = themeController1;
            this.themeableWatermarkBox1.Watermark = "Search";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.ThemeController = themeController1;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(530, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 57);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.ThemeController = themeController1;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // themableButton1
            // 
            this.themableButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.themableButton1.ForeColor = System.Drawing.Color.White;
            this.themableButton1.Location = new System.Drawing.Point(530, 118);
            this.themableButton1.Name = "themableButton1";
            this.themableButton1.Size = new System.Drawing.Size(111, 69);
            this.themableButton1.TabIndex = 5;
            this.themableButton1.Text = "themableButton1";
            this.themableButton1.ThemeController = themeController1;
            this.themableButton1.UseVisualStyleBackColor = false;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(212, 211);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 94);
            this.listBox1.TabIndex = 6;
            this.listBox1.ThemeController = themeController1;
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.themableButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.themeableWatermarkBox1);
            this.Controls.Add(this.themeableTextBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "DemoForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.ThemableTextBox themeableTextBox1;
        private Gui.ThemableWatermarkBox themeableWatermarkBox1;
        private Gui.ThemableComboBox comboBox1;
        private CSharpEssentials.Gui.ThemableButton button1;
        private Gui.ThemableButton themableButton1;
        private CSharpEssentials.Gui.ThemableListBox listBox1;
    }
}

