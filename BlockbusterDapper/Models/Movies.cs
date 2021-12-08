using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterDapper.Models
{
    public class Movies
    {
        /*
        id int not null auto_increment primary key, 
        `name` nvarchar(50) not null, 
         `genre` nvarchar(20) not null,
         `year` int, 
         runtime time
         */
        [Key]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Name of movie must be at least 50 characters")] //i didn't know how to fix the SQL requirements to make this 30 so just ran with 50
        public string Name { get; set; }
        public string Genre { get; set; }
        [Range(1880, 2021, ErrorMessage = "Movie must be between the years 1880 and 2021.")]
        public int Year { get; set; }
        public DateTime Runtime { get; set; }
    }
}
