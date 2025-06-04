using Microsoft.AspNetCore.SignalR;

namespace Blog_System.SignalRHub
{
    public class NotifyHub : Hub
    {
        public async Task SendNotification(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", user, message);
        }
    }
}
