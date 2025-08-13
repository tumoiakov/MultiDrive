namespace MultiDrive.Database
{
    internal class Constants
    {
        public const string DBFilename = "MultidriveDB.db3";
        public static string DBPath => Path.Combine(FileSystem.AppDataDirectory, DBFilename);
    }
}