using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace TinyBots.Data
{
    public static class DataHelper
    {
        public static Robot GetRobot(int robotId)
        {
            using(var context = new TinyBotsEntities())
            {
                return context.Robots.ToList().FirstOrDefault(x => x.RobotId == robotId);
            }
          
        }
    }
}
