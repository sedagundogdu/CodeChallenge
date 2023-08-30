using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodeChallenge.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlayersController : ControllerBase
	{

		[HttpGet("{totalPlayers}")]
		public ActionResult<int> GetAlgorithm(int totalPlayers)
		{
			if (totalPlayers <= 0)
			{
				return BadRequest("Number of players cannot be zero or less than 0 !!!");
			}

			int number = totalPlayers; 
			int skip = 1; //count of people to be skipped
						  
			

			List<int> player = new List<int>();

			for (int i = 1; i <= number; i++) 
			{
				player.Add(i);
			}

			int index = 0;

			Algorithm(player, skip, index);

			return Ok(player[0]);
			// return HTTP 200 response
			// operation was successful and returning player[0] as the response content
		}

		private void Algorithm(List<int> player, int skip, int index)
		{
			if (player.Count == 1) // in the game, when only 1 player left
			{
				return;
			}

			index = ((index + skip) % player.Count); // player.count is remaining players

			player.RemoveAt(index); 

			Algorithm(player, skip, index);
		}

	}
}
