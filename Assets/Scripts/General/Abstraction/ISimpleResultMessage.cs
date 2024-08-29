using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.General.Abstraction
{
    public interface ISimpleResultMessage
    {
        //
        // Summary:
        //     The type of the messages
        public enum MessageTypeEnum
        {
            Information,
            Warning,
            Error,
            Success
        }

        //
        // Summary:
        //     The type of the message
        MessageTypeEnum MessageType { get; set; }

        //
        // Summary:
        //     The string message.
        string Message { get; set; }
    }
}
