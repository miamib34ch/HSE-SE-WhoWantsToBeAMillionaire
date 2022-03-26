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
            level = 0;
            btnChangeQuestion.Enabled = true;
            btn50.Enabled = true;
            btnFriendsHelp.Enabled = true;
            btnHallHelp.Enabled = true;
            btnRightToFail.Enabled = true;
            NextStep();
        }

        void btnClick (object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                NextStep();
            else
            {
                MessageBox.Show("Неверный ответ!");
                if (hasRightToFail)
                    hasRightToFail = false;
                else
                    startGame();
            }
        }
        private void btnAnswerA_Click(object sender, EventArgs e)
        {
            btnClick(sender, e);
        }

        private void btnAnswerB_Click(object sender, EventArgs e)
        {
            btnClick(sender, e);
        }

        private void btnAnswerC_Click(object sender, EventArgs e)
        {
            btnClick(sender, e);
        }

        private void btnAnswerD_Click(object sender, EventArgs e)
        {
            btnClick(sender, e);
        }

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
        }

        private void btnChangeQuestion_Click(object sender, EventArgs e)
        {
            itChangeQuestion = true;
            NextStep();
            btnChangeQuestion.Enabled = false;
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

            Random rnd = new Random();
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
        }

        private void btnHallHelp_Click(object sender, EventArgs e)
        {
            btnHallHelp.Enabled = false;
        }

        private void btnRightToFail_Click(object sender, EventArgs e)
        {
            btnRightToFail.Enabled = false;
        }
    }
}