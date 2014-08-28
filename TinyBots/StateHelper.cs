using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyBots.Models;

namespace TinyBots
{
    public static class StateHelper
    {
        private static GameState gameState = new GameState();

        public static void AddRobot(RobotModel robot)
        {
            gameState.Robots.Add(robot);
        }

        public static bool Ready()
        {
            return gameState.Robots.Count >= 2;
        }
    }
}
