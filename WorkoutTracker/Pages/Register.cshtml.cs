using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace WorkoutTracker.Pages
{
    public class RegisterModel : PageModel
    {
        public string message = "";

        public void OnGet() { }

        public IActionResult OnPost(string username, string password)
        {
            string connStr = "server=localhost;port=1108;database=workoutdb;user=root;;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            // check duplicate
            string check = "SELECT * FROM users WHERE username=@username";
            MySqlCommand checkCmd = new MySqlCommand(check, conn);
            checkCmd.Parameters.AddWithValue("@username", username);

            var reader = checkCmd.ExecuteReader();

            if (reader.Read())
            {
                conn.Close();
                message = "Username already exists!";
                return Page();
            }

            conn.Close();
            conn.Open();

            string insert = "INSERT INTO users(username,password) VALUES(@username,@password)";
            MySqlCommand cmd = new MySqlCommand(insert, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();

            conn.Close();

            return RedirectToPage("Login");
        }
    }
}