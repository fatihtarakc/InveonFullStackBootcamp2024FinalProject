namespace InveonCourseApp.Backend.Core.Utilities.Helpers
{
    public static class HelperCharacter
    {
        private static char[] upperCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static char[] lowerCharacters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static char[] turkishCharacters = { 'ç', 'Ç', 'ğ', 'Ğ', 'ı', 'İ', 'ö', 'Ö', 'ş', 'Ş', 'ü', 'Ü' };
        private static char[] digits = "0123456789".ToCharArray();
        private static char[] symbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', ']', '{', '}', '\\', '|', ';', ':', '\'', '\"', ',', '.', '<', '>', '/', '?', '`', '~' };
        public static bool UpperCharacterInclude(string input) =>
            string.IsNullOrWhiteSpace(input) is true ? false : input.Any(character => upperCharacters.Contains(character));

        public static bool UpperCharacterNotInclude(string input) =>
            string.IsNullOrWhiteSpace(input) is true ? true : !input.Any(character => upperCharacters.Contains(character));

        public static bool LowerCharacterInclude(string input) =>
            string.IsNullOrWhiteSpace(input) is true ? false : input.Any(character => lowerCharacters.Contains(character));

        public static bool LowerCharacterNotInclude(string input) =>
            string.IsNullOrWhiteSpace(input) is true ? true : !input.Any(character => lowerCharacters.Contains(character));

        public static bool TRCharacterInclude(string input) =>
            string.IsNullOrWhiteSpace(input) is true ? false : input.Any(character => turkishCharacters.Contains(character));

        public static bool TRCharacterNotInclude(string input) =>
            string.IsNullOrWhiteSpace(input) is true ? true : !input.Any(character => turkishCharacters.Contains(character));

        public static bool DigitInclude(string input) =>
            string.IsNullOrWhiteSpace(input) is true ? false : input.Any(character => digits.Contains(character));

        public static bool DigitNotInclude(string input) =>
            string.IsNullOrWhiteSpace(input) is true ? true : !input.Any(character => digits.Contains(character));

        public static bool SymbolInclude(string input) =>
            string.IsNullOrWhiteSpace(input) is true ? false : input.Any(character => symbols.Contains(character));

        public static bool SymbolNotInclude(string input) =>
            string.IsNullOrWhiteSpace(input) is true ? true : !input.Any(character => symbols.Contains(character));
    }
}