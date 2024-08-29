using Assets.Scripts.General.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.General.Class
{
    public class SimpleResultMessage : ISimpleResultMessage
    {
        public ISimpleResultMessage.MessageTypeEnum MessageType { get; set; }

        public string Message { get; set; }

        public SimpleResultMessage(ISimpleResultMessage.MessageTypeEnum messageType, string message)
        {
            MessageType = messageType;
            Message = message;
        }
    }
}
