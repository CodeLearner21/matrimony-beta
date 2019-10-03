using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Matrimony.Dtos
{
    public class CreatePortfolioDto
    {
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Birth date is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "User id is missing")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please select any portfolio type")]
        public int PortfolioTypeId { get; set; }
    }
}
