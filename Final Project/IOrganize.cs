using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    interface IOrganize
    {
        String TypeId { get; set; }
        String Title { get; set; }
        String Description { get; set; }
        String Genre { get; set; }
        String Length { get; set; }
        String Artists { get; set; }
        String Cost { get; set;}
        String DateReleased { get; set; }
        String Publisher { get; set; }
        String Location { get; set; }
        String Format { get; set; }
        String Size { get; set; }
    }
}
