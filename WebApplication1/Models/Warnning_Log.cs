using System.ComponentModel.DataAnnotations;

namespace Book_Web.Models
{
    public class Warnning_Log
    {
        public int Id { get; set; }
        public string? Log { get; set; }
        public DateTime Time { get; set; }
    }
}
