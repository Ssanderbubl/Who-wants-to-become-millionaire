using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Who_want_to_become_millionaire
{
    public partial class Form1 : Form
    {
        List<Question> questions;
        int currentQuestion;
        string CorrectAnswer;
        List<int> usedQuestion;
        bool isButton50_50 = false;
        bool isStopped = false;
        bool isCalledFriend = false;
        bool isAudienceHelp = false;
        List<Label> labels;
        bool isMute = false;
        SoundPlayer player;
        public Form1()
        {
            InitializeComponent();
            usedQuestion = new List<int>();
            GetQuestions("questions.xml");
        }

        private void GetQuestions(string path)
        {
            var stream = new FileStream(path, FileMode.Open);
            var serializer = new XmlSerializer(typeof(List<Question>));
            questions = (List<Question>)serializer.Deserialize(stream);
            stream.Close();
            currentQuestion = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Type type = this.GetType();
                
                this.Height = 633;
                this.Width = 809;
                CreateListOfAward();
                if(!isMute)
                {
                    player = new SoundPlayer(@"sound\begin.wav");
                    player.Play();
                }
                ChangeAward();
                SetQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateListOfAward()
        {
            panel1.Location = new Point(587, 73);
            panel1.Size = new Size(206, 525);

            int x = 0;
            int y = panel1.Height - 45;
            labels = new List<Label>();
            for (int i = 0; i < 15; i++)
            {
                labels.Add(new Label());
            }
            int award = 0;  
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Size = new Size(73, 35);
                if(i < 3)
                {
                    award += 100;
                    labels[i].Text = award.ToString();
                }
                else if(i == 3)
                {
                    award += 200;
                    labels[i].Text = award.ToString();
                }
                else if(i == 11)
                {
                    award *= 2;
                    award -= 3000;
                    labels[i].Text = award.ToString();
                }
                else
                {
                    award *= 2;
                    labels[i].Text = award.ToString();
                }
                labels[i].Location = new Point(x, y);
                labels[i].Font = new Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                labels[i].ForeColor = Color.Yellow;
                labels[i].BackColor = Color.Black;
                labels[i].Visible = true;

                panel1.Controls.Add(labels[i]);
                //this.Controls.Add(labels[i]);
                y -= 34;
            }
        }
        private void SetQuestion()
        {
            Random random = new Random();
            int index = random.Next(0, questions.Count);
            while(usedQuestion.Contains(index))
            {
                index = random.Next(0, questions.Count);
            }
            usedQuestion.Add(index);

            CorrectAnswer = questions[index].AnswerA;
            QuestionLabel.Text = questions[index].question;

            string[] q = new string[] { 
                questions[index].AnswerA,
                questions[index].AnswerB,
                questions[index].AnswerC,
                questions[index].AnswerD 
            };
            List<int> usedAnswer = new List<int>();

            for (int i = 0; i < q.Length;)
            {
                index = random.Next(0, q.Length - 1);
                while (usedAnswer.Contains(index))
                {
                    index = random.Next(0, q.Length);
                }
                if(i == 0)
                {
                    AnswerA.Text = "A: " + q[index];
                }
                else if (i == 1)
                {
                    AnswerB.Text = "B: " + q[index];
                }
                else if (i == 2)
                {
                    AnswerC.Text = "C: " + q[index];
                }
                else if (i == 3)
                {
                    AnswerD.Text = "D: " + q[index];
                }
                i++;
                usedAnswer.Add(index);
               
            }

            if(currentQuestion < questions.Count)
            {
                currentQuestion++;
            }
            else
            {
                currentQuestion = 0;
            }
        }
        private void ChangeAward()
        {
            labels[currentQuestion].BackColor = Color.Orange;
            if(currentQuestion > 0)
            {
                labels[currentQuestion - 1].BackColor = Color.Black;
            }
            else
            {
                labels[14].BackColor = Color.Black;
            }
        }
        private void Answers_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(isButton50_50)
            {
                Button[] buttons = { AnswerA, AnswerB, AnswerC, AnswerD };
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Visible = true;
                }
            }
            if(isCalledFriend)
            {
                FriendImage.Visible = false;
                FriendAnswerLabel.Visible = false;
            }
            if(isAudienceHelp)
            {
                AudienceHelpBox.Visible = false;
            }
            if (button.Text.Contains(CorrectAnswer))
            {
                if(!isMute)
                {
                    player = new SoundPlayer(@"sound\true.wav");
                    player.Play();
                }
                if(currentQuestion == 15)
                {
                    if (!isMute)
                    {
                        player = new SoundPlayer(@"sound\winner.wav");
                        player.Play();
                    }
                    MessageBox.Show($"Победа, ты выиграл {labels[currentQuestion - 1].Text}");
                    currentQuestion = 0;
                    ChangeAward();
                    usedQuestion.Clear();
                    SetQuestion();
                    return; 
                }
                CorrectAnswerPicture.Visible = true;
                Correct.Visible = true;
                ChangeAward();
                SetQuestion();
            }
            else
            {
                if (!isMute)
                {
                    player = new SoundPlayer(@"sound\false.wav");
                    player.Play();
                }
                MessageBox.Show("Ты проиграл");
                labels[currentQuestion - 1].BackColor = Color.Black;
                currentQuestion = 0;
                ChangeAward();
                usedQuestion.Clear();
                SetQuestion();
            }
        }

        private void Answers_MouseLeave(object sender, EventArgs e)
        {
            if(CorrectAnswerPicture.Visible)
            {
                CorrectAnswerPicture.Visible = false;
                Correct.Visible = false;
            }
        }
        
        private void newGameButton_Click(object sender, EventArgs e)
        {
            labels[currentQuestion - 1].BackColor = Color.Black;
            currentQuestion = 0;
            usedQuestion.Clear();
            ChangeAward();
            if(isButton50_50)
            {
                isButton50_50 = false;
                Button[] buttons = { AnswerA, AnswerB, AnswerC, AnswerD };
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Visible = true;
                }
                button50_50.Image = new Bitmap(@"Image\1.jpg"); ;
            }
            if(isCalledFriend)
            {
                isCalledFriend = false;
                FriendImage.Visible = false;
                FriendAnswerLabel.Visible = false;
                callFriendButton.Image = new Bitmap(@"Image\2.jpg"); ;
            }
            if(isAudienceHelp)
            {
                AudienceHelpBox.Visible = false;
                isAudienceHelp = false;
                audienceHelpButton.Image = new Bitmap(@"Image\3.jpg"); ;
            }
            if (!isMute)
            {
                player = new SoundPlayer(@"sound\summa.wav");
                player.Play();
            }
            SetQuestion();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stopGameButton_Click(object sender, EventArgs e)
        {
            if(isStopped)
            {
                isStopped = false;
                button50_50.Enabled = true;
                callFriendButton.Enabled = true;
                audienceHelpButton.Enabled = true;
                QuestionLabel.Enabled = true;
                AnswerA.Enabled = true;
                AnswerB.Enabled = true;
                AnswerC.Enabled = true;
                AnswerD.Enabled = true;
            }
            else
            {
                isStopped = true;
                button50_50.Enabled = false;
                callFriendButton.Enabled = false;
                audienceHelpButton.Enabled = false;
                QuestionLabel.Enabled = false;
                AnswerA.Enabled = false;
                AnswerB.Enabled = false;
                AnswerC.Enabled = false;
                AnswerD.Enabled = false;
            }
        }

        private void button50_50_Click(object sender, EventArgs e)
        {
            if(!isButton50_50)
            {
                Button[] buttons = { AnswerA, AnswerB, AnswerC, AnswerD };
                Random random = new Random();
                int secondVisibleButton = random.Next(0, buttons.Length);
                while (buttons[secondVisibleButton].Text.Contains(CorrectAnswer))
                {
                    secondVisibleButton = random.Next(0, buttons.Length);
                }
                for (int i = 0; i < buttons.Length; i++)
                {
                    if(buttons[i].Text.Contains(CorrectAnswer))
                    {
                        buttons[i].Visible = true;
                    }
                    else if(i == secondVisibleButton)
                    {
                        buttons[i].Visible = true;
                    }
                    else
                    {
                        buttons[i].Visible = false;
                    }
                }
                isButton50_50 = true;
                if (!isMute)
                {
                    player = new SoundPlayer(@"sound\gong.wav");
                    player.Play();
                }
                button50_50.Image = new Bitmap(@"Image\4.jpg");
            }
        }

        private void audienceHelpButton_Click(object sender, EventArgs e)
        {
            if(!isAudienceHelp)
            {
                Random random = new Random();
                int[] panelSize = new int[4];
                int maxSize = 100;
                int currentSize = 0;
                int indexCorrectAnswer = 0;
                Button[] buttons = new Button[] { AnswerA, AnswerB, AnswerC, AnswerD};
                Panel[] panels = new Panel[] { A_Panel, B_Panel, C_Panel, D_Panel };

                for (int i = 0; i < buttons.Length; i++)
                {
                    if(buttons[i].Text.Contains(CorrectAnswer))
                    {
                        indexCorrectAnswer = i;
                    }
                }
                panelSize[indexCorrectAnswer] = random.Next(60, 75);
                currentSize += panelSize[indexCorrectAnswer];
                for (int i = 0; i < panelSize.Length; i++)
                {
                    if(i != indexCorrectAnswer)
                    {
                        panelSize[i] = random.Next(0, maxSize - currentSize);
                        currentSize += panelSize[i];
                    }
                }
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].Size = new Size(panelSize[i], 19);
                }
                AudienceHelpBox.Visible = true;
                audienceHelpButton.Image = new Bitmap(@"Image\6.jpg"); ;
                isAudienceHelp = true;
                if (!isMute)
                {
                    player = new SoundPlayer(@"sound\zal.wav");
                    player.Play();
                }
            }
        }

        private void callFriendButton_Click(object sender, EventArgs e)
        {
            if(!isCalledFriend)
            {
                FriendImage.Visible = true;
                FriendAnswerLabel.Visible = true;
                FriendAnswerLabel.Text = "Я думаю это " + CorrectAnswer;
                callFriendButton.Image = new Bitmap(@"Image\5.jpg"); ;
                isCalledFriend = true;

                if (!isMute)
                {
                    player = new SoundPlayer(@"sound\zvonok.wav");
                    player.Play();
                }
            }
        }

        private void addNewQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddQuestionForm form2 = new AddQuestionForm();
            form2.ShowDialog();
            if (form2.Question != null)
            {
                questions.AddRange(form2.Question);
            }
        }

        private void editQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditQuestionForm editQuestionForm = new EditQuestionForm(questions);
            editQuestionForm.ShowDialog();
        }

        private void deleteQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteQuestionForm deleteQuestionForm = new DeleteQuestionForm(questions);
            deleteQuestionForm.ShowDialog();
        }


        private void MuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(isMute)
            {
                isMute = false;
            }
            else
            {
                isMute = true;
                player.Stop();
            }
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game created by Zhurzher Oleksandr", "Info");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fileStream = new FileStream("questions.xml", FileMode.Create);
            var serializer = new XmlSerializer(typeof(List<Question>));
            serializer.Serialize(fileStream, questions);
            fileStream.Close();
        }
    }
}
