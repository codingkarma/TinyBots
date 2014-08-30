using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace TinyBots
{
    public class BotHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.Caller.onConnect();
            Clients.Caller.broadcastMessage("SERVER", "Welcome to TinyBots, Attack will enable when two users join simulataneously.  Open another browser window to test");
            return base.OnConnected();
        }
        public void SendMessage(string name, string message)
        {
            var user = Clients.Caller.user;
            Clients.All.broadcastMessage(name, message);
        }
        public void Attack(Robot attacker, Robot defender)
        {
            Clients.Group(attacker.gameId.ToString()).broadcastAttack(attacker, defender);
        }
        public void Join(Robot player)
        {
            var joinedGame = StateHelper.Join(player);
            player.gameId = joinedGame.GameId;
            Groups.Add(Context.ConnectionId, joinedGame.GameId.ToString());
            Clients.All.createPlayer(player);
            if(StateHelper.Ready(joinedGame.GameId))
            {
                Clients.All.createPlayer(joinedGame.Robots[0]);
                Clients.All.enablePlay();
            }
        }
    }
}