using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace WinAppHastable
{
    public partial class Form1 : Form
    {

        string filePath = string.Empty;
        string dictionaryFile = string.Empty;
        string targetFile = string.Empty;
        string missedWordsFile = string.Empty;
        public Form1()
        {
            dictionaryFile = ConfigurationManager.AppSettings["dictionaryFile"];
            targetFile = ConfigurationManager.AppSettings["targetFile"];
            missedWordsFile = ConfigurationManager.AppSettings["missedWordsFile"];
            InitializeComponent();
        }

        private void closeAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hashTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hastable object declaration
            Hashtable englishHashDictionary = new Hashtable();
            // Read the file and add words to hashtable
            DateTime startDate = DateTime.Now;
            foreach (string line in System.IO.File.ReadLines(dictionaryFile))
            {
                if (!englishHashDictionary.ContainsKey(line))
                {
                    englishHashDictionary.Add(line, line);
                }
            }
            TimeSpan timeDiff = DateTime.Now - startDate;
            string result = string.Format("{0} add to Hashtable in {1} ms", dictionaryFile, timeDiff.TotalMilliseconds);
            Console.WriteLine(result);
            toolStripStatusLabel1.Text = result;
            //Read target file to spell-check and put not fouded words in a list
            IList<string> missedWords = new List<string>();
            foreach (string line in System.IO.File.ReadLines(targetFile))
            {
                string[] words = line.Replace(",", "").Replace("!", "").Split(' ');
                foreach (string word in words)
                {
                    if (!englishHashDictionary.ContainsKey(word))
                    {
                        if (!missedWords.Contains(word))
                        {
                            missedWords.Add(word);
                        }
                    }
                }
            }
            if (missedWords.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, missedWords));
                System.IO.File.WriteAllLines(missedWordsFile, missedWords);
            }
            Console.WriteLine("File processed!!");

        }

        private void dictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> englishHashDictionary = new Dictionary<string, string>();
            DateTime startDate = DateTime.Now;
            foreach (string line in System.IO.File.ReadLines(dictionaryFile))
            {
                if (!englishHashDictionary.ContainsKey(line))
                {
                    englishHashDictionary.Add(line, line);
                }
            }
            TimeSpan timeDiff = DateTime.Now - startDate;
            string result = string.Format("{0} add to Hashtable in {1} ms", dictionaryFile, timeDiff.TotalMilliseconds);
            Console.WriteLine(result);
            toolStripStatusLabel2.Text = result;
            //Read target file to spell-check and put not fouded words in a list
            IList<string> missedWords = new List<string>();
            foreach (string line in System.IO.File.ReadLines(targetFile))
            {
                string[] words = line.Replace(",", "").Replace("!", "").Split(' ');
                foreach (string word in words)
                {
                    if (!englishHashDictionary.ContainsKey(word))
                    {
                        if (!missedWords.Contains(word))
                        {
                            missedWords.Add(word);
                        }
                    }
                }
            }
            if (missedWords.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, missedWords));
                System.IO.File.WriteAllLines(missedWordsFile, missedWords);
            }
            Console.WriteLine("File processed!!");
        }

        private void sortedDirctonaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SortedDictionary<string, string> englishHashDictionary = new SortedDictionary<string, string>();

            DateTime startDate = DateTime.Now;
            foreach (string line in System.IO.File.ReadLines(dictionaryFile))
            {
                if (!englishHashDictionary.ContainsKey(line))
                {
                    englishHashDictionary.Add(line, line);
                }
            }
            TimeSpan timeDiff = DateTime.Now - startDate;
            string result = string.Format("{0} add to Hashtable in {1} ms", dictionaryFile, timeDiff.TotalMilliseconds);
            Console.WriteLine(result);
            toolStripStatusLabel3.Text = result;
            //Read target file to spell-check and put not fouded words in a list
            IList<string> missedWords = new List<string>();
            foreach (string line in System.IO.File.ReadLines(targetFile))
            {
                string[] words = line.Replace(",", "").Replace("!", "").Split(' ');
                foreach (string word in words)
                {
                    if (!englishHashDictionary.ContainsKey(word))
                    {
                        if (!missedWords.Contains(word))
                        {
                            missedWords.Add(word);
                        }
                    }
                }
            }
            if (missedWords.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, missedWords));
                System.IO.File.WriteAllLines(missedWordsFile, missedWords);
            }
            Console.WriteLine("File processed!!");
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    tA1.LoadFile(filePath, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hashtable englishHashDictionary = new Hashtable();
            foreach (string line in System.IO.File.ReadLines(dictionaryFile))
            {
                if (!englishHashDictionary.ContainsKey(line))
                {
                    englishHashDictionary.Add(line, line);
                }
            }
            // Compara cada palabra de la canción con el diccionario
            foreach (string line in tA1.Lines)
            {
                string[] palabras = line.Replace("'", "").Replace(",", "").Replace("!", "").Split(' ');
                foreach (string palabra in palabras)
                {
                    if (!englishHashDictionary.ContainsKey(palabra))
                        tA2.SelectionColor = Color.Red;
                    else
                        tA2.SelectionColor = Color.Black;
                    tA2.AppendText(palabra + "\n");
                }
            }

        }
    }
}
