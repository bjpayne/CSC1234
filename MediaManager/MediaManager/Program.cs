using System;
using System.Collections.Generic;

namespace MediaManager
{
    class Program
    {
        static void Main(String[] args)
        {
            // get meta data from the database with column headings as the key
            // and column values as the pair
            List<KeyValuePair<String, String>> metaData = new List<KeyValuePair<String, String>>
            {
                new KeyValuePair<String, String>("id", "1"),
                new KeyValuePair<String, String>("title", "Sound of Silence"),
                new KeyValuePair<String, String>("description", "Song"),
                new KeyValuePair<String, String>("genre", "Folk Rock"),
                new KeyValuePair<String, String>("length", "3:05"),
                new KeyValuePair<String, String>("artist", "Simon & Garfunkle"),
                new KeyValuePair<String, String>("actors", ""),
                new KeyValuePair<String, String>("cost", "2.99"),
                new KeyValuePair<String, String>("year", "1965"),
                new KeyValuePair<String, String>("publisher", "Columbia Records"),
                new KeyValuePair<String, String>("location", "Los Angeles, CA"),
                new KeyValuePair<String, String>("format", "Digital"),
                new KeyValuePair<String, String>("size", "12MB")
            };

            Music soundOfSilence = new Music {MetaData = metaData};

            try
            {
                soundOfSilence.Play();
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine("Music played");
            }
        }
    }
}
