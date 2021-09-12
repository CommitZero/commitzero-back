using System;

namespace CommitZeroBack.Data {
    public static class Globals {
        public static string ConnectionString = 
        $"Server={Environment.GetEnvironmentVariable("POSTGRES_HOST")};" + 
        $"Port={Environment.GetEnvironmentVariable("POSTGRES_PORT")};" + 
        $"Database={Environment.GetEnvironmentVariable("POSTGRES_DB")};" +
        $"User Id={Environment.GetEnvironmentVariable("POSTGRES_USER")};" +
        $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")}";
        public const string CommitZeroKey = "AS3FR5G87U-12BL9-SWE67HJ890-SW23D";
    };
}