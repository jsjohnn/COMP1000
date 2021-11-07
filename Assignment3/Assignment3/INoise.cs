using System;
using System.Diagnostics;
using System.Linq;
using System.Collections;
namespace Assignment3
{
    public interface INoise
    {
        int GetNext(int level);
    }
}