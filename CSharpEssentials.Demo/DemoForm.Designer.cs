
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
            this.themeableTextBox1 = new CSharpEssentials.Gui.Controls.ThemeableTextBox();
            this.themeableWatermarkBox1 = new CSharpEssentials.Gui.Controls.ThemeableWatermarkBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // themeableTextBox1
            // 
            this.themeableTextBox1.Location = new System.Drawing.Point(564, 415);
            this.themeableTextBox1.Name = "themeableTextBox1";
            this.themeableTextBox1.Size = new System.Drawing.Size(224, 23);
            this.themeableTextBox1.TabIndex = 1;
            // 
            // themeableWatermarkBox1
            // 
            this.themeableWatermarkBox1.Location = new System.Drawing.Point(12, 96);
            this.themeableWatermarkBox1.Name = "themeableWatermarkBox1";
            this.themeableWatermarkBox1.Size = new System.Drawing.Size(224, 23);
            this.themeableWatermarkBox1.TabIndex = 2;
            this.themeableWatermarkBox1.Watermark = "Search";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.themeableWatermarkBox1);
            this.Controls.Add(this.themeableTextBox1);
            this.Name = "DemoForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.Controls.ThemeableTextBox themeableTextBox1;
        private Gui.Controls.ThemeableWatermarkBox themeableWatermarkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

