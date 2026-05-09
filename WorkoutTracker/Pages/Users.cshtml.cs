using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Data;

namespace WorkoutTracker.Pages
{
    public class UsersModel : PageModel
    {
        public List<string> users = new List<string>();

        public void OnGet()
        {
            string connStr = "server=localhost;port=1108;database=workoutdb;user=root;;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = "SELECT username FROM users";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(reader.GetString(0));
            }

            conn.Close();
        }
    }
}