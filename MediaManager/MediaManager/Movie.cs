using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaManager
{
    public class Movie : Media
    {
        public const String Category = "movie";
        
        private List<KeyValuePair<String, String>> metaData;

        public List<KeyValuePair<String, String>> MetaData
        {
            get => metaData;
            set => metaData = value;
        }
    }
}