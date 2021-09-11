using Npgsql;
using CommitZeroBack.Tools;
using System;

namespace CommitZeroBack.Data {
    public static class ValidateLogin {
        public static bool Execute(string access_token) {
            string RealSessionToken = string.Empty;
            string RealUserIp = string.Empty;
            string UserIp = IpGetter.Get();

            try {
                NpgsqlConnection conn = new(Globals.ConnectionString);
                string compare_script = $"select * FROM users WHERE (sessiontoken='{access_token}' AND sessionip='{UserIp}')";
                
                conn.Open();

                NpgsqlCommand com = new (compare_script, conn);
                NpgsqlDataReader reader = com.ExecuteReader();
                while(reader.Read()){
                    RealSessionToken = reader["sessiontoken"].ToString();
                    RealUserIp = reader["sessionip"].ToString();
                }

                conn.Close();
            }
            catch {
                return false;
            }

            if(access_token == RealSessionToken && UserIp == RealUserIp) {
                return true;
            }
            return false;
        }
    }
}