namespace country_info_app.server.validation
{
    public static class IsoCodeValidator
    {
        public static bool IsValid(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return false;
            }

            code = code.Trim();
            if (code.Length < 2 || code.Length > 3)
            {
                return false;
            }

            return code.All(char.IsLetter);
        }
    }
}