using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire
{
    class Question
    {
        public int id { get; private set; }
        public string question { get; private set; }
        public string answerA { get; private set; }
        public string answerB { get; private set; }
        public string answerC { get; private set; }
        public string answerD { get; private set; }
        public int rightAnswer { get; private set; }
        public int level { get; private set; }

        Question() { }

        public Question(string[] s, int id)
        {
            this.id = id;
            question = s[0];
            answerA = s[1];
            answerB = s[2];
            answerC = s[3];
            answerD = s[4];
            rightAnswer = int.Parse(s[5]);
            level = int.Parse(s[6]);

            using (var db = new QuestionContex())
            {
                try
                {
                    db.questions.Add(this);
                    db.SaveChanges();
                }
                catch
                {
                }
            }
        }

        public static List<Question> downloadByLevel(int lvl)
        {
            using (var db = new QuestionContex())
            {
                return db.questions.Where(x => x.level == lvl).ToList();
            }
        }

        public static void deleteAll()
        {
            using (var db = new QuestionContex())
            {
                foreach (var qst in db.questions)
                    db.questions.Remove(qst);
                db.SaveChanges();
            }
        }
    }

    class QuestionContex: DbContext
    {
        public DbSet<Question>questions{ get; private set; }

        public string DbPath { get; }

        public QuestionContex(): base()
        {
            DbPath = MainForm.GetPath();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
