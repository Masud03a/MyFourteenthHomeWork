using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task_14
{
    class Program
    {
        delegate T Operation<T, K, O>(O val1, K val2);

        static T Plus<T>(T val1, T val2)
        {
            return (dynamic)val1 + (dynamic)val2;
        }

        static T Minus<T>(T val1, T val2)
        {
            return (dynamic)val1 - (dynamic)val2;
        }

        static T Multiplication<T>(T val1, T val2)
        {
            return (dynamic)val1 * (dynamic)val2;
        }

        static T Division<T>(T val1, T val2)
        {
            if((dynamic)val2 == 0)
                throw new DivideByZeroException();
            else
                return (dynamic)val1 / (dynamic)val2;
        }
        
    }
}


