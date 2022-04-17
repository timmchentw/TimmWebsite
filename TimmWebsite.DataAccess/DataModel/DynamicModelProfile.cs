using System;

namespace TimmWebsite.DataAccess.DataModel
{
    public class Profile_Portfolio
    {
        public int Seq { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public DateTime Timestamp { get; set; }
        public string Tags { get; set; }
    }
}