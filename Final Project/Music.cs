using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Music : IOrganize
    {
        private String id;

        private String title;

        private String description;

        private String genre;

        private String length;

        private String artist;

        private String actors;

        private String year;

        private String publisher;

        private String location;

        private String format;

        private String size;

        public String Title
        {
            get { return title; }
            set
            {
                if (value.Length == 0)
                {
                    throw new Exception("Title cannot be blank");
                }

                title = value;
            }
        }

        public String Description { get; set; }
        public String Genre { get; set; }
        public String Length { get; set; }
        public String Artist { get; set; }
        public String Actors { get; set; }
        public String Year { get; set; }
        public String Publisher { get; set; }
        public String Location { get; set; }
        public String Format { get; set; }
        public String Size { get; set; }

        public IOrganize Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IOrganize Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

    }
}
