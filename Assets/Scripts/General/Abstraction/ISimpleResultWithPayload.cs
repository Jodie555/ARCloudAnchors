using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.General.Abstraction
{
    public interface ISimpleResultWithPayload<TPayload> : ISimpleResult, ISimpleResultPayload<TPayload>
    {
        //
        // Summary:
        //     Adds the messages in the result to this result and will set SparkStandard.Result.Abstractions.ISimpleResult.Success
        //     = False if messages are SparkStandard.Result.Abstractions.Components.ISimpleResultMessage.MessageTypeEnum.Error.
        //     The payload will also be set, if you do not want to do this then use SparkStandard.Result.Abstractions.ISimpleResult.AddMessagesAndSetFailedIfErrorFound(System.Collections.Generic.List{SparkStandard.Result.Abstractions.Components.ISimpleResultMessage}).
        //
        //
        // Parameters:
        //   simpleResultWithPayload:
        void AddMessagesAndSetFailedIfErrorFound(ISimpleResultWithPayload<TPayload> simpleResultWithPayload);
    }
}
