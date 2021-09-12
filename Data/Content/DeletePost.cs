using Npgsql;
using System;
using System.Text.Json;
using CommitZeroBack.Models;

namespace CommitZeroBack.Data {
    public static class DeletePost {
        public static string Execute(string access_token, int post_id) {

            if (Convert.ToBoolean(ValidateLogin.Execute(access_token))) {
                try {
                    NpgsqlConnection conn = new(Globals.ConnectionString);

                    /* FETCH */

                    string fetch_script = $"DELETE FROM posts WHERE id='{post_id}'";

                    conn.Open();

                    NpgsqlCommand com = new (fetch_script, conn);
                    com.ExecuteNonQuery();

                    conn.Close();

                    return JsonSerializer.Serialize(new Response() {
                        data = "Post deletado com sucesso"
                    });

                }
                catch(Exception e) {
                    return JsonSerializer.Serialize(new Response() {
                        data = "Erro: " + e
                    });
                }
            }

            return JsonSerializer.Serialize(new Response() {
                data = "Erro"
            });
        }
    }
}