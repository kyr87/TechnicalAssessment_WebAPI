using Accepted_Technical_Assignment.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accepted_Technical_Assignment.Models.PutModels
{
    public class PutMatch:Match
    {
        [Required]
        public override int Id { get => base.Id; set => base.Id = value; }
        [Required]
        public override string Description { get => base.Description; set => base.Description = value; }
        [Required]
        public override DateTime? MatchDate { get => base.MatchDate; set => base.MatchDate = value; }
        [Required]
        public override int? Sport { get => base.Sport; set => base.Sport = value; }
    }
}
