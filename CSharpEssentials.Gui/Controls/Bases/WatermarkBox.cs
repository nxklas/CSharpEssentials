using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpEssentials.Gui
{
    /// <summary>
    /// Represents a <see cref="TextBox"/> with watermark text
    /// </summary>
    [Description("A textbox with watermark")]
    public class WatermarkBox : TextBox
    {
<<<<<<< Updated upstream:CSharpEssentials/Gui/Controls/Bases/WatermarkBox.cs
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

=======
>>>>>>> Stashed changes:CSharpEssentials.Gui/Controls/Bases/WatermarkBox.cs
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
                Text = watermarkText,
                Location = new Point(Location.X + 3, Location.Y + 1)
            };
            _watermark.MouseDown += (sender, args) => _watermark_OnMouseDown(args);
            Controls.Add(_watermark);
        }
        #endregion

        #region Properties
        /// <summary>
        /// The text of the watermark
        /// </summary>
        [Description("The text of the watermark"), Category("Appearance")]
        public string Watermark
        {
            get => _watermark.Text;
            set
            {
                if (_watermark.Text != value)
                {
                    var oldWatermark = _watermark.Text;
                    _watermark.Text = value;
                    WatermarkChanged?.Invoke(this, new PropertyChangedEventArgs<string>(oldWatermark, _watermark.Text));
                }
            }
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

        /// <summary>
        /// Triggers when <see cref="Control.MouseDown"/> on the watermark label occurs
        /// </summary>
        /// <param name="args">The data of the event</param>
        protected virtual void _watermark_OnMouseDown(MouseEventArgs args)
        {
            if (args.Button == MouseButtons.Left)
                Focus();
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
