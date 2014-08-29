using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TinyBots.Models
{
    public class Game
    {
        public int GameId;
        public List<Robot> Robots = new List<Robot>();
    }
}