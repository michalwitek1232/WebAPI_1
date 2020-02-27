using System;

namespace WebAPI_1.Models
{
    public class ProfileImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime AddedDate{ get; set; }
        public bool IsMain { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}