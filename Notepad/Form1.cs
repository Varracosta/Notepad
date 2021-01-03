using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Notepad : Form
    {
        public string text = null;
        public int count = 0;     //counter for words (white spaces actually)

        public Notepad()
        {
            InitializeComponent();
        }

        //counting the number of words 
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            text = textBox.Text;
            count = text.Length - text.Replace(" ", "").Length + 1;
            totalWords.Text = count.ToString();
        }

        //saving file: summoning File Explorer to browse the desired directory
        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string fileText = System.IO.File.ReadAllText(filename);
                textBox.Text = fileText;
            }
        }
        //opening file by summonin File Explorer to browse the file
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Save file",

                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",

                OverwritePrompt = true
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(fileName, textBox.Text);
            }
        }
    }
}
