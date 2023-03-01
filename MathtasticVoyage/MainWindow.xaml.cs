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

namespace MathtasticVoyage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Queue<string> queue = Data.GetDataQueue();
        MathProblem prob;
        List<string> CorrectList = new List<string>();
        List<string> IncorrectList = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
            
            if (!queue.IsEmpty)
            {
                GetProblem();

                TextBoxMathProblems.Text = prob.ProbInfix;

                prob.Answer = MathProblem.PostFixEvaluator(MathProblem.infixToPostfix(prob.ProbInfix));

                LabelCurrentProblem.Content = prob.ProbInfix;

            }
            ListBoxIncorrect.ItemsSource = IncorrectList;
            ListBoxCorrectAns.ItemsSource = CorrectList;
            
        }


        private void GetProblem()
        {
            TextBoxUserAnswer.Clear();

            prob = new MathProblem();
            prob.ProbInfix = queue.Dequeue();

            TextBoxMathProblems.Text = prob.ProbInfix;

            prob.Answer = MathProblem.PostFixEvaluator(MathProblem.infixToPostfix(prob.ProbInfix));

            LabelCurrentProblem.Content = prob.ProbInfix;
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer();

            if (!queue.IsEmpty)
            {
                GetProblem();
            }
            else
            {
                prob = null;
                TextBoxMathProblems.Text = null;
                TextBoxUserAnswer.Clear();
                LabelCurrentProblem.Content = null;
            }

            ListBoxIncorrect.Items.Refresh();
            ListBoxCorrectAns.Items.Refresh();
        }

        private void CheckAnswer()
        {
            string userAnswer = TextBoxUserAnswer.Text;
            bool Parced = double.TryParse(userAnswer, out double userAnsNum);
            if (Parced)
            {
                prob.UserAns = userAnsNum;
            }
            else { }

            string infixed = prob.ProbInfix + " = " + prob.UserAns;

            if (prob.IsCorrect)
            {
                CorrectList.Add(infixed);

            }
            else
            {
                IncorrectList.Add(infixed);
            }
        }
    }
}
