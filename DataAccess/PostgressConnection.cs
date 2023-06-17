using Dapper;
using MiniProjektSQL.Models;
using Npgsql;
using System.Configuration;
using System.Data;

namespace MiniProjektSQL
{

    class PostgressConnection
    {
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        internal static List<UserModels> LoadUser()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModels>("SELECT * FROM mob_person").ToList();
                return output;
            }
        }

        internal static List<ProjektModel> LoadProject()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjektModel>("SELECT * FROM mob_project").ToList();
                return output;
            }
        }

        internal static List<SQLProjektPerson> LoadProjectAndPerson()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SQLProjektPerson>("SELECT * FROM mob_project_person").ToList();
                return output;
            }
        }

        public static int GetUserIdByName(string name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>($"SELECT id FROM mob_person WHERE person_name = @Name", new { Name = name });
                return output;
            }
        }

        public static int GetProjectIdByName(string name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>($"SELECT id FROM mob_project WHERE project_name = @Name", new { Name = name });
                return output;
            }
        }

        public static void CreateNewUser(string person_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO mob_person (person_name) VALUES (@Name)", new { Name = person_name });
            }
        }

        public static void UpdateNewUser(int old_id, string new_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE mob_person SET person_name = @NewName WHERE id = @OldId", new { NewName = new_name, OldId = old_id });
            }
        }

        public static void CreateNewProject(string project_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO mob_project (project_name) VALUES (@Name)", new { Name = project_name });
            }
        }

        public static void UpdateNewProject(int old_id, string new_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE mob_project SET project_name = @NewName WHERE id = @OldId", new { NewName = new_name, OldId = old_id });
            }
        }

        public static void TimeReport(int project_id, int person_id, int hours_worked)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO mob_project_person (project_id, person_id, hours) VALUES (@ProjectId, @PersonId, @Hours)", new { ProjectId = project_id, PersonId = person_id, Hours = hours_worked });
            }
        }

        public static void UpdateProjectPerson(int id, int hours)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE mob_project_person SET hours = @Hours WHERE id = @Id", new { Hours = hours, Id = id });
            }
        }
    }
}

