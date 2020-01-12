using System;
using System.IO;

namespace OhMySky
{
    public static class Constants
    {
        public static string NasaApiEndpoint = "https://api.nasa.gov/neo/rest/v1/feed";
        public static string NasaPictureOfTheDayEndpoint = "https://api.nasa.gov/planetary/apod";
        public static string APIKey = "nW9v8esVn2HGad3ZCZpWhXcDyJdZmDj1glAxzc94";
        public const string DatabaseFilename = "OhMySkySQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            { 
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                Console.WriteLine(basePath);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}