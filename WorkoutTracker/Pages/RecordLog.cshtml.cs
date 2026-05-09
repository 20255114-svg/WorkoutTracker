using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace WorkoutTracker.Pages
{
    public class RecordLogModel : PageModel
    {
        public List<string> Users { get; set; } = new List<string>();

        public void OnGet()
        {
            string connStr = "server=localhost;port=1108;database=workoutdb;user=root;";
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            string query = "SELECT username, password FROM users";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string username = reader.IsDBNull(0) ? "(no username)" : reader.GetString(0);
                string password = reader.IsDBNull(1) ? "(no password)" : reader.GetString(1);

                Users.Add($"{username} - {password}");
            }
        }
    }
}

