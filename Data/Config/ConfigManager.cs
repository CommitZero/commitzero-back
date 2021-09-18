using Microsoft.AspNetCore.Mvc;
using CommitZeroBack.Models;
using System.Text.Json;
using System.IO;
using System.Diagnostics;

namespace CommitZeroBack.Data {
    public static class ConfigManager {
        public static string connection_string() {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "hk.bat";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }

        public static string api_key() {
            return AppConfig().api_key;
        }

        public static string postgres_host() {
            return AppConfig().postgres_host;
        }

        public static string postgres_port() {
            return AppConfig().postgres_port;
        }

        public static string postgres_user() {
            return AppConfig().postgres_user;
        }

        public static string postgres_password() {
            return AppConfig().postgres_password;
        }

        public static string postgres_db() {
            return AppConfig().postgres_db;
        }

        public static Config AppConfig() {
            return JsonSerializer.Deserialize<Config>(File.ReadAllText(Directory.GetCurrentDirectory() + @"/environment.json"));
        }
    }
}