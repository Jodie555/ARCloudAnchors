using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.General.Abstraction
{
    public interface ISimpleResultPayload<TPayload> : ISimpleResultPayloadExtensions
    {

        //
        // Summary:
        //     The payload of the result.
        TPayload Payload { get; }

        //
        // Summary:
        //     The payload of the result.
        TPayload Value { get; }
    }
}
