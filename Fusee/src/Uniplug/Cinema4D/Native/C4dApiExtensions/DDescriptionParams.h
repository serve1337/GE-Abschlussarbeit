#pragma once
#include "c4d_nodedata.h"


// We need this construction because SWIG is unable to handle the reference on enum parameters
// (e.g. the DESCFLAGS_DESC &flags parameter in GetDDescruption)  in the 
// original ObjectData class gracefully. The desirable solution would have been if SWIG 
// just mapped those C++ references (&) to a C# ref or out parameter - this seems to be impossible
// at least if the class is used as a director. Thus we generate wrapper classes for those parameters.
// At the same time we pack all parameters of those functions together ino a single class.

class DDescriptionParams
{
public:
	Description *Desc;
	DESCFLAGS_DESC Flags;
};


