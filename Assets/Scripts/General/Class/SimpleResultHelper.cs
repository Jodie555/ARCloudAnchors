using Assets.Scripts.General.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.General.Class
{
    public sealed class SimpleResultHelper
    {
        public static void AddFailedMessage(ref ISimpleResult simpleResult, string message)
        {
            simpleResult.Success = false;
            if (message.Trim().Length > 0)
            {
                simpleResult.Messages.Add(new SimpleResultMessage(ISimpleResultMessage.MessageTypeEnum.Error, message));
            }
        }

        public static void AddFailedMessages(ref ISimpleResult simpleResult, List<string> messages)
        {
            foreach (string message in messages)
            {
                simpleResult.AddFailedMessage(message);
            }
        }

        public static void AddInformationMessage(ref ISimpleResult simpleResult, string message)
        {
            if (message.Trim().Length > 0)
            {
                simpleResult.Messages.Add(new SimpleResultMessage(ISimpleResultMessage.MessageTypeEnum.Information, message));
            }
        }

        public static void AddSuccessMessage(ref ISimpleResult simpleResult, string message)
        {
            if (message.Trim().Length > 0)
            {
                simpleResult.Messages.Add(new SimpleResultMessage(ISimpleResultMessage.MessageTypeEnum.Success, message));
            }
        }

        public static void AddWarningMessage(ref ISimpleResult simpleResult, string message)
        {
            if (message.Trim().Length > 0)
            {
                simpleResult.Messages.Add(new SimpleResultMessage(ISimpleResultMessage.MessageTypeEnum.Warning, message));
            }
        }

        public static void AddMessagesAndSetFailedIfErrorFound(ref ISimpleResult simpleResult, ISimpleResult suppliedSimpleResult)
        {
            if (!suppliedSimpleResult.Success)
            {
                simpleResult.Success = false;
            }

            AddMessagesAndSetFailedIfErrorFound(ref simpleResult, suppliedSimpleResult.Messages);
        }

        public static void AddMessagesAndSetFailedIfErrorFound(ref ISimpleResult simpleResult, List<ISimpleResultMessage> messages)
        {
            foreach (ISimpleResultMessage message in messages)
            {
                if (message.MessageType == ISimpleResultMessage.MessageTypeEnum.Error)
                {
                    simpleResult.Success = false;
                }
            }

            simpleResult.Messages.AddRange(messages);
        }

        public static List<string> GetSimpleMessages(ref ISimpleResult simpleResult)
        {
            List<string> list = new List<string>();
            foreach (ISimpleResultMessage message in simpleResult.Messages)
            {
                list.Add(message.Message);
            }

            return list;
        }
    }
}
