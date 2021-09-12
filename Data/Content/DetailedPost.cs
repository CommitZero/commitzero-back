using Npgsql;
using CommitZeroBack.Models;
using System.Collections.Generic;
using System.Text.Json;
using System;

namespace CommitZeroBack.Data {
    public static class DetailedPost {
        public static string Execute(int id) {
            List<Post> posts = new();
            try {
                NpgsqlConnection conn = new(Globals.ConnectionString);

                string fetch_script = @$"select * from posts where (id = '{id}');";

                conn.Open();

                NpgsqlCommand com = new (fetch_script, conn);
                NpgsqlDataReader reader = com.ExecuteReader();
                
                while(reader.Read()){
                    posts.Add(new Post(){
                        author_id = int.Parse(reader["author_id"].ToString()),
                        id = int.Parse(reader["id"].ToString()),
                        title = reader["title"].ToString(),
                        description = reader["description"].ToString(),
                        cathegory = reader["cathegory"].ToString(),
                        author = reader["author"].ToString(),
                        created_at = reader["created_at"].ToString(),
                        updated_at = reader["updated_at"].ToString()
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