using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire
{
    public class Record
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public int score { get; private set; }

        Record() { }

        public Record(int id, string name, int score)
        {
            this.id = id;
            this.name = name;
            this.score = score;

            using (var db = new RecordContex())
            {
                try
                {
                    db.record.Add(this);
                    db.SaveChanges();
                }
                catch
                {
                }
            }
        }

        public static List<Record> sortByScore()
        {
            using (var db = new RecordContex())
            {
                return db.record.OrderByDescending(x=>x.score).ToList();
            }
        }

        public override string ToString()
        {
            return $"{name} {score}"; 
        }

        public static void deleteAll()
        {
            using (var db = new RecordContex())
            {
                foreach (var rcrd in db.record)
                    db.record.Remove(rcrd);
                db.SaveChanges();
            }
        }
    }

    class RecordContex : DbContext
    {
        public DbSet<Record> record { get; private set; }

        public string DbPath { get; }

        public RecordContex() : base()
        {
            DbPath = MainForm.GetPath();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
