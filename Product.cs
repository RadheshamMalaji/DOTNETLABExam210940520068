using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabExam210940520068.Models
{
    public class Product
    {
        [Key]
        [DisplayName("Product Id")]
        public int ProductId { set; get; }

        [DataType(DataType.Text)]
        [DisplayName("Product Name")]
        [Required(ErrorMessage ="Enter Valid Product Name")]
        public string ProductName { set; get; }

        [DisplayName("Rate")]
        [Range(0.0,500.00,ErrorMessage ="Enter Rate Between 0 to 500")]
        public decimal Rate { set; get; }

        [DisplayName("Description")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Description")]
        public string Description { set; get; }

        [DisplayName("Category Name")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Enter CategoryName")]
        public string CategoryName { set; get; }
    }
}