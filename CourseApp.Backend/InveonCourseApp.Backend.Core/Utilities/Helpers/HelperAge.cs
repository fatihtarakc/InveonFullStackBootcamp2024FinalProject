namespace InveonCourseApp.Backend.Core.Utilities.Helpers
{
    public static class HelperAge
    {
        public static bool StudentControl(DateTime birthdate)
        {
            var today = DateTime.Today;

            var age = today.Year - birthdate.Year;

            if (birthdate.Date > today.AddYears(-age)) age--;

            return age >= 7;
        }

        public static bool TrainerControl(DateTime birthdate)
        {
            var today = DateTime.Today;

            var age = today.Year - birthdate.Year;

            if (birthdate.Date > today.AddYears(-age)) age--;

            return age >= 18;
        }
    }
}