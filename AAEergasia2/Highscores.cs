using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace AAEergasia2 {

    public class Highscores {
        private SQLiteConnection con;
        public Highscores() {
            if (!System.IO.File.Exists("Highscores.sql")) {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");
            }
            con = new SQLiteConnection("Data Source=Highscores.sql;Version=3;");
            con.Open();
            string sql = "CREATE TABLE IF NOT EXISTS highscores (name VARCHAR(30), score INT)";
            SQLiteCommand command = new SQLiteCommand(sql, con);
            command.ExecuteNonQuery();
        }

        public void InsertScore(string name, int score) {
            string sql = "INSERT INTO highscores (name, score) VALUES ('" + name + "'," + score + ")";
            SQLiteCommand command = new SQLiteCommand(sql, con);
            command.ExecuteNonQuery();
        }
        

        public SQLiteDataReader GetTopScores() {
            string sql = "SELECT * FROM highscores ORDER BY score ASC";
            SQLiteCommand command = new SQLiteCommand(sql, con);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void Close() {
            con.Close();
        }

    }

}
