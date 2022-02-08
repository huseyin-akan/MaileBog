using MeyileBogh.Helpers.Abstract;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeyileBogh.Helpers
{
    public class TextBoxLogger : ILogger
    {
        private RichTextBox _textBox;
        public TextBoxLogger(RichTextBox textbox)
        {
            _textBox = textbox;
        }

        public void Log(string logText, bool isSuccess = true)
        {           
            int textLength = _textBox.Text.Length;      
            var textToAppend = Environment.NewLine + DateTime.Now.ToString("HH:mm:ss") + " --> " + logText;
            _textBox.AppendText(textToAppend);
            _textBox.Select(textLength, textToAppend.Length);

            if (isSuccess)
            {
                _textBox.SelectionFont = new Font(_textBox.Font, FontStyle.Bold);
                _textBox.SelectionColor = Color.Green;
            }
            else
            {                
                _textBox.SelectionColor = Color.Red;
                _textBox.SelectionFont = new Font(_textBox.Font, FontStyle.Bold);
            }
            _textBox.ScrollToCaret();
        }

        public void LogMailResult(string logText)
        {
            int textLength = _textBox.Text.Length;
            var textToAppend = Environment.NewLine + DateTime.Now.ToString("HH:mm:ss") + " --> " + logText;
            _textBox.AppendText(textToAppend);
            _textBox.Select(textLength, textToAppend.Length);

            _textBox.SelectionFont = new Font(_textBox.Font, FontStyle.Bold);
            _textBox.SelectionColor = Color.Blue;

            _textBox.ScrollToCaret();
        }
    }
}
