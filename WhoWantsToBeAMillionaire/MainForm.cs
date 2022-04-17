namespace WhoWantsToBeAMillionaire
{
    public partial class MainForm : Form
    {

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
                int id = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    new Question(line.Split('\t'), id);
                    id++;
                }
            }
        }

        private void ShowQuestion(Question q)
        {
            lblQuestion.Text = q.question;
            btnAnswerA.Text = q.answerA;
            btnAnswerB.Text = q.answerB;
            btnAnswerC.Text = q.answerC;
            btnAnswerD.Text = q.answerD;
        }

        private Question GetQuestion(int level)
        {
            var questionsWithLevel = Question.download(level);
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

        public static string GetPath()
        {
            string[] start = (Application.StartupPath).Split('\\');
            string path = "";
            for ( int i = 0; i <7; i++) 
            {
                path += start[i];
                path += "\\";
            }
            path += "Resources\\whoWantsDb.db";
            return path;
        }

        #region Кнопки ответов

        void btnClick (object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!hasRightToFail)
            {
                if (currentQuestion.rightAnswer == int.Parse(button.Tag.ToString()))
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
                if (currentQuestion.rightAnswer == int.Parse(button.Tag.ToString()))
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
            if (((Button)sender).Tag.ToString() != currentQuestion.rightAnswer.ToString())
                ((Button)sender).Enabled = false;
            btnClick(sender, e);
        }

        private void btnAnswerB_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Tag.ToString() != currentQuestion.rightAnswer.ToString())
                ((Button)sender).Enabled = false;
            btnClick(sender, e);
        }

        private void btnAnswerC_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Tag.ToString() != currentQuestion.rightAnswer.ToString())
                ((Button)sender).Enabled = false;
            btnClick(sender, e);
        }

        private void btnAnswerD_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Tag.ToString() != currentQuestion.rightAnswer.ToString())
                ((Button)sender).Enabled = false;
            btnClick(sender, e);
        }

        #endregion

        #region Подсказки

        private void btn50_Click(object sender, EventArgs e)
        {
            podskazki++;
            if (checkNumPodsk() == DialogResult.Yes)
            {
                Button[] btns = new Button[] { btnAnswerA, btnAnswerB, btnAnswerC, btnAnswerD };

                int count = 0;
                while (count < 2)
                {
                    int n = rnd.Next(4);
                    int answer = int.Parse(btns[n].Tag.ToString());

                    if (answer != currentQuestion.rightAnswer && btns[n].Enabled)
                    {
                        btns[n].Enabled = false;
                        count++;
                    }
                }
                btn50.Enabled = false;
            }
        }

        private void btnChangeQuestion_Click(object sender, EventArgs e)
        {
            podskazki++;
            if (checkNumPodsk() == DialogResult.Yes)
            {
                itChangeQuestion = true;
                NextStep();
                btnChangeQuestion.Enabled = false;
            }
        }

        private void btnFriendsHelp_Click(object sender, EventArgs e)
        {
            podskazki++;
            if (checkNumPodsk() == DialogResult.Yes)
            {
                Button[] btns = new Button[] { btnAnswerA, btnAnswerB, btnAnswerC, btnAnswerD };
                Button rightBtn = new Button();
                Button falseBtn = new Button();
                foreach (Button btn in btns)
                {
                    if (btn.Tag.ToString() == currentQuestion.rightAnswer.ToString())
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
            }
        }

        private void btnHallHelp_Click(object sender, EventArgs e)
        {
            podskazki++;
            if (checkNumPodsk() == DialogResult.Yes)
            {
                Button[] btns = new Button[] { btnAnswerA, btnAnswerB, btnAnswerC, btnAnswerD };
                Button rightBtn = new Button();
                Button falseBtn = new Button();
                foreach (Button btn in btns)
                {
                    if (btn.Tag.ToString() == currentQuestion.rightAnswer.ToString())
                        rightBtn = btn;
                    else
                        falseBtn = btn;
                }

                int res = 0;
                for (int i = 0; i < 40; i++)
                {
                    int p = rnd.Next(5);
                    res += p;
                }
                if (res >= 50 + level * 5)
                {
                    MessageBox.Show($"60% зала считает, что ответ \"{rightBtn.Text}\", а 40% за \"{falseBtn.Text}\"");
                }
                else
                {
                    MessageBox.Show($"60% зала считает, что ответ \"{falseBtn.Text}\", а 40% за \"{rightBtn.Text}\"");
                }

                btnHallHelp.Enabled = false;
            }
        }

        private void btnRightToFail_Click(object sender, EventArgs e)
        {
            podskazki++;
            if (checkNumPodsk() == DialogResult.Yes)
            {
                hasRightToFail = true;
                btnRightToFail.Enabled = false;
            }
        }

        DialogResult checkNumPodsk()
        {
            if (podskazki == 4)
            {
                var msg = MessageBox.Show("Вы уверены?", "Это будет последняя подсказка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    Button[] btns = new Button[] { btn50, btnChangeQuestion, btnFriendsHelp, btnRightToFail, btnHallHelp };
                    foreach (Button btn in btns)
                        btn.Enabled = false;
                    return msg;
                }
                else
                {
                    podskazki--;
                    return msg;
                }
            }
            else
                return DialogResult.Yes;
        }

        #endregion
    }
}