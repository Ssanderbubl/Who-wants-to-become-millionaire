using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Who_want_to_become_millionaire
{
    public partial class EditQuestionForm : Form
    {
        List<Question> questions;
        Question Question { get; set; }
        public EditQuestionForm(List<Question> questions)
        {
            InitializeComponent();
            this.questions = questions;
            numericUpDown1.Maximum = questions.Count;
            Question = this.questions[(int)numericUpDown1.Value - 1];

            question.Text = Question.question;
            AnswerA.Text = Question.AnswerA;
            AnswerB.Text = Question.AnswerB;
            AnswerC.Text = Question.AnswerC;
            AnswerD.Text = Question.AnswerD;
        }

        private void question_TextChanged(object sender, EventArgs e)
        {
            TextBox question = sender as TextBox;
            Question.question = question.Text;
        }

        private void AnswerA_TextChanged(object sender, EventArgs e)
        {
            TextBox Answer = sender as TextBox;
            Question.AnswerA = Answer.Text;
        }

        private void AnswerB_TextChanged(object sender, EventArgs e)
        {
            TextBox Answer = sender as TextBox;
            Question.AnswerB = Answer.Text;
        }

        private void AnswerC_TextChanged(object sender, EventArgs e)
        {
            TextBox Answer = sender as TextBox;
            Question.AnswerC = Answer.Text;
        }

        private void AnswerD_TextChanged(object sender, EventArgs e)
        {
            TextBox Answer = sender as TextBox;
            Question.AnswerD = Answer.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Question = this.questions[(int)numericUpDown1.Value - 1];
            question.Text = Question.question;
            AnswerA.Text = Question.AnswerA;
            AnswerB.Text = Question.AnswerB;
            AnswerC.Text = Question.AnswerC;
            AnswerD.Text = Question.AnswerD;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (Question.question == "" || Question.AnswerA == "" || Question.AnswerB == "" || Question.AnswerC == "" || Question.AnswerD == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
            }
            else
            {
                this.questions[(int)numericUpDown1.Value - 1] = Question;
                MessageBox.Show("Вопрос успешно изменен");
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
