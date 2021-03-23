using Accepted_Technical_Assignment.GenericRepository;
using Accepted_Technical_Assignment.Helpers;
using Accepted_Technical_Assignment.Models.DBEntities;
using Accepted_Technical_Assignment.Models.PostModels;
using Accepted_Technical_Assignment.Models.PutModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accepted_Technical_Assignment.Controllers
{
    [Route("api/match")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly SportBetContext _dbcontext;
        private readonly IRepository<Match> _matchRepository;
        private readonly IRepository<MatchOdd> _oddRepository;

        public MatchesController(SportBetContext dbcontext, IRepository<Match> matchRepository, IRepository<MatchOdd> oddRepository)
        {
            _dbcontext = dbcontext;
            _oddRepository = oddRepository;
            _matchRepository = matchRepository;
        }

        /// <summary>
        /// Returns all matches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 120, Location = ResponseCacheLocation.Client)]
        [ProducesResponseType(typeof(List<Match>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Match>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Match>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMatches()
        {
            var matches = await _matchRepository.GetAll();

            return Ok(matches);
        }

        /// <summary>
        /// Inserts a match with odd
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(Match), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Match), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Match), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Match), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateMatch([FromBody]PostMatch model)
        {
            using MatchHelper mh = new MatchHelper(_dbcontext, _matchRepository, _oddRepository);

            if (ModelState.IsValid)
            {
                //model.MatchDate = DateTime.Today;
                //model.MatchTime = DateTime.Now.TimeOfDay;
                //model.Sport = (int)Sports.Football;
                return Ok(await mh.InsertMatchWithOdd(model));
            }
            else
                return BadRequest(ModelState);
        }

        /// <summary>
        /// Updates a match
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        [ProducesResponseType(typeof(Match), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Match), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Match), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Match), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateMatch([FromBody] PutMatch model)
        {
            if (ModelState.IsValid)
            {
                var selected = await _matchRepository.GetById(model.Id);

                if (selected == null)
                    return NotFound();

                var match = await _matchRepository.Update(model);
                return Ok(match);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Removes a match
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _matchRepository.Delete(id);

            return Ok(match);
        }

        /// <summary>
        /// Returns all match odds
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("odds")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 120, Location = ResponseCacheLocation.Client)]
        [ProducesResponseType(typeof(List<MatchOdd>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<MatchOdd>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<MatchOdd>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMatchOdds()
        {
            var odds = await _oddRepository.GetAll();

            return Ok(odds);
        }

        /// <summary>
        /// Inserts a match odd
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("odd")]
        [ProducesResponseType(typeof(MatchOdd), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MatchOdd), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(MatchOdd), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MatchOdd), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateMatchOdd([FromBody] PostMatchOdd model)
        {
            if (ModelState.IsValid)
            {
                var odd = await _oddRepository.Insert(model);

                return Ok(odd);
            }
            else
                return BadRequest(ModelState);
        }

        /// <summary>
        /// Updates a match odd
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("odd")]
        [ProducesResponseType(typeof(MatchOdd), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MatchOdd), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(MatchOdd), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MatchOdd), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateMatchOdd([FromBody] PutMatchOdd model)
        {
            if (ModelState.IsValid)
            {
                var selected = await _oddRepository.GetById(model.Id);

                if (selected == null)
                    return NotFound();
                        
                var odd = await _oddRepository.Update(model);
                return Ok(odd);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Removes a match odd
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("odd/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMatchOdd(int id)
        {
            var odd = await _oddRepository.Delete(id);

            return Ok(odd);
        }

    }
}
