using Npgsql;
using CommitZeroBack.Models;
using System.Collections.Generic;
using System.Text.Json;
using System;

namespace CommitZeroBack.Data {
    public static class GetPosts {
        public static string Execute(int quantity) {
            List<PostLink> posts = new List<PostLink>();
            try {
                NpgsqlConnection conn = new NpgsqlConnection(Globals.ConnectionString());

                string fetch_script = $"select * from post_links order by id desc limit {quantity};";

                conn.Open();

                NpgsqlCommand com = new NpgsqlCommand(fetch_script, conn);
                NpgsqlDataReader reader = com.ExecuteReader();
                
                while(reader.Read()){
                    posts.Add(new PostLink(){
                        id = int.Parse(reader["id"].ToString()),
                        title = reader["title"].ToString(),
                        description = reader["description"].ToString(),
                        cathegory = reader["cathegory"].ToString(),
                        author = reader["author"].ToString(),
                        miniature = reader["image_url"].ToString()
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