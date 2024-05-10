using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Socialite.Api.SignalR.Interfaces;
using Socialite.Api.SignalR.Models;

namespace Socialite.Api.SignalR.Hubs;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ChatHub : Hub<IChatClient>
{
    public async Task Register()
    {
        await Clients.All.ReceiveMessage("Этот пидр нажал на кнопку");
    }
    
    public async Task JoinChat(ChatConnection chatConnection)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatConnection.ChatId.ToString());
        
        await Clients
            .Group(chatConnection.ChatId.ToString())
            .ReceiveMessage("Здрасьте забор покрасьте");
    }

    public async Task SuggestAChat(ChatConnection chatConnection)
    {
        await Clients.User("ilklmkn").ReceiveMessage("Вам предложили чат)");
    }

    public override Task OnConnectedAsync()
    {
        string name = Context.User.Identity.Name;

        Groups.AddToGroupAsync(Context.ConnectionId, name);

        return base.OnConnectedAsync();
    }
}