using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace EnglishCards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Words wordsList = new Words();
        public MainWindow()
        {
            InitializeComponent();
            DeserializeCreateButton();
        }

        private void DeserializeCreateButton()
        {
            wordsList = DeserializeXML();
            foreach(Word item in wordsList.words)
            {
                CreateButton(item);
            }
        }
        private void addWordButton_Click(object sender, RoutedEventArgs e)
        {
            wordsList.words.Add(new Word());
            WordDescription wordDescription = new WordDescription(wordsList.words[wordsList.words.Count - 1]);
            wordDescription.ShowDialog();
            if (CheckWord(wordsList.words[wordsList.words.Count - 1].word))
            {
                wordsList.words.RemoveAt(wordsList.words.Count - 1);
                return;
            }

            CreateButton(wordsList.words[wordsList.words.Count - 1]);
        }
        private void CreateButton(Word word)
        {
            Button button = new Button();
            button.Name = $"{word.word}Button";
            button.Content = word.word;
            button.Click += (s, e) =>
            {
                int index = wordsList.words.FindIndex(obj => obj.word == button.Name.Substring(0, button.Name.Length - 6));
                WordDescription wordDescription = new WordDescription(wordsList.words[index], index);
                wordDescription.ShowDialog();
            };
            wordsPanel.Children.Add(button);
        }
        private void SerializeXML(Words words)
        {
            string path = "C:\\Users\\User\\Desktop\\Words\\Words.xml";
            XmlSerializer xml = new XmlSerializer(typeof(Words));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, words);
            }
        }

        private Words DeserializeXML()
        {
            string path = "C:\\Users\\User\\Desktop\\Words\\Words.xml";
            XmlSerializer xml = new XmlSerializer(typeof(Words));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (Words)xml.Deserialize(fs);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SerializeXML(wordsList);
        }
        private bool CheckWord(string word)
        {
            if(word == null)
            {
                return true;
            }
            return false;
        }
    }
}
