using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class Address
    {
        [Key]
        public int Addressid { get; set; }

        public string line { get; set; }

        public string city { get; set; }

        public int userId { get; set; }

        public User? user { get; set; }
    }
}
