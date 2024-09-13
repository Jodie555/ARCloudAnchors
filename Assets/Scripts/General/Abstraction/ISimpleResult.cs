using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.General.Abstraction
{
    public interface ISimpleResult
    {
        //
        // Summary:
        //     All of the messages in the result.
        List<ISimpleResultMessage> Messages { get; }

        //
        // Summary:
        //     Flag to show if successful.
        bool Success { get; set; }

        //
        // Summary:
        //     Add a message with the status of SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.Success.
        //
        //
        // Parameters:
        //   message:
        void AddSuccessMessage(string message);

        //
        // Summary:
        //     Add messages with the status of SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.Success.
        //
        //
        // Parameters:
        //   messages:
        void AddSuccessMessages(List<string> messages);

        //
        // Summary:
        //     Add a message with the status of SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.Information.
        //
        //
        // Parameters:
        //   message:
        void AddInformationMessage(string message);

        //
        // Summary:
        //     Add messages with the status of SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.Information.
        //
        //
        // Parameters:
        //   messages:
        void AddInformationMessages(List<string> messages);

        //
        // Summary:
        //     Add a message with the status of SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.Warning.
        //
        //
        // Parameters:
        //   message:
        void AddWarningMessage(string message);

        //
        // Summary:
        //     Add messages with the status of SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.Warning.
        //
        //
        // Parameters:
        //   messages:
        void AddWarningMessages(List<string> messages);

        //
        // Summary:
        //     Add a message with the status of SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.Error.
        //
        //
        // Parameters:
        //   message:
        void AddFailedMessage(string message);

        //
        // Summary:
        //     Add messages with the status of SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.Error.
        //
        //
        // Parameters:
        //   messages:
        void AddFailedMessages(List<string> messages);

        //
        // Summary:
        //     Adds the messages to this result and will set SparkStandard.Result.Abstractions.ISimpleResult.Success
        //     = False if messages are SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.Error.
        //
        //
        // Parameters:
        //   messages:
        void AddMessagesAndSetFailedIfErrorFound(List<ISimpleResultMessage> messages);

        //
        // Summary:
        //     Adds the messages in the result to this result and will set SparkStandard.Result.Abstractions.ISimpleResult.Success
        //     = False if messages are SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.Error.
        //
        //
        // Parameters:
        //   simpleResult:
        void AddMessagesAndSetFailedIfErrorFound(ISimpleResult simpleResult);

        //
        // Summary:
        //     Gets the messages in the result as strings regardless of SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.
        List<string> GetSimpleMessages();
    }
}
