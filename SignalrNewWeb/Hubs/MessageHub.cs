using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalrNewWeb.Hubs
{

    class MessageHub : Hub
    {
        public async Task SendToAll( string user , string message) => await Clients.All.SendAsync("RecieveMessage" ,user , message );
        

    }
}