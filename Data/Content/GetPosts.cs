using Npgsql;
using CommitZeroBack.Models;
using System.Collections.Generic;
using System.Text.Json;
using System;

namespace CommitZeroBack.Data {
    public static class GetPosts {
        public static string Execute(int quantity) {
            List<PostLink> posts = new();
            try {
                NpgsqlConnection conn = new(Globals.ConnectionString);

                string fetch_script = $"select * from post_links order by id desc limit {quantity};";

                conn.Open();

                NpgsqlCommand com = new (fetch_script, conn);
                NpgsqlDataReader reader = com.ExecuteReader();
                
                while(reader.Read()){
                    posts.Add(new PostLink(){
                        id = int.Parse(reader["id"].ToString()),
                        title = reader["title"].ToString(),
                        description = reader["description"].ToString(),
                        cathegory = reader["cathegory"].ToString(),
                        author = reader["author"].ToString(),
                        miniature = reader["miniature"].ToString()
                    });
                }

                return JsonSerializer.Serialize(posts);
            }
            catch(Exception e) {
                return JsonSerializer.Serialize(new Response() {
                    data = "Erro: " + e
                });
            }
        }
    }
}