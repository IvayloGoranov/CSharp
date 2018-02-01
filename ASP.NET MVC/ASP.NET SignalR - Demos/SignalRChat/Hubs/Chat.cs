using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRChat.Hubs
{
    public class Chat : Hub
    {
        public void SendMessage(string message)
        {
            var msg = string.Format("{0}: {1}", Context.ConnectionId, message);
            this.Clients.All.addMessage(msg);
        }

        public void JoinRoom(string room)
        {
            this.Groups.Add(Context.ConnectionId, room);
            this.Clients.Caller.joinRoom(room);
        }

        public void SendMessageToRoom(string message, string[] rooms)
        {
            var msg = string.Format("{0}: {1}", Context.ConnectionId, message);

            for (int i = 0; i < rooms.Length; i++)
            {
                this.Clients.Group(rooms[i]).addMessage(msg);
            }
        }
    }
}