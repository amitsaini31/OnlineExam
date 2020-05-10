using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OnlineExamWeb.Hubs
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

    public class ChatHub : Hub
    {
        static int Temperature;
        [HubMethodName("change_weather")]
        public void ChangeWeather(int temperature)
        {
            Temperature = temperature;

            Clients.Others.NotifyUser(temperature);

        }

        [HubMethodName("get_weather")]
        public void GetWeather()
        {
            Clients.Caller.NotifyUser(Temperature);
        }

        [HubMethodName("get_id")]
        public void GetConnectionId()
        {
            Clients.Caller.GetID(Context.ConnectionId);
        }

        public override Task OnConnected()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool flag)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnected(flag);
        }

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}