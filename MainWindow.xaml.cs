/*
 *Josh Degazio
 *June 6, 2018
 *Math Tutor
 *Program generates a math question with a random operator, the user then makes an attempt to answer the question.
*/
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U4_Tutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ImageBrush img_Background = new ImageBrush(new BitmapImage(new Uri("Background.png", UriKind.Relative)));
        Random rnumber = new Random();
        int number_1;
        int number_2;
        int rnumber_Sign;

        string[] MathSign = new string[4];
        int answer;
        string question;

        public MainWindow()
        {
            MathSign[0] = "+";
            MathSign[1] = "-";
            MathSign[2] = "*";
            MathSign[3] = "/";

            InitializeComponent();
            Grid.Background = img_Background;
            Grid.Background.Opacity = 0.4;

            GenerateQuestion();

        }

        private void GenerateQuestion()
        {
            number_1 = rnumber.Next(1, 11);
            number_2 = rnumber.Next(1, 11);
            rnumber_Sign = rnumber.Next(0, 4);
            question = number_1.ToString() + " " + MathSign[rnumber_Sign] + " " + number_2.ToString();
            Question.Text = question;
        }

        public void Click_Calc(object Sender, RoutedEventArgs e)
        {
            if (MathSign[rnumber_Sign] == "+")
            {
                answer = number_1 + number_2;
            }
            else if (MathSign[rnumber_Sign] == "-")
            {
                answer = number_1 - number_2;
            }
            else if (MathSign[rnumber_Sign] == "*")
            {
                answer = number_1 * number_2;
            }
            else if (MathSign[rnumber_Sign] == "/")
            {
                answer = number_1 / number_2;
            }

            if (txt_Inpt.Text == answer.ToString())
            {
                MessageBox.Show("Correct! A new answer will now appear.");
                GenerateQuestion();
            }
            else if (txt_Inpt.Text != answer.ToString())
            {
                MessageBox.Show("Incorrect.");
            }
        }
    }
}
