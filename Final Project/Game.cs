using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Game : IOrganize
    { 
        private String typeId;

        private String title;

        private String description;

        private String genre;

        private String length;

        private String artist;

        private String cost;

        private String dateReleased;

        private String publisher;

        private String location;

        private String format;

        private String size;

        public String TypeId { get; set; }

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
        public String Artists { get; set; }
        public String Cost { get; set; }
        public String DateReleased { get; set; }
        public String Publisher { get; set; }
        public String Location { get; set; }
        public String Format { get; set; }
        public String Size { get; set; }
    }
}
