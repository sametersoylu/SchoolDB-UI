using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class NTextBox : UserControl
    {
        //Fields 
        private Color borderColor = Color.MediumSlateBlue; 
        private int borderWidth = 2;
        private bool underlinedStyle = false;
        private HorizontalAlignment align = HorizontalAlignment.Left; 
        private string _text = string.Empty;
        public NTextBox()
        {
            
            InitializeComponent();
        }

        public Color BorderColor { get => borderColor; set  { borderColor = value; this.Invalidate(); } }
        public int BorderWidth { get => borderWidth; set { borderWidth = value; this.Invalidate(); } }
        public bool UnderlinedStyle { get => underlinedStyle; set { underlinedStyle = value; this.Invalidate(); } }
        public HorizontalAlignment TextAlignment { get => align; set {  align = value; textBox1.TextAlign = align; this.Invalidate(); } }
        public string TextBoxText { get => textBox1.Text; set { textBox1.Text = value; this.Invalidate(); } }
        public bool SystemPasswordChar { get => textBox1.UseSystemPasswordChar; set { textBox1.UseSystemPasswordChar = value; this.Invalidate(); } }
        public string PlaceHolder { get => textBox1.PlaceholderText; set { textBox1.PlaceholderText = value; this.Invalidate(); } }
        public bool ReadOnly { get => textBox1.ReadOnly; set { textBox1.ReadOnly = value; this.Invalidate(); } }
        public TextBox TBoxUserControls { get => textBox1; set { textBox1 = value; this.Invalidate(); } }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            

            using (Pen penborder = new Pen(borderColor, borderWidth))
            {
                penborder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset; 
                if(underlinedStyle) { graph.DrawLine(penborder, 0,this.Height - 1, this.Width, this.Height - 1);}
                else { graph.DrawRectangle(penborder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);}
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(DesignMode)
            {
                UpdateControlHeight();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight(); 
        }

        private void UpdateControlHeight() 
        {
            if(textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true; 
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false; 

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;

            }
        }
    }
}
