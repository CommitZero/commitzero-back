using Npgsql;
using System;
using System.Text.Json;
using CommitZeroBack.Models;
using CommitZeroBack.Tools;

namespace CommitZeroBack.Data {
    public static class NewPost {
        public static string Execute(string access_token, string post_title, string post_cathegory,
        string post_description, string post_content, string image_url) {
            string created_at = DateTime.Now.ToString();
            string updated_at = DateTime.Now.ToString();
            string author = string.Empty;
            int author_id = 0;

            if (!ValidData.IsValid(access_token)) {
                return JsonSerializer.Serialize(new Response() {
                    data = "Erro - Dados inválidos"
                });
            }

            if (Convert.ToBoolean(ValidateLogin.Execute(access_token))) {
                try {
                    NpgsqlConnection conn_fetch = new(Globals.ConnectionString);
                    NpgsqlConnection conn_post = new(Globals.ConnectionString);

                    /* FETCH */

                    string fetch_script = $"SELECT * FROM users WHERE sessiontoken='{access_token}'";

                    conn_fetch.Open();

                    NpgsqlCommand com_fetch = new (fetch_script, conn_fetch);
                    NpgsqlDataReader reader = com_fetch.ExecuteReader();
                    
                    while(reader.Read()){
                        author = reader["username"].ToString();
                        author_id = int.Parse(reader["id"].ToString());
                    }

                    conn_fetch.Close();

                    /* POST */
                    string post_script = @$"INSERT INTO posts (author_id, title, description, cathegory, author, 
                    content, created_at, updated_at) VALUES ({author_id}, '{post_title}', '{post_description}',
                    '{post_cathegory}', '{author}', '{post_content}', '{created_at}', '{updated_at}');";

                    string postlink_script = @$"INSERT INTO post_links (title, description, cathegory, author, image_url) 
                    VALUES ('{post_title}', '{post_description}', '{post_cathegory}',
                    '{author}', '{image_url}');";

                    conn_post.Open();
                    NpgsqlCommand com_post = new (post_script + postlink_script, conn_post);
                    com_post.ExecuteNonQuery();
                    conn_post.Close();

                    return JsonSerializer.Serialize(new Response() {
                        data = "Post criado com sucesso"
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