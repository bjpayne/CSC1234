using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaManager
{
    public class Music : Media
    {
        public const String Category = "music";

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<KeyValuePair<String, String>> metaData;
        public List<KeyValuePair<String, String>> MetaData
        {
            get => metaData;
            set => metaData = value;
        }
    }
}