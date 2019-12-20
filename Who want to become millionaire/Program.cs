using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Who_want_to_become_millionaire
{
    [Serializable]
    public class Question
    {
        public string question { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }

        public Question()
        {
        }
        //public Question(Question question)
        //{
        //    this.question = question.question;
        //    AnswerA = question.AnswerA;
        //    AnswerB = question.AnswerB;
        //    AnswerC = question.AnswerC;
        //    AnswerD = question.AnswerD;
        //}
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //StreamReader streamReader = new StreamReader("question.txt", System.Text.Encoding.Default);
            //List<Question> questions = new List<Question>();
            //Question question = new Question();
            //for (int i = 0; i < 15; i++)
            //{
            //    question.question = streamReader.ReadLine();
            //    question.AnswerA = streamReader.ReadLine();
            //    question.AnswerB = streamReader.ReadLine();
            //    question.AnswerC = streamReader.ReadLine();
            //    question.AnswerD = streamReader.ReadLine();
            //    questions.Add(new Question(question));
            //}
            //streamReader.Close();

            //FileStream fileStream = new FileStream("questions.xml", FileMode.Create);
            //var serializer = new XmlSerializer(typeof(List<Question>));
            //serializer.Serialize(fileStream, questions);
            //fileStream.Close();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
