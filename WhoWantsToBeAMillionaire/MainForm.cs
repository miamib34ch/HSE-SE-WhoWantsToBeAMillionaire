namespace WhoWantsToBeAMillionaire
{
    public partial class MainForm : Form
    {

        List<Question> questions = new List<Question>();
        private Random rnd = new Random();
        int level = 0;
        Question currentQuestion;
        bool itChangeQuestion = false;
        bool hasRightToFail = false;
        int podskazki = 0;

        public MainForm()
        {
            InitializeComponent();
            ReadFile();
            startGame();
        }

        private void ReadFile()
        {
            string path = @"Вопросы.txt";

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    questions.Add(new Question(line.Split('\t')));
                }
            }
        }

        private void ShowQuestion(Question q)
        {
            lblQuestion.Text = q.Text;
            btnAnswerA.Text = q.Answers[0];
            btnAnswerB.Text = q.Answers[1];
            btnAnswerC.Text = q.Answers[2];
            btnAnswerD.Text = q.Answers[3];
        }

        private Question GetQuestion(int level)
        {
            var questionsWithLevel = questions.Where(q => q.Level == level).ToList();
            return questionsWithLevel[rnd.Next(questionsWithLevel.Count)];
        }

        private void NextStep()
        {
            Button[] btns = new Button[] { btnAnswerA, btnAnswerB, btnAnswerC, btnAnswerD };

            foreach (Button btn in btns)
                btn.Enabled = true;
            if (itChangeQuestion)
                itChangeQuestion = false;
            else
                level++;
            currentQuestion = GetQuestion(level);
            ShowQuestion(currentQuestion);
            lstLevel.SelectedIndex = lstLevel.Items.Count - level;
        }

        private void startGame()
        {
            SaveMoney sm = new SaveMoney();
            sm.ShowDialog();
            level = 0;
            podskazki = 0;
            btnChangeQuestion.Enabled = true;
            btn50.Enabled = true;
            btnFriendsHelp.Enabled = true;
            btnHallHelp.Enabled = true;
            btnRightToFail.Enabled = true;
            NextStep();
        }

        private void Record(int prize)
        {
            Victorie vic = new Victorie(prize);
            vic.ShowDialog();
        }

        public string Conc(string[] mas)
        {
            string res = "";
            foreach (string s in mas)
                res += s;
            return res;
        }

        #region Кнопки ответов

        void btnClick (object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!hasRightToFail)
            {
                if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                {
                    if (level == 15)
                    {
                        Record(3000000);
                        startGame();
                    }
                    else
                        NextStep();
                }
                else
                {
                    MessageBox.Show("Неверный ответ!");
                    if (int.Parse(Conc(lstLevel.SelectedItem.ToString().Split(" "))) > int.Parse(Conc(SaveMoney.select.Split(" "))))
                        Record(int.Parse(Conc(SaveMoney.select.Split(" "))));
                    else
                        Record(0);
                    startGame();
                }
            }
            else
            {
                if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                {
                    if (level == 15)
                    {
                        Record(3000000);
                        startGame();
                    }
                    else
                        NextStep();
                    hasRightToFail = false;
                }
                else
                {
                    MessageBox.Show("Неверный ответ!");
                    hasRightToFail = false;
                }
            }
        }

        private void btnAnswerA_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Tag.ToString() != currentQuestion.RightAnswer.ToString())
                ((Button)sender).Enabled = false;
            btnClick(sender, e);
        }

        private void btnAnswerB_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Tag.ToString() != currentQuestion.RightAnswer.ToString())
                ((Button)sender).Enabled = false;
            btnClick(sender, e);
        }

        private void btnAnswerC_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Tag.ToString() != currentQuestion.RightAnswer.ToString())
                ((Button)sender).Enabled = false;
            btnClick(sender, e);
        }

        private void btnAnswerD_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Tag.ToString() != currentQuestion.RightAnswer.ToString())
                ((Button)sender).Enabled = false;
            btnClick(sender, e);
        }

        #endregion

        #region Подсказки

        private void btn50_Click(object sender, EventArgs e)
        {
            Button[] btns = new Button[] { btnAnswerA, btnAnswerB, btnAnswerC, btnAnswerD };
            
            int count = 0;
            while (count < 2)
            {
                int n = rnd.Next(4);
                int answer = int.Parse(btns[n].Tag.ToString());

                if (answer != currentQuestion.RightAnswer && btns[n].Enabled)
                {
                    btns[n].Enabled = false;
                    count++;
                }
            }
            btn50.Enabled = false;
            podskazki++;
            checkNumPodsk();
        }

        private void btnChangeQuestion_Click(object sender, EventArgs e)
        {
            itChangeQuestion = true;
            NextStep();
            btnChangeQuestion.Enabled = false;
            podskazki++;
            checkNumPodsk();
        }

        private void btnFriendsHelp_Click(object sender, EventArgs e)
        {
            Button[] btns = new Button[] { btnAnswerA, btnAnswerB, btnAnswerC, btnAnswerD };
            Button rightBtn = new Button();
            Button falseBtn = new Button();
            foreach (Button btn in btns) 
            {
                if (btn.Tag.ToString() == currentQuestion.RightAnswer.ToString())
                    rightBtn = btn;
                else
                    falseBtn = btn;
            }

            int p = rnd.Next(5);

            if (p == 0 || p == 1 || p == 2 || p == 3) 
            {
                if (p == 0)
                {
                    MessageBox.Show($"Твой друг Богдан уверенно считает, что ответ \"{rightBtn.Text}\"");
                }
                else
                {
                    if (p == 1 || p == 2 || p == 3)
                    {
                        if (p == 1 || p == 2)
                        {
                            if (p == 1)
                                MessageBox.Show($"Твой друг Богдан считает, что ответ либо \"{falseBtn.Text}\", либо \"{rightBtn.Text}\"");
                            else
                                MessageBox.Show($"Твой друг Богдан считает, что ответ либо \"{rightBtn.Text}\", либо \"{falseBtn.Text}\"");
                        }
                        else
                        {
                            MessageBox.Show($"Твой друг Богдан считает, что ответ точно не \"{falseBtn.Text}\""); 
                        }

                    }
                }
            }
            else
                MessageBox.Show($"Твой друг Богдан не знает ответ, предлагает тебе забрать деньги, поскольку удача не на твоей стороне :(");
            btnFriendsHelp.Enabled = false;
            podskazki++;
            checkNumPodsk();
        }

        private void btnHallHelp_Click(object sender, EventArgs e)
        {
            Button[] btns = new Button[] { btnAnswerA, btnAnswerB, btnAnswerC, btnAnswerD };
            Button rightBtn = new Button();
            Button falseBtn = new Button();
            foreach (Button btn in btns)
            {
                if (btn.Tag.ToString() == currentQuestion.RightAnswer.ToString())
                    rightBtn = btn;
                else
                    falseBtn = btn;
            }

            int res = 0;
            for (int i = 0;i < 40; i++)
            {
                int p = rnd.Next(5);
                res += p;
            }
            if(res >= 50 + level*5)
            {
                MessageBox.Show($"60% зала считает, что ответ \"{rightBtn.Text}\", а 40% за \"{falseBtn.Text}\"");
            }
            else
            {
                MessageBox.Show($"60% зала считает, что ответ \"{falseBtn.Text}\", а 40% за \"{rightBtn.Text}\"");
            }

            btnHallHelp.Enabled = false;
            podskazki++;
            checkNumPodsk();
        }

        private void btnRightToFail_Click(object sender, EventArgs e)
        {
            hasRightToFail = true;
            btnRightToFail.Enabled = false;
            podskazki++;
            checkNumPodsk();
        }

        void checkNumPodsk()
        {
            if (podskazki == 4)
            {
                var msg = MessageBox.Show("Вы уверены?", "Это будет последняя подсказка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    //кнопки ответов поменять на подсказки и сначала чек а потом выполнение подсказки
                    Button[] btns = new Button[] { btnAnswerA, btnAnswerB, btnAnswerC, btnAnswerD };
                    foreach (Button btn in btns)
                        btn.Enabled = false;
                }
                else
                    podskazki--;
            }
        }

        #endregion
    }
}