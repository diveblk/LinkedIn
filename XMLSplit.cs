using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace XMLSplit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string log = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string xmlDoc = textBox1.Text;

            XDocument doc = XDocument.Load(xmlDoc);
            var newDocs = doc.Descendants("Branch").Select(d => new XDocument(new XElement("Tree", d)));

            log += "[" + Environment.NewLine;

            foreach (var newDoc in newDocs)
            {
                string ItemNo = newDoc.Root.Element("Branch").FirstNode.ToString().Replace("<Key>", "").Replace("</Key>", "");
                string region = newDoc.Root.Element("Branch").FirstNode.NextNode.ToString().Replace("<region>", "").Replace("</region>", "");
                string subregion = newDoc.Root.Element("Branch").FirstNode.NextNode.NextNode.ToString().Replace("<subregion>", "").Replace("</subregion>", "");
                string value = newDoc.Root.Element("Branch").FirstNode.NextNode.NextNode.NextNode.ToString().Replace("<value>", "").Replace("</value>", "");

                log += "{" + Environment.NewLine;
                log += "\"key\": \"" + ItemNo + "\"," + Environment.NewLine;
                log += "\"region\": \"" + region + "\"," + Environment.NewLine;
                log += "\"subregion\": \"" + subregion + "\"," + Environment.NewLine;

                try
                {
                    log += "\"value\": " + string.Format("{0:G29}", decimal.Parse(value)).Substring(0, value.IndexOf('.', 0)) + Environment.NewLine;

                }
                catch
                {

                }
                log += "}," + Environment.NewLine;
            }
            log = log.Substring(0, log.Length - 3) + Environment.NewLine;
            log += "]" + Environment.NewLine;
            File.AppendAllText(textBox2.Text + @"\tree.json", log);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
