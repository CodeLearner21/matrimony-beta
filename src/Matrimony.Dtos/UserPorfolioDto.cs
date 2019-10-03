using Matrimony.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Dtos
{
    public class UserPorfolioDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public PortfolioType PortfolioType { get; set; }
    }
}
