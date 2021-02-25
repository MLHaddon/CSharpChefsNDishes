using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefID {get; set;}

        [Required]
        [Display(Name ="First Name")]
        public string FirstName {get; set;}

        [Required]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}

        [Required(ErrorMessage = "Date of Birth Required")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth {get; set;}
        public List<Dish> ChefDishes {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}