namespace Who_want_to_become_millionaire
{
    partial class AddQuestionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.question = new System.Windows.Forms.TextBox();
            this.AnswerA = new System.Windows.Forms.TextBox();
            this.AnswerB = new System.Windows.Forms.TextBox();
            this.AnswerC = new System.Windows.Forms.TextBox();
            this.AnswerD = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите вопрос:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введите первый вариант ответа(правильный):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Введите второй вариант ответа:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Введите третий вариант ответа: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Введите четвертый вариант ответа: ";
            // 
            // question
            // 
            this.question.Location = new System.Drawing.Point(12, 29);
            this.question.MaxLength = 150;
            this.question.Multiline = true;
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(345, 40);
            this.question.TabIndex = 5;
            // 
            // AnswerA
            // 
            this.AnswerA.Location = new System.Drawing.Point(12, 86);
            this.AnswerA.MaxLength = 70;
            this.AnswerA.Name = "AnswerA";
            this.AnswerA.Size = new System.Drawing.Size(345, 20);
            this.AnswerA.TabIndex = 6;
            // 
            // AnswerB
            // 
            this.AnswerB.Location = new System.Drawing.Point(12, 125);
            this.AnswerB.MaxLength = 70;
            this.AnswerB.Name = "AnswerB";
            this.AnswerB.Size = new System.Drawing.Size(345, 20);
            this.AnswerB.TabIndex = 7;
            // 
            // AnswerC
            // 
            this.AnswerC.Location = new System.Drawing.Point(12, 164);
            this.AnswerC.MaxLength = 70;
            this.AnswerC.Name = "AnswerC";
            this.AnswerC.Size = new System.Drawing.Size(345, 20);
            this.AnswerC.TabIndex = 8;
            // 
            // AnswerD
            // 
            this.AnswerD.Location = new System.Drawing.Point(12, 203);
            this.AnswerD.MaxLength = 70;
            this.AnswerD.Name = "AnswerD";
            this.AnswerD.Size = new System.Drawing.Size(345, 20);
            this.AnswerD.TabIndex = 9;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(48, 240);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(107, 41);
            this.AddButton.TabIndex = 10;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(187, 240);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(107, 41);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 302);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AnswerD);
            this.Controls.Add(this.AnswerC);
            this.Controls.Add(this.AnswerB);
            this.Controls.Add(this.AnswerA);
            this.Controls.Add(this.question);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Добавление вопроса";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox question;
        private System.Windows.Forms.TextBox AnswerA;
        private System.Windows.Forms.TextBox AnswerB;
        private System.Windows.Forms.TextBox AnswerC;
        private System.Windows.Forms.TextBox AnswerD;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelButton;
    }
}