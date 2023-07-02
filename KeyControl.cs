using System;
using System.Drawing;
using System.Windows.Forms;

namespace zo
{
    public partial class KeyControl : UserControl
    {
        public int Value { get; private set; }
        public char Char { get; private set; }
        public bool IsControlChar { get; private set; }
        public bool IsSpecialChar { get; private set; }

        public KeyControl(int value)
        {
            InitializeComponent();

            if (value < 0 || value > 127)
            {
                throw new ArgumentOutOfRangeException("Only for Char 0..127");
            }

            this.Value = value;

            if (value.In(8, 27, 127))
            {
                this.IsControlChar = true;
            }
            else if (value.In(9, 10, 13))
            {
                this.IsSpecialChar = true;
            }
            
            this.Char = Convert.ToChar(value);
        }

        private void KeyControl_Load(object sender, EventArgs e)
        {

            string hex = string.Format("{0:x}", this.Value).PadLeft(2, '0');
            string OnesZeros = "";

            foreach (var ch in hex)
            {
                OnesZeros += ToBool(ch);
            }

            lblBool.Text = OnesZeros.Substring(1);
            lblChar.Text = GetText();
        }

        private string GetText()
        {
            if (!IsSpecialChar && !IsControlChar)
            {
                return  this.Char.ToString();
            }

            var result = string.Empty;

            lblChar.Font = new Font("MS UI Gothic", 15.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            switch (Value)
            {
                case 8: //Backspace, works on HP terminals/computer
                    return "BS";
                case 9: //Horizontal tab, move to next tab stop
                    return "Tab";
                case 10: //Line Feed
                    return "LF";
                case 13: //Carriage Return
                    return "CR";
                case 27: //Escape, next character is not echoed
                    return "ESC";
                case 127: //Delete
                    return "DEL";
                default:
                    return string.Empty;
            }
        }

        private string ToBool(char ch)
        {
            switch (ch)
            {
                case '0': return "0000";
                case '1': return "0001";
                case '2': return "0010";
                case '3': return "0011";
                case '4': return "0100";
                case '5': return "0101";
                case '6': return "0110";
                case '7': return "0111";
                case '8': return "1000";
                case '9': return "1001";
                case 'a': return "1010";
                case 'b': return "1011";
                case 'c': return "1100";
                case 'd': return "1101";
                case 'e': return "1110";
                case 'f': return "1111";
                default: throw new ArgumentOutOfRangeException("Hex you fool! Hex!");
            }
        }

        public override string ToString()
        {
            return this.lblBool.Text + " " + this.lblChar.ToString();
        }
    }
}
