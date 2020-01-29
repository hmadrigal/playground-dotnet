using System;
using System.Collections.Generic;
using System.Text;

namespace Workbench.Parsers
{
    // Determines the sub parts of a query that can be parsed individually.
    public enum MySQLParseUnit
    {
        PuGeneric,
        PuCreateSchema,
        PuCreateTable,
        PuCreateTrigger,
        PuCreateView,
        PuCreateFunction,
        PuCreateProcedure,
        PuCreateRoutine, // Compatibility enum for function/procedure/UDF, deprecated.
        PuCreateUdf,
        PuCreateEvent,
        PuCreateIndex,
        PuGrant,
        PuDataType,
        PuCreateLogfileGroup,
        PuCreateServer,
        PuCreateTablespace,
    }
}
