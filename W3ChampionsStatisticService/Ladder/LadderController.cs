﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using W3ChampionsStatisticService.Matches;
using W3ChampionsStatisticService.PlayerProfiles;
using W3ChampionsStatisticService.Ports;

namespace W3ChampionsStatisticService.Ladder
{
    [ApiController]
    [Route("api/ladder")]
    public class LadderController : ControllerBase
    {
        private readonly IRankRepository _rankRepository;

        public LadderController(
            IRankRepository rankRepository)
        {
            _rankRepository = rankRepository;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPlayer(string searchFor, GateWay gateWay = GateWay.Europe, GameMode gameMode = GameMode.GM_1v1)
        {
            var players = await _rankRepository.SearchPlayerOfLeague(searchFor, gateWay, gameMode);
            return Ok(players);
        }

        [HttpGet("{leagueId}")]
        public async Task<IActionResult> GetLadder([FromRoute] int leagueId, [FromRoute] int season, GateWay gateWay = GateWay.Europe, GameMode gameMode = GameMode.GM_1v1)
        {
            var playersInLadder = await _rankRepository.LoadPlayersOfLeague(leagueId, season, gateWay, gameMode);
            if (playersInLadder == null)
            {
                return NoContent();
            }

            return Ok(playersInLadder);
        }

        [HttpGet("league-constellation")]
        public async Task<IActionResult> GetLeagueConstellation([FromRoute] int season)
        {
            var leagues = await _rankRepository.LoadLeagueConstellation(season);
            return Ok(leagues);
        }
    }
}