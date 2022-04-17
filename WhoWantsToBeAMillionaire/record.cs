using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire
{
    public class record
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public int score { get; private set; }

        record()
        {

        }

        public record(int id, string name, int score)
        {
            this.id = id;
            this.name = name;
            this.score = score;
            using (var db = new recordContex())
            {
                try
                {
                    db.record.Add(this);
                    db.SaveChanges();
                }
                catch
                {
                    db.record.Update(this);
                    db.SaveChanges();
                }
            }
        }

        public static List<record> download()
        {
            using (var db = new recordContex())
            {
                return db.record.Where(x=> x.id < 11).ToList();
            }
        }

        public override string ToString()
        {
            return $"{id}. {name} {score}"; 
        }

    }

    class recordContex : DbContext
    {
        public DbSet<record> record { get; private set; }

        public string DbPath { get; }

        public recordContex() : base()
        {
            DbPath = MainForm.GetPath();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
