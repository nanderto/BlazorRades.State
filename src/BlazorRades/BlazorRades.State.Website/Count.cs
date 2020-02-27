using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRades.State.Website
{
    public class Count
    {

        public Count(int count)
        {
            Current = count;
        }

        public int Current { get; set; }
    }
}
