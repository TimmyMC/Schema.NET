namespace Schema.NET;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

internal sealed class IValuesDebugView
{
    private readonly IEnumerable<object> collection;

    public IValuesDebugView(IEnumerable<object> collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        this.collection = collection;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public object[] Items => this.collection.ToArray();
}

