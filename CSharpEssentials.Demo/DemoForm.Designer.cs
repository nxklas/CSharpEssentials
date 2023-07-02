
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
            themeableTextBox1 = new Gui.ThemableTextBox();
            themeableWatermarkBox1 = new Gui.ThemableWatermarkBox();
            comboBox1 = new Gui.ThemableComboBox();
            listBox1 = new Gui.ThemableListBox();
            themableButton2 = new Gui.ThemableButton();
            SuspendLayout();
            // 
            // themeableTextBox1
            // 
            themeableTextBox1.BackColor = System.Drawing.Color.FromArgb(54, 54, 54);
            themeableTextBox1.ForeColor = System.Drawing.Color.White;
            themeableTextBox1.Location = new System.Drawing.Point(564, 415);
            themeableTextBox1.Name = "themeableTextBox1";
            themeableTextBox1.Size = new System.Drawing.Size(224, 23);
            themeableTextBox1.TabIndex = 1;
            // 
            // themeableWatermarkBox1
            // 
            themeableWatermarkBox1.BackColor = System.Drawing.Color.FromArgb(54, 54, 54);
            themeableWatermarkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            themeableWatermarkBox1.ForeColor = System.Drawing.Color.White;
            themeableWatermarkBox1.Location = new System.Drawing.Point(12, 96);
            themeableWatermarkBox1.Name = "themeableWatermarkBox1";
            themeableWatermarkBox1.Size = new System.Drawing.Size(224, 23);
            themeableWatermarkBox1.TabIndex = 2;
            themeableWatermarkBox1.Watermark = "Search";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = System.Drawing.Color.FromArgb(54, 54, 54);
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.ForeColor = System.Drawing.Color.White;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(121, 23);
            comboBox1.TabIndex = 3;
            comboBox1.TextChanged += comboBox1_TextChanged;
            // 
            // listBox1
            // 
            listBox1.BackColor = System.Drawing.Color.FromArgb(54, 54, 54);
            listBox1.ForeColor = System.Drawing.Color.White;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new System.Drawing.Point(212, 211);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(120, 94);
            listBox1.TabIndex = 6;
            // 
            // themableButton2
            // 
            themableButton2.Location = new System.Drawing.Point(118, 369);
            themableButton2.Name = "themableButton2";
            themableButton2.Size = new System.Drawing.Size(75, 23);
            themableButton2.TabIndex = 7;
            themableButton2.Text = "themableButton2";
            themableButton2.UseVisualStyleBackColor = true;
            // 
            // DemoForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(themableButton2);
            Controls.Add(listBox1);
            Controls.Add(comboBox1);
            Controls.Add(themeableWatermarkBox1);
            Controls.Add(themeableTextBox1);
            ForeColor = System.Drawing.SystemColors.ControlText;
            Name = "DemoForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Gui.ThemableTextBox themeableTextBox1;
        private Gui.ThemableWatermarkBox themeableWatermarkBox1;
        private Gui.ThemableComboBox comboBox1;
        private Gui.ThemableListBox listBox1;
        private Gui.ThemableButton themableButton2;
    }
}

