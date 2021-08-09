namespace TheReadingClub
{
    public class ProjectConstants
    {
        public const string AdminRole = "Admin";
        public const string AdminName = "Admin@reading.com";
        public const string AdminEmail = "Admin@reading.com";
        public const string AdminFullName = "Administrator";
        public const string AdminPassword = "Admin12";

        public const string ModeratorRole = "Moderator";

        public const int AuthorNameMaxLenght = 100;
        public const int AuthorNameMinLenght = 2;
        public const string AuthorNameRegex = "[A-Za-z ']*";

        public const int BookTitleMaxLenght = 100;
        public const int BookTitleMinLenght = 2;
        public const int BookDescriptionMaxLenght = 500;
        public const int BookDescriptionMinLenght = 50;
        public const string BookTitleRegex = "[А-Яа-яA-Za-z. ']*";
        public const string BookYearRegex = "[0-9]{4}";

        public const int GenreNameMaxLenght = 50;

        public const int UserFullNameMaxLenght = 100;
    }
}
