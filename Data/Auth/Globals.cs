using System;

namespace CommitZeroBack.Data {
    public static class Globals {
        public static string ConnectionString() {
            return $"Server={Environment.GetEnvironmentVariable("POSTGRES_HOST")};" + 
            $"Port={Environment.GetEnvironmentVariable("POSTGRES_PORT")};" + 
            $"Database={Environment.GetEnvironmentVariable("POSTGRES_DB")};" +
            $"User Id={Environment.GetEnvironmentVariable("POSTGRES_USER")};" +
            $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")}";
        }

        public static string MigrationString() {
            return $"Server={Environment.GetEnvironmentVariable("POSTGRES_HOST")};" + 
            $"Port={Environment.GetEnvironmentVariable("POSTGRES_PORT")};" + 
            $"Database=postgres;" +
            $"User Id={Environment.GetEnvironmentVariable("POSTGRES_USER")};" +
            $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")}";
        }
    };
}