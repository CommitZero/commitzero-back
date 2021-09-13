using Npgsql;
using System;

namespace CommitZeroBack.Data {
    public static class DBMaker {
        public static string Execute() {
            string script_init = @"
                CREATE DATABASE commitzero;
            ";

            string script_actions = @"                
                CREATE TABLE commitzero.public.users (
                    id serial NOT NULL,
                    username varchar(99) NOT NULL,
                    password varchar(99) NOT NULL,
                    sessionip varchar(99),
                    sessiontoken varchar(99),
                    sessionexpiration varchar(99)
                );

                CREATE TABLE commitzero.public.post_links (
                    id serial NOT NULL,
                    title varchar(99) NOT NULL,
                    cathegory varchar(99) NOT NULL,
                    author varchar(99) NOT NULL,
                    description varchar(99) NOT NULL,
                    image_url varchar(99) NOT NULL
                );

                CREATE TABLE commitzero.public.posts (
                    id serial NOT NULL,
                    author_id int NOT NULL,
                    title varchar(99) NOT NULL,
                    cathegory varchar(99) NOT NULL,
                    author varchar(99) NOT NULL,
                    description varchar(99) NOT NULL,
                    content text NOT NULL,
                    created_at varchar(99) NOT NULL,
                    updated_at varchar(99) NOT NULL
                );";

            try {
                NpgsqlConnection conn = new(Globals.MigrationString());
                conn.Open();
                NpgsqlCommand com = new(script_init, conn);
                com.ExecuteNonQuery();
                conn.Close();

                NpgsqlConnection conn_act = new(Globals.ConnectionString());
                conn_act.Open();
                NpgsqlCommand com_act = new(script_actions, conn_act);
                com_act.ExecuteNonQuery();
                conn_act.Close();

                return "Migração efetuada com sucesso.";
            }
            catch(Exception e){
                return "Ocorreu um erro: " + e;
            }
        }
    }
}