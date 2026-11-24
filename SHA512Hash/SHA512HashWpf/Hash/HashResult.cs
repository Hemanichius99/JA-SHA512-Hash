using System;
using System.Collections.Generic;
using System.Text;

namespace SHA512HashWpf.Hash
{
    public record HashResult(
        string Hash,
        float TimeInMilliseconds
    )
    {
    }
}
