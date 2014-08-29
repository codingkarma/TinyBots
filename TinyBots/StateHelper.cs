using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyBots.Models;

namespace TinyBots
{
    public static class StateHelper
    {
        private static List<Game> Games = new List<Game>();

        public static Game Join(Robot robot)
        {
            if(Games.Count > 0 && Games[Games.Count-1].Robots.Count == 1)
            {
                //TODO: FIX THIS HACK
                robot.id = 2;
                Games[Games.Count - 1].Robots.Add(robot);
                return Games[Games.Count - 1];
            }
            //If we dont have any games with only one person in them, go ahead and create a new game and add it to our state
            Games.Add(new Game()
                {
                    GameId = Games.Count,
                    Robots = new List<Robot>() {robot}
                });
            return Games[Games.Count - 1];
        }
        public static bool Ready(int gameId)
        {
            return Games.First(x => x.GameId == gameId).Robots.Count == 2;
        }
    }
}
