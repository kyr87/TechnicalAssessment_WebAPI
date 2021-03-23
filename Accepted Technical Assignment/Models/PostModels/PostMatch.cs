using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accepted_Technical_Assignment.Models.PostModels
{
    public class PostMatch
    {
        [Required]
        public string Description { get; set; }
        public DateTime? MatchDate { get; set; }
        public TimeSpan? MatchTime { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        [Required]
        public int? Sport { get; set; }
        public int? MatchId { get; set; }
        [Required]
        public string Specifier { get; set; }
        [Required]
        public decimal? Odd { get; set; }
    }
}
