using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDemo.WebApi.Models
{
    public class User
    {
        public User(string name, DateTime birthday)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Birthday = birthday;
        }

        [Key] public string Id { get; private set; }

        [Required] public string Name { get; private set; }

        [DataType(DataType.Date)] public DateTime Birthday { get; private set; }
    }
}