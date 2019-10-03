using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Matrimony.Database.Entities
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        
        public int PortfolioTypeId { get; set; }
        [ForeignKey("PortfolioTypeId")]
        public PortfolioType PortfolioType { get; set; }
    }
}
