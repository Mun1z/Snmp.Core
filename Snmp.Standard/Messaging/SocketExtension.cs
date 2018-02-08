﻿using System.Net.Sockets;

namespace Snmp.Standard.Messaging
{
    internal static class SocketExtension
    {
        public static SocketAwaitable ReceiveAsync(this Socket socket,
            SocketAwaitable awaitable)
        {
            awaitable.Reset();
            if (!socket.ReceiveAsync(awaitable.m_eventArgs))
                awaitable.m_wasCompleted = true;
            return awaitable;
        }

        public static SocketAwaitable SendToAsync(this Socket socket,
            SocketAwaitable awaitable)
        {
            awaitable.Reset();
            if (!socket.SendToAsync(awaitable.m_eventArgs))
                awaitable.m_wasCompleted = true;
            return awaitable;
        }

        internal static readonly SocketAsyncEventArgsFactory EventArgsFactory = new SocketAsyncEventArgsFactory();
    }
}
