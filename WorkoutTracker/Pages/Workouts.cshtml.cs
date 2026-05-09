using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkoutTracker.Pages
{
    public class WorkoutsModel : PageModel
    {
        [BindProperty]
        public string WorkoutName { get; set; }
        [BindProperty]
        public int Duration { get; set; }

        public static List<string> Workouts { get; set; } = new List<string>();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            // Just store in memory for now (no database)
            Workouts.Add($"{WorkoutName} - {Duration} mins");
            return Page();
        }
    }
}
