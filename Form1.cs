using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.IO;

namespace zo
{
    public partial class Form1 : Form
    {
        List<KeyControl> keys = new List<KeyControl>();
        List<KeyControl> candidates = new List<KeyControl>();
        Color[] colors = new Color[] { Color.Blue, Color.Gray };
        bool IsCommandMode = true;
        int index = 0;
        TextBox currentText = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toggleCommandMode();
            
            for (int i = 0; i <= 127; i++)
            {
                var k = new KeyControl(i);
                this.keyPanel.Controls.Add(k);
                keys.Add(k);
            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                    DealWith(e.KeyChar);
                    break;
                default:
                    index = 0;
                    Reset();
                    Sort();
                    currentText.Text = "";
                    this.Text = "ERROR!! BAD INPUT!! BUFFER DISCARDED.";
                    lblInput.Text = "BAD INPUT!";
                    lblInput.BackColor = System.Drawing.Color.Red;
                    lblInput.ForeColor = System.Drawing.Color.White;
                    SystemSounds.Beep.Play();
                    break;
            }
        }

        private void DealWith(char p)
        {

            if (index == 0)
            {
                Reset();
                lblInput.BackColor = SystemColors.Control;
                lblInput.ForeColor = SystemColors.ControlText;
            }

            this.Text += p;
            lblInput.Text = Say(index, lblInput.Text, p);
            int start, finish;
            start = p == '0' ? (candidates.Count / 2) : 0;

            lbl0.Enabled = p == '0';
            lbl1.Enabled = p != '0';
            lbl0.ForeColor = p == '0' ? colors[0] : colors[1];
            lbl1.ForeColor = p != '0' ? colors[0] : colors[1];

            finish = start + (candidates.Count / 2);

            //Disable non-matching controls
            for (int i = start; i <= finish - 1; i++)
            {
                candidates[i].Enabled = false;
            }

            //Remove half the controls from further consideration
            candidates.RemoveRange(start, (candidates.Count / 2));

            if (index == 6 || candidates.Count == 0)
            {

                var pressedKey = candidates[0];
                Reset();

                if (pressedKey.IsControlChar)
                {
                    ExecCommand(pressedKey.Value);
                }
                else
                {
                    if (!IsCommandMode)
                    {
                        textBox1.Text += pressedKey.Char;
                    }
                    else
                    {
                        if (pressedKey.Value == 10)
                        {
                            //Execute the command that has been entered
                            Exec(txtCommand.Text);
                        }
                        else
                        {
                            txtCommand.Text += pressedKey.Char;
                        }
                    }
                }
                
            }
            index++;
            index = index % 7;
            Sort();
        }

        private void Exec(string command)
        {
            try
            {
                string fileName;
                if (command.StartsWith("o"))
                {
                    
                    fileName = command.Substring(1);
                    if (!File.Exists(fileName))
                    {
                        this.Text = "FILE NOT FOUND '" + fileName + "'";
                        SystemSounds.Beep.Play();
                        return;
                    }
                    textBox1.Text = File.ReadAllText(fileName);
                    txtCommand.Text = "";
                    toggleCommandMode();
                    this.Text = "OPENING '" + fileName + "'";

                    return;
                }
                if (command.StartsWith("s"))
                {
                    fileName = command.Substring(1);
                    File.WriteAllText(fileName, textBox1.Text);
                    txtCommand.Text = "";
                    toggleCommandMode();
                    this.Text = "SAVING '" + fileName + "'";

                    return;
                }
                if (command.StartsWith("q"))
                {
                    SystemSounds.Beep.Play();
                    txtCommand.Text = "";
                    toggleCommandMode();
                    this.Text = "QUITTING...";

                    this.Close();
                }
            }
            catch (Exception)
            {
                SystemSounds.Beep.Play();
                this.Text = "ERROR IN COMMAND!";

            }
        }
        
        private void ExecCommand(int p)
        {
            
            switch (p)
            {
                case 8: //Backspace, works on HP terminals/computer
                    //Do Backspace, works on HP terminals/computer
                    if (currentText.Text == string.Empty)
                    {
                        SystemSounds.Beep.Play();
                        return;
                    }
                    currentText.Text = currentText.Text.Substring(0, currentText.Text.Length - 1);
                    break;
                case 27: //Escape, next character is not echoed
                    toggleCommandMode();
                    break;
                case 127: //Del
                    //Delete not implemented;
                    SystemSounds.Beep.Play();
                    break;
            }
        }

        private void toggleCommandMode()
        {
            IsCommandMode = !IsCommandMode;
            txtCommand.Visible = IsCommandMode;
            currentText = IsCommandMode ? txtCommand : textBox1;
            this.Text = IsCommandMode ? "** COMMAND MODE **" : "AWAITING USER INPUT...";
        }

        private string Say(int index, string pattern, char p)
        {
            return pattern.Substring(0, pattern.IndexOf('_')) + p + pattern.Substring(pattern.IndexOf('_') + 1);
        }


        private void Sort()
        {
            candidates.Sort((key1, key2) => { return key1.lblBool.Text[index].CompareTo(key2.lblBool.Text[index]); });
        }

        private void Reset()
        {
            candidates = new List<KeyControl>(keys);
            candidates.ForEach(k => k.Enabled = true);
            this.Text = IsCommandMode ? "** COMMAND MODE **" : "AWAITING USER INPUT...";
            lblInput.Text = "_ _ _ _ _ _ _";
        }
    }
}
