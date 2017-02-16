using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Read config file
            var path = "../../config.xml";
            FileStream reader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Xml.XmlDocument configFile = new System.Xml.XmlDocument();
            configFile.Load(reader);

            // Set form config
            System.Xml.XmlNodeList nodeList = configFile.GetElementsByTagName("Form");

            var formSettings = nodeList[0].ChildNodes;
            
            this.Name = formSettings[0].InnerText;
            this.Width = Convert.ToInt32(formSettings[1].InnerText);
            this.Height = Convert.ToInt32(formSettings[2].InnerText);

            var formColorList = formSettings[3].InnerText.Split(',');
            var red = Convert.ToInt32(formColorList[0]);
            var green = Convert.ToInt32(formColorList[1]);
            var blue = Convert.ToInt32(formColorList[2]);

            this.BackColor = Color.FromArgb(red, green, blue);

            // Set button config
            var button = new Button();

            System.Xml.XmlNodeList nodeButtonList = configFile.GetElementsByTagName("button");
            var buttonSettings = nodeButtonList[0].ChildNodes;

            button.Top = Convert.ToInt32(buttonSettings[0].InnerText);
            button.Left = Convert.ToInt32(buttonSettings[1].InnerText);
            button.Name = buttonSettings[2].InnerText;
            button.Width = Convert.ToInt32(buttonSettings[3].InnerText);
            button.Height = Convert.ToInt32(buttonSettings[4].InnerText);

            var buttonColorList = buttonSettings[5].InnerText.Split(',');
            var buttonRed = Convert.ToInt32(buttonColorList[0]);
            var buttonGreen = Convert.ToInt32(buttonColorList[1]);
            var buttonBlue = Convert.ToInt32(buttonColorList[2]);

            button.BackColor = Color.FromArgb(buttonRed, buttonGreen, buttonBlue);

            this.Controls.Add(button);
        }
    }
}
