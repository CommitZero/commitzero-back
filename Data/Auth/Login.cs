using Npgsql;
using System.Linq;
using System;
using CommitZeroBack.Tools;

namespace CommitZeroBack.Data {
    public static class Login {
        public static string Execute(string username, string password) {
            string RealUsername = string.Empty;
            string RealPassword = string.Empty;
            string UserIp = IpGetter.Get();


            NpgsqlConnection conn = new(Globals.ConnectionString);
            string compare_script = $"SELECT * FROM users WHERE username='{username}' AND password='{password}'";
            
            conn.Open();

            NpgsqlCommand com = new (compare_script, conn);
            NpgsqlDataReader reader = com.ExecuteReader();
            while(reader.Read()){
                RealPassword = reader["password"].ToString();
                RealUsername = reader["username"].ToString();
            }

            if (RealPassword == password && RealUsername == username) {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var SessionToken = new string(Enumerable.Repeat(chars, 125).Select(s => s[new Random().Next(s.Length)]).ToArray());
                string session_script = $"UPDATE users SET sessiontoken='{SessionToken}', sessionip='{UserIp}', sessionexpiration='test'";

                NpgsqlCommand session_com = new (session_script, conn);
                session_com.ExecuteNonQuery();
                return 
            }

            conn.Close();

        }
    }
}