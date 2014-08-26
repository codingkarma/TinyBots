using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TinyBots
{
    public class BotHub : Hub
    {
        public void SendMessage(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
        public void Attack(int damage)
        {
            //Clients.All.hello();
            Clients.All.broadcastAttack(damage);
        }
    }
}