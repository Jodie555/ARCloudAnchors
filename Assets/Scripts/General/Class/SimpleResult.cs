using Assets.Scripts.General.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.General.Class
{
    public class SimpleResult : ISimpleResult
    {
        public bool Success { get; set; }

        public List<ISimpleResultMessage> Messages { get; set; }

        //
        // Summary:
        //     Create a new SparkStandard.Result.SimpleResult.
        public SimpleResult()
        {
            Success = true;
            Messages = new List<ISimpleResultMessage>();
        }

        //
        // Summary:
        //     Create a new SparkStandard.Result.SimpleResult from another one.
        //
        // Parameters:
        //   result:
        public SimpleResult(ISimpleResult result)
            : this()
        {
            AddMessagesAndSetFailedIfErrorFound(result);
        }

        public void AddInformationMessage(string message)
        {
            ISimpleResult simpleResult = this;
            SimpleResultHelper.AddInformationMessage(ref simpleResult, message);
        }

        void ISimpleResult.AddInformationMessage(string message)
        {
            //ILSpy generated this explicit interface implementation from .override directive in AddInformationMessage
            this.AddInformationMessage(message);
        }

        public void AddWarningMessage(string message)
        {
            ISimpleResult simpleResult = this;
            SimpleResultHelper.AddWarningMessage(ref simpleResult, message);
        }

        void ISimpleResult.AddWarningMessage(string message)
        {
            //ILSpy generated this explicit interface implementation from .override directive in AddWarningMessage
            this.AddWarningMessage(message);
        }

        public void AddFailedMessage(string message)
        {
            ISimpleResult simpleResult = this;
            SimpleResultHelper.AddFailedMessage(ref simpleResult, message);
        }

        void ISimpleResult.AddFailedMessage(string message)
        {
            //ILSpy generated this explicit interface implementation from .override directive in AddFailedMessage
            this.AddFailedMessage(message);
        }

        public void AddMessagesAndSetFailedIfErrorFound(List<ISimpleResultMessage> messages)
        {
            ISimpleResult simpleResult = this;
            SimpleResultHelper.AddMessagesAndSetFailedIfErrorFound(ref simpleResult, messages);
        }

        void ISimpleResult.AddMessagesAndSetFailedIfErrorFound(List<ISimpleResultMessage> messages)
        {
            //ILSpy generated this explicit interface implementation from .override directive in AddMessagesAndSetFailedIfErrorFound
            this.AddMessagesAndSetFailedIfErrorFound(messages);
        }

        public void AddMessagesAndSetFailedIfErrorFound(ISimpleResult simpleResult)
        {
            ISimpleResult simpleResult2 = this;
            SimpleResultHelper.AddMessagesAndSetFailedIfErrorFound(ref simpleResult2, simpleResult);
        }

        void ISimpleResult.AddMessagesAndSetFailedIfErrorFound(ISimpleResult simpleResult)
        {
            //ILSpy generated this explicit interface implementation from .override directive in AddMessagesAndSetFailedIfErrorFound
            this.AddMessagesAndSetFailedIfErrorFound(simpleResult);
        }

        public void AddFailedMessages(List<string> messages)
        {
            ISimpleResult simpleResult = this;
            SimpleResultHelper.AddFailedMessages(ref simpleResult, messages);
        }

        void ISimpleResult.AddFailedMessages(List<string> messages)
        {
            //ILSpy generated this explicit interface implementation from .override directive in AddFailedMessages
            this.AddFailedMessages(messages);
        }

        public void AddInformationMessages(List<string> messages)
        {
            foreach (string message in messages)
            {
                ISimpleResult simpleResult = this;
                SimpleResultHelper.AddInformationMessage(ref simpleResult, message);
            }
        }

        void ISimpleResult.AddInformationMessages(List<string> messages)
        {
            //ILSpy generated this explicit interface implementation from .override directive in AddInformationMessages
            this.AddInformationMessages(messages);
        }

        public void AddWarningMessages(List<string> messages)
        {
            foreach (string message in messages)
            {
                ISimpleResult simpleResult = this;
                SimpleResultHelper.AddWarningMessage(ref simpleResult, message);
            }
        }

        void ISimpleResult.AddWarningMessages(List<string> messages)
        {
            //ILSpy generated this explicit interface implementation from .override directive in AddWarningMessages
            this.AddWarningMessages(messages);
        }

        public void AddSuccessMessage(string message)
        {
            ISimpleResult simpleResult = this;
            SimpleResultHelper.AddSuccessMessage(ref simpleResult, message);
        }

        void ISimpleResult.AddSuccessMessage(string message)
        {
            //ILSpy generated this explicit interface implementation from .override directive in AddSuccessMessage
            this.AddSuccessMessage(message);
        }

        public void AddSuccessMessages(List<string> messages)
        {
            foreach (string message in messages)
            {
                ISimpleResult simpleResult = this;
                SimpleResultHelper.AddSuccessMessage(ref simpleResult, message);
            }
        }

        void ISimpleResult.AddSuccessMessages(List<string> messages)
        {
            //ILSpy generated this explicit interface implementation from .override directive in AddSuccessMessages
            this.AddSuccessMessages(messages);
        }

        public List<string> GetSimpleMessages()
        {
            ISimpleResult simpleResult = this;
            return SimpleResultHelper.GetSimpleMessages(ref simpleResult);
        }

        List<string> ISimpleResult.GetSimpleMessages()
        {
            //ILSpy generated this explicit interface implementation from .override directive in GetSimpleMessages
            return this.GetSimpleMessages();
        }
    }
}