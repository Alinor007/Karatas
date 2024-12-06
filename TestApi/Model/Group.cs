using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace TestApi.Model
{
    public class Group
       
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
