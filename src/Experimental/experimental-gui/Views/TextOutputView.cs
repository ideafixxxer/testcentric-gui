// ***********************************************************************
// Copyright (c) 2018 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System.Drawing;
using System.Windows.Forms;

namespace TestCentric.Gui.Views
{
    public partial class TextOutputView : UserControl, ITextOutputView
    {
        public TextOutputView()
        {
            InitializeComponent();

            richTextBox1.ContextMenuStrip = contextMenuStrip1;
        }

        public bool WordWrap
        {
            get { return richTextBox1.WordWrap; }
            set { richTextBox1.WordWrap = value; }
        }

        public void Clear()
        {
            InvokeIfRequired(() =>
            {
                richTextBox1.Clear();
            });
        }

        public void Write(string text)
        {
            InvokeIfRequired(() =>
            {
                richTextBox1.AppendText(text);
            });
        }

        public void Write(string text, Color color)
        {
            InvokeIfRequired(() =>
            {
                richTextBox1.SelectionStart = richTextBox1.TextLength;
                richTextBox1.SelectionLength = 0;
                richTextBox1.SelectionColor = color;

                richTextBox1.AppendText(text);

                richTextBox1.SelectionColor = ForeColor;
            });
        }

        #region Context Menu Actions

        // NOTE: The TextOutputView teakes care of its own context menu since
        // the effects of all the actions are entirely within the view.

        private void copyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void selectAllToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            wordWrapToolStripMenuItem.Checked = richTextBox1.WordWrap = !richTextBox1.WordWrap;
        }

        private void increaseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Font = new Font(Font.FontFamily, Font.SizeInPoints * 1.2f, Font.Style);
        }

        private void decreaseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Font = new Font(Font.FontFamily, Font.SizeInPoints / 1.2f, Font.Style);
        }

        private void resetToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Font = new Font(FontFamily.GenericMonospace, 8.0f);
        }

        private void contextMenuStrip1_Opened(object sender, System.EventArgs e)
        {
            wordWrapToolStripMenuItem.Checked = richTextBox1.WordWrap;
            copyToolStripMenuItem.Enabled = richTextBox1.SelectedText != "";
            selectAllToolStripMenuItem.Enabled = richTextBox1.TextLength > 0;
        }

        #endregion

        #region Helper Methods

        private void InvokeIfRequired(MethodInvoker _delegate)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(_delegate);
            else
                _delegate();
        }

        #endregion
    }
}
