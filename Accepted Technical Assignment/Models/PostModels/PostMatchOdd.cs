using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accepted_Technical_Assignment.Models.PostModels
{
    public class PostMatchOdd: DBEntities.MatchOdd
    {
        [Required]
        public override string Specifier { get => base.Specifier; set => base.Specifier = value; }
        [Required]
        public override decimal? Odd { get => base.Odd; set => base.Odd = value; }
    }
}
