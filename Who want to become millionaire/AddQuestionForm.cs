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
    public partial class AddQuestionForm : Form
    {
        public List<Question> Question { get; set; }
        public AddQuestionForm()
        {
            InitializeComponent();
            Question = null;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(question.Text == "" || AnswerA.Text == "" || AnswerB.Text == "" || AnswerC.Text == "" || AnswerD.Text == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
            }
            else
            {
                Question = new List<Question>();
                Question.Add(
                    new Question
                    {
                        question = this.question.Text,
                        AnswerA = this.AnswerA.Text,
                        AnswerB = this.AnswerB.Text,
                        AnswerC = this.AnswerC.Text,
                        AnswerD = this.AnswerD.Text
                    }
                );;
                MessageBox.Show("Вопрос успешно добавлен");
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Question = null;
            this.Close();
        }
    }
}
