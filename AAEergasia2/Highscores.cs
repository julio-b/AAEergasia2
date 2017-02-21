using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace AAEergasia2 {
    public class Highscores {
        
        private SQLiteConnection con;
        private string filename = "..\\..\\Externals\\Highscores.sqldb";

        public Highscores() {
            NewCon();
        }

        public void InsertScore(string name, int score, int seconds) {
            string sql = "INSERT INTO highscores (name, score, time) VALUES ('" + name + "'," + score + "," + seconds + ")";
            SQLiteCommand command = new SQLiteCommand(sql, con);
            command.ExecuteNonQuery();
        }

        private void NewCon() {
            if (!System.IO.File.Exists(filename)) {
                SQLiteConnection.CreateFile(filename);
            }
            con = new SQLiteConnection("Data Source=" + filename + ";Version=3;");
            con.Open();
            string sql = "CREATE TABLE IF NOT EXISTS highscores (name VARCHAR(30), score INT, time INT)";
            SQLiteCommand command = new SQLiteCommand(sql, con);
            command.ExecuteNonQuery();
        }

        private SQLiteDataReader GetTopOrder(string order="score") {
            string sql = "SELECT * FROM highscores ORDER BY "+ order +" ASC";
            SQLiteCommand command = new SQLiteCommand(sql, con);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SQLiteDataReader GetTopScores() {
            return GetTopOrder("score");
        }

        public SQLiteDataReader GetTopTimes() {
            return GetTopOrder("time");
        }

        public void Close() {
            con.Close();
        }

    }

}
