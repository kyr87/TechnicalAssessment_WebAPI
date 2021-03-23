using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Accepted_Technical_Assignment.Models.DBEntities
{
    public class MatchOdd
    {
        public virtual int Id { get; set; }
        public virtual int? MatchId { get; set; }
        public virtual string Specifier { get; set; }
        public virtual decimal? Odd { get; set; }

        public virtual Match Match { get; set; }
    }
}