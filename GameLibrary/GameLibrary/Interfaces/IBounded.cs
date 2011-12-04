using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Interfaces
{
    public interface IBounded
    {
        float left { get; set; }
        float right { get; set; }
        float top { get; set; }
        float bottom { get; set; }
    }
}
