using Npgsql;
using System.Linq;
using System.Text.Json;
using System;
using CommitZeroBack.Tools;
using CommitZeroBack.Models;

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

            conn.Close();
            conn.Open();

            if (RealPassword == password && RealUsername == username) {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var SessionToken = new string(Enumerable.Repeat(chars, 125).Select(s => s[new Random().Next(s.Length)]).ToArray());
                string session_script = @$"UPDATE users SET sessiontoken='{SessionToken}', sessionip='{UserIp}', 
                sessionexpiration='{DateTime.Now.AddHours(12).ToString()}'";

                NpgsqlCommand session_com = new (session_script, conn);
                session_com.ExecuteNonQuery();
                return JsonSerializer.Serialize(new Response() { data = SessionToken });
            }

            conn.Close();
            return JsonSerializer.Serialize(new Response() { data = "[Error]" });
        }
    }
}