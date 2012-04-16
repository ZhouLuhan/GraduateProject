using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ChessPresenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public enum AIValidationError { None, ServerName, URL, Link };

    public partial class MainWindow : Window
    {

        private Dictionary<string, AI_Information> whites, blacks, eithers;

        public MainWindow()
        {
            InitializeComponent();
            AIReload();
        }

        private AI_Information AI_Construct(ComboBox comboBox)
        {
            if (comboBox.SelectedItem != null)
            {
                return eithers[((ComboBoxItem)comboBox.SelectedItem).Content as string];
            }
            return null;
        }

        AIValidationError AIValidation(AI_Information info)
        {
            Dictionary<string, AI_Information>.ValueCollection tot = eithers.Values;
            foreach (AI_Information either in tot)
            {
                if (info.ServerName.Equals(either.ServerName)) return AIValidationError.ServerName;
                if (info.URL.Equals(either.URL)) return AIValidationError.URL;
            }
            if (!info.GetLinked()) return AIValidationError.Link;
            return AIValidationError.None;
        }

        void AIInsert(AI_Information info)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("AIConfig.xml");
            XmlNode root = doc.SelectSingleNode("Root");
            XmlElement ep = doc.CreateElement("EndPoint");
            XmlElement ele;
            ele = doc.CreateElement("ServerName");
            ele.InnerText = info.ServerName;
            ep.AppendChild(ele);
            ele = doc.CreateElement("URL");
            ele.InnerText = info.URL;
            ep.AppendChild(ele);
            ele = doc.CreateElement("Type");
            ele.InnerText = info.Type.ToString();
            ep.AppendChild(ele);
            root.AppendChild(ep);
            doc.Save("AIConfig.xml");
        }

        private void AIReload()
        {
            eithers = new Dictionary<string, AI_Information>();
            whites = new Dictionary<string, AI_Information>();
            blacks = new Dictionary<string, AI_Information>();
            XmlDocument doc = new XmlDocument();
            doc.Load("AIConfig.xml");
            XmlNodeList eps = doc.SelectSingleNode("Root").ChildNodes;
            foreach (XmlNode ep in eps)
            {
                AI_Information info = new AI_Information();
                XmlNode ele;
                ele = ep.SelectSingleNode("ServerName");
                info.ServerName = ele.InnerText;
                ele = ep.SelectSingleNode("URL");
                info.URL = ele.InnerText;
                ele = ep.SelectSingleNode("Type");
                for (int i = 0; i < AI_Information.AITypeStr.Length; ++i)
                    if (AI_Information.AITypeStr[i] == ele.InnerText[0]) info.Type = (AIType)i;
                if (AIValidation(info) == AIValidationError.None)
                {
                    eithers.Add(info.ServerName, info);
                    if (info.Type != AIType.Black) whites.Add(info.ServerName, info);
                    if (info.Type != AIType.White) blacks.Add(info.ServerName, info);
                }
            }
            WhiteComboBox.Items.Clear();
            foreach (string info in whites.Keys)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = info;
                WhiteComboBox.Items.Insert(WhiteComboBox.Items.Count, item);
            }
            BlackComboBox.Items.Clear();
            foreach (string info in blacks.Keys)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = info;
                BlackComboBox.Items.Insert(BlackComboBox.Items.Count, item);
            }
        }

        private void NewAI_Click(object sender, RoutedEventArgs e)
        {
            AI_Information info = new AI_Information();
            NewAIWindow window = new NewAIWindow(info);
            window.ShowDialog();
            AIValidationError err = AIValidationError.None;
            if ((bool)window.DialogResult && (err = AIValidation(info)) == AIValidationError.None)
            {
                AIInsert(info);
                AIReload();
            } else switch (err) {
                case AIValidationError.ServerName:
                    MessageBox.Show("The server name is already used!");
                    break;
                case AIValidationError.URL:
                    MessageBox.Show("The URL is already used!");
                    break;
                case AIValidationError.Link:
                    MessageBox.Show("Cannot contact with the service, please re-check the URL");
                    break;
            }
        }

        private void DeleteAI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GameStart_Click(object sender, RoutedEventArgs e)
        {
            AI_Information ai_a = AI_Construct(WhiteComboBox);
            AI_Information ai_b = AI_Construct(BlackComboBox);
            ChessGame chessGameWindow = new ChessGame(this, ai_a, ai_b);
            chessGameWindow.Show(); this.Hide();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AI_Information ai_a = AI_Construct(WhiteComboBox);
            AI_Information ai_b = AI_Construct(BlackComboBox);
            if (ai_a == null || ai_b == null)
            {
                MessageBox.Show("This function need both gamers are AI, plz choose the AI type for them");
                return;
            }
            PractiseWindow practise = new PractiseWindow(this, ai_a, ai_b);
            practise.Show(); this.Hide();
        }
    }
}
