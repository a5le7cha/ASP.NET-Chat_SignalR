﻿using Microsoft.AspNetCore.SignalR;

namespace ASP.NET_SignalR
{
    public class ChatHub : Hub
    {
        public async Task Send(string message, string userName)
        {
            await this.Clients.All.SendAsync("Receive", message, userName);
        }
    }
}