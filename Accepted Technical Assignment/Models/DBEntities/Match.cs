using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Accepted_Technical_Assignment.Models.DBEntities
{
    public class Match
    {
        public Match()
        {
            MatchOdds = new HashSet<MatchOdd>();
        }

        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? MatchDate { get; set; }
        public virtual TimeSpan? MatchTime { get; set; }
        public virtual string TeamA { get; set; }
        public virtual string TeamB { get; set; }
        public virtual int? Sport { get; set; }

        public virtual ICollection<MatchOdd> MatchOdds { get; set; }
    }

    public enum Sports
    {
        Football = 1,
        Basketball = 2
    }
}