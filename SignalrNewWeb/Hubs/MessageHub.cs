using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalrNewWeb.Hubs
{

    class MessageHub : Hub
    {
        public async Task SendToAll(  string message) => await Clients.All.SendAsync("RecieveMessage", message );
        

    }
}