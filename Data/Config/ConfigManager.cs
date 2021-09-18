using Microsoft.AspNetCore.Mvc;
using CommitZeroBack.Models;
using System.Text.Json;
using System.IO;
using System;
using Npgsql;

namespace CommitZeroBack.Data {
    public static class ConfigManager {
        public static string connection_string() {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/')
            };

            return builder.ToString();
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