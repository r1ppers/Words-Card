using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace EnglishCards
{
    /// <summary>
    /// Логика взаимодействия для WordDescription.xaml
    /// </summary>
    public partial class WordDescription : Window
    {
        Word wordList;
        int index;
        public WordDescription(Word wordList, int index = -1)
        {
            InitializeComponent();
            this.wordList = wordList;
            this.index = index;
            CheckCreate();
        }
        private void CheckCreate()
        {
            if (index == -1)
                return;
            wordTextBox.Text = wordList.word;
            FillTextBoxes(wordList.tranlations, translationsWrapPanel);
            FillTextBoxes(wordList.examples, exampleseWrapPanel);
            wordList.tranlations.Clear();
            wordList.examples.Clear();
        }

        private void FillTextBoxes(List<string> list, WrapPanel wrapPanel)
        {
            for(int i = 0; i < list.Count; i++)
            {
                CreateTextBox(wrapPanel, list[i]);
            }
        }

        private void addTranslationButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTextBox(translationsWrapPanel);
        }

        private void CreateTextBox(WrapPanel wrapPanel, string text = "")
        {
            TextBox textBox = new TextBox();
            textBox.MinWidth = 30;
            textBox.Text = text;
            wrapPanel.Children.Add(textBox);
        }

        private void addExamplesButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTextBox(exampleseWrapPanel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(wordTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("You did not fill in \"Word\" field","Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SaveWord();
            this.Close();
        }
        private void SaveWord()
        {
            wordList.word = wordTextBox.Text;
            FillLTranslationsList(wordList.tranlations, translationsWrapPanel);
            FillLTranslationsList(wordList.examples, exampleseWrapPanel);
        }
        private void FillLTranslationsList(List<string> list, WrapPanel wrapPanel )
        {
            for(int i = 0; i < wrapPanel.Children.Count; i++)
            {
                TextBox text = (TextBox)wrapPanel.Children[i];
                list.Add(text.Text);
            }
        }

    }
}
