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
        public static GameState GetState()
        {
            if(gameState != null)
            {
                gameState = new GameState();
                return gameState;
            }
            return gameState;
        }
        public static void AddRobot(RobotModel robot)
        {
            if(gameState.playerOne == null)
            {
                gameState.playerOne = robot;
            }
            else if(gameState.playerTwo == null)
            {
                gameState.playerTwo = robot;
            }
        }

        public static bool Ready()
        {
            return gameState.playerOne != null && gameState.playerTwo != null;
        }
    }
}
