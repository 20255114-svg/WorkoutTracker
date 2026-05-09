using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace WorkoutTracker.Pages
{
    public class LoginModel : PageModel
    {
        public string message = "";

        public void OnGet()
        {
        }

        public static class SessionData
        {
            public static string currentUser = "";
        }
        public IActionResult OnPost(string username, string password)
        {
            string connStr = "server=localhost;port=1108;database=workoutdb;user=root;;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = "SELECT * FROM users WHERE username=@username AND password=@password";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                SessionData.currentUser = username; // 👈 TRACK USER
                conn.Close();
                return RedirectToPage("Index");
            }

            conn.Close();
            message = "Invalid login";
            return Page();
        }
    }
}