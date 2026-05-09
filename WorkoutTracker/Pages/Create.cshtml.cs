using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using static WorkoutTracker.Pages.LoginModel;

namespace WorkoutTracker.Pages
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string workoutname, int duration, int calories, DateTime workoutdate)
        {
            string connection = "server=localhost;port=1108;database=workoutdb;user=root;";

            MySqlConnection conn = new MySqlConnection(connection);

            conn.Open();

            string query = "INSERT INTO workouts(workoutname,duration,calories,workoutdate,username) VALUES(@w,@d,@c,@date,@u)";
            

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@u", SessionData.currentUser);
            cmd.Parameters.AddWithValue("@workoutname", workoutname);
            cmd.Parameters.AddWithValue("@duration", duration);
            cmd.Parameters.AddWithValue("@calories", calories);
            cmd.Parameters.AddWithValue("@workoutdate", workoutdate);

            cmd.ExecuteNonQuery();

            conn.Close();

            return RedirectToPage("Index");
        }
    }
}