using System.ComponentModel.DataAnnotations;

namespace TestApi.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
