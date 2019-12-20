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
    public partial class DeleteQuestionForm : Form
    {
        List<Question> questions;
        public DeleteQuestionForm(List<Question> questions)
        {
            InitializeComponent();
            this.questions = questions;
            numericUpDown1.Maximum = this.questions.Count;
            textBox1.Text = this.questions[(int)numericUpDown1.Value - 1].question;
            textBox1.Enabled = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = questions[(int)numericUpDown1.Value - 1].question;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(questions.Count > 15)
            {
                questions.RemoveAt((int)numericUpDown1.Value - 1);
                numericUpDown1.Maximum = questions.Count();
            }
            else
            {
                MessageBox.Show("Вопросов должно быть минимум 15", "Вы не можете удалить вопрос", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
