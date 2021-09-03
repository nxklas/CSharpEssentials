using CSharpEssentials.Events;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpEssentials.Gui.Controls.Bases
{
    /// <summary>
    /// Represents a <see cref="TextBox"/> with watermark text
    /// </summary>
    [Description("A textbox with watermark")]
    public class WatermarkBox : TextBox
    {
        #region Properties
        /// <summary>
        /// The text of the watermark
        /// </summary>
        /// <returns>The watermark text</returns>
        [Description("The text of the watermark"),Category("Appearance")]
        public string Watermark
        {
            get => _watermark.Text;
            set
            {
                if (_watermark.Text != value)
                {
                    string oldWatermark = _watermark.Text;
                    _watermark.Text = value;
                    WatermarkChanged?.Invoke(this, new PropertyChangedEventArgs<string>(oldWatermark, _watermark.Text));
                }
            }
        }
        #endregion

        #region Fields
        private Label _watermark;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="WatermarkBox"/> class with default watermark ("Search")
        /// </summary>
        public WatermarkBox() : this("Search")
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="WatermarkBox"/> with specific watermark
        /// </summary>
        public WatermarkBox(string watermarkText) : base()
        {
            _watermark = new()
            {
                Text = watermarkText
            };
            _watermark.Location = new Point(Location.X + 3, Location.Y + 1);
            Controls.Add(_watermark);
        }
        #endregion

        #region Event methods
        /// <summary>
        /// Triggers when <see cref="Control.TextChanged"/> occurs
        /// </summary>
        /// <param name="e">The data of the event</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            _watermark.Visible = Text switch
            {
                null or "" => true,
                _ => false,
            };
        }

        /// <summary>
        /// Triggers when <see cref="Control.ForeColorChanged"/> occurs
        /// </summary>
        /// <param name="e">The data of the event</param>
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            _watermark.ForeColor = ForeColor;
        }
        #endregion

        #region Events
        /// <summary>
        /// Occurs when <see cref="Watermark"/> has changed
        /// </summary>
        [Description("Occurs when the watermark text has changed"), Category("PropertyChanged")]
        public event PropertyChangedEventHandler<string> WatermarkChanged;
        #endregion
    }
}
