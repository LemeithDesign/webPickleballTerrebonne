using Microsoft.AspNetCore.SignalR;

namespace web_PickleballTerrebonne.Hubs
{
    public class ListeAttenteHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            HttpContext? httpContext = Context.GetHttpContext();
            string? userId = httpContext?.Request.Cookies["UserId"];

            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userId);
            }

            await base.OnConnectedAsync();
        }
    }
}