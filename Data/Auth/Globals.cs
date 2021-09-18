using System;

namespace CommitZeroBack.Data {
    public static class Globals {
        public static string ConnectionString() {
            return ConfigManager.connection_string();
            /*
            return $"Server={ConfigManager.postgres_host()};" + 
            $"Port={ConfigManager.postgres_port()};" + 
            $"Database={ConfigManager.postgres_db()};" +
            $"User Id={ConfigManager.postgres_user()};" +
            $"Password={ConfigManager.postgres_password()}";
            */
        }
    };
}