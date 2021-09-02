using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public static class Utility
    {
        public static void Swap(List<int> values, int i, int j)
        {
            values[i] = values[i] + values[j];
            values[j] = values[i] - values[j];
            values[i] = values[i] - values[j];
        }
        // What is Log N ? Log(base 2) N => e.g Log(base 2) 16 = 4 => how many times do you divide 16 by 2 till you get 1
        //2^ 4 = 16 => Log2 16 = 4
    }
}
