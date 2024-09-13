using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.General.Abstraction
{
    public interface ISimpleResultPayloadExtensions
    {
        //
        // Summary:
        //     Check to see if a payload is null (nothing).
        bool PayloadIsNull { get; }

        //
        // Summary:
        //     Check to see if a payload is the default value.
        //
        // Returns:
        //     For System.Objects this will be the same as SparkStandard.Result.Abstractions.Components.ISimpleResultPayloadExtensions.PayloadIsNull.
        //     For types like System.Int32 this will return True where the value is 0.
        bool PayloadIsDefault { get; }

        //
        // Summary:
        //     This will check if the result is successful and the payload is not null.
        bool SuccessAndNotNull { get; }

        //
        // Summary:
        //     This will check if the result is successful and the payload is not the default
        //     value.
        bool SuccessAndNotDefault { get; }
    }
}
