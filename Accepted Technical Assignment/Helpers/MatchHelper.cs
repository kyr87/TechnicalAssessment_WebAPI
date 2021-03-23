using Accepted_Technical_Assignment.GenericRepository;
using Accepted_Technical_Assignment.Models.DBEntities;
using Accepted_Technical_Assignment.Models.PostModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Accepted_Technical_Assignment.Helpers
{
    public class MatchHelper : IDisposable
    {
        private readonly SportBetContext _dbcontext;
        private readonly IRepository<Match> _matchRepository;
        private readonly IRepository<MatchOdd> _oddRepository;

        public MatchHelper(SportBetContext dbcontext, IRepository<Match> matchRepository, IRepository<MatchOdd> oddRepository)
        {
            _dbcontext = dbcontext;
            _oddRepository = oddRepository;
            _matchRepository = matchRepository;
        }

        public async Task<PostMatch> InsertMatchWithOdd(PostMatch model)
        {
            using var transaction = _dbcontext.Database.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                Match match = new Match
                {
                    Description = model.Description,
                    MatchDate = model.MatchDate,
                    MatchTime = model.MatchTime,
                    TeamA = model.TeamA,
                    TeamB = model.TeamB,
                    Sport = model.Sport
                };

                _dbcontext.Matches.Add(match);
                await _dbcontext.SaveChangesAsync();

                MatchOdd odd = new MatchOdd
                {
                    MatchId = match.Id,
                    Specifier = model.Specifier,
                    Odd = model.Odd
                };

                _dbcontext.MatchOdds.Add(odd);
                await _dbcontext.SaveChangesAsync();

                transaction.Commit();

                return model;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return null;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UserHelper() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
    }
}
