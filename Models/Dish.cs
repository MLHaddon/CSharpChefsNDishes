using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishID {get; set;}

        [Required]
        [Display(Name = "Dish Name")]
        public string Name {get; set;}

        [Required]
        [Range(1, 10000)]
        [Display(Name ="# of Calories")]
        public int Calories {get; set;}
        
        [Required]
        [Display(Name = "Description")]
        public string Desc {get; set;}
        public int ChefId {get; set;}

        [Display(Name ="Chef")]
        public Chef ChefOfDish {get; set;}

        [Required]
        [Range(1, 5)]
        public int Tastiness {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;

        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}