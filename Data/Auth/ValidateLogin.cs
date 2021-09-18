using Npgsql;
using CommitZeroBack.Tools;
using System;
using System.Globalization;

namespace CommitZeroBack.Data {
    public static class ValidateLogin {
        public static bool Execute(string access_token) {
            string RealSessionToken = string.Empty;
            string RealUserIp = string.Empty;
            DateTime ExpirationDate = new DateTime();
            string UserIp = IpGetter.Get();

            if(!ValidData.IsValid(access_token)) return false;

            try {
                NpgsqlConnection conn = new NpgsqlConnection(Globals.ConnectionString());
                string compare_script = $"select * FROM users WHERE (sessiontoken='{access_token}' AND sessionip='{UserIp}')";
                
                conn.Open();

                NpgsqlCommand com = new NpgsqlCommand(compare_script, conn);
                NpgsqlDataReader reader = com.ExecuteReader();
                while(reader.Read()){
                    RealSessionToken = reader["sessiontoken"].ToString();
                    RealUserIp = reader["sessionip"].ToString();
                    ExpirationDate = DateTime.ParseExact(reader["sessionexpiration"].ToString(),
                    "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                }

                conn.Close();
            }
            catch {
                return false;
            }

            if(access_token == RealSessionToken && UserIp == RealUserIp && DateTime.Now < ExpirationDate) {
                return true;
            }
            return false;
        }
    }
}