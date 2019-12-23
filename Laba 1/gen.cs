using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Laba_1
{
    class gen
    {
        public static ArrayList Gen(int itemCount)
        {
            ArrayList myAL = new ArrayList();
            
            if (itemCount > 0)
            {
                Random rnd1 = new Random();
                int number;
                int index;
                for (index = 1; index <= itemCount; index++)
                {
                    number = -100 + rnd1.Next(200);
                    myAL.Add(number);
                }
            }
            return myAL;
        }
    }
}
