using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1
{
    class abs
    {
        static public void Gen_int(List<int> myAL, int itemCount)
        {

            int index;
            Random rnd1 = new Random();
            int number;

            for (index = 1; index <= itemCount; index++)
            {
                number = -100 + rnd1.Next(200);
                myAL.Add(number);
            }
        }

        static public void But_7(List<int> myAL, List<int> myAL1, int itemCount)
        {

            int sum = 0, Sr, Sr1, A;


            for (int i = 0; i < itemCount; i++)
            {
                sum += myAL[i];
            }

            Sr = sum / itemCount;


            for (int i = 0; i < itemCount; i++)
            {
                A = myAL[i];
                myAL1.Add(Sr - A);
            }

            for (int i = 0; i < itemCount; i++)
            {
                sum += myAL1[i];
            }

            Sr1 = sum / itemCount;

            for (int i = 0; i < itemCount; i++)
            {
                if (myAL1[i] > Sr1 / 2) myAL[i] = Sr;
            }

        }

        static public void But_8(List<int> myAL, List<int> myAL1, int itemCount, int l)
        {

            int sum = 0, sum1 = 0, Sr, Sr1, A;


            for (int i = 0; i < itemCount; i++)
            {
                sum += myAL[i];
            }

            Sr = sum / itemCount;


            for (int i = 0; i < itemCount; i++)
            {
                A = myAL[i];
                myAL1.Add(Sr - A);
            }

            for (int i = 0; i < itemCount; i++)
            {
                sum1 += myAL1[i];
            }

            Sr1 = sum1 / itemCount;



            for (int i = 0; i < itemCount; i++)
            {
                if (myAL1[i] > Sr1 * l / 100) myAL[i] = Sr;

            }

        }

        static public void But_9(List<int> myAL, List<int> myAL1, int itemCount, int l, int z)
        {

            int sum = 0, sum1 = 0, Sr, Sr1, A;

            for (int i = 0; i < itemCount; i++)
            {
                sum += myAL[i];
            }

            Sr = sum / itemCount;


            for (int i = 0; i < itemCount; i++)
            {
                A = myAL[i];
                myAL1.Add(Sr - A);

            }

            for (int i = 0; i < itemCount; i++)
            {
                sum1 += myAL1[i];
            }

            Sr1 = sum1 / itemCount;

            for (int i = 0; i < itemCount; i++)
            {
                if (myAL1[i] > Sr1 * l / 100) myAL[i] = z;
            }
        }

        static public void But_otr_7(List<int> myAL, List<int> myAL1, int a, int b)
        {

            int sum = 0, Sr, Sr1, A;


            for (int i = a; i < b; i++)
            {
                sum += myAL[i];
            }

            Sr = sum / b - a;


            for (int i = a; i < b; i++)
            {
                A = myAL[i];
                myAL1.Add(Sr - A);
            }

            for (int i = a; i < b; i++)
            {
                sum += myAL1[i];
            }

            Sr1 = sum / b - a;

            for (int i = a; i < b; i++)
            {
                if (myAL1[i] > Sr1 / 2) myAL1[i] = Sr;
            }

        }

        static public void But_otr_8(List<int> myAL, List<int> myAL1, int l, int a, int b)
        {

            int sum = 0, sum1 = 0, Sr, Sr1, A;


            for (int i = a; i < b; i++)
            {
                sum += myAL[i];
            }

            Sr = sum / b - a;


            for (int i = a; i < b; i++)
            {
                A = myAL[i];
                myAL1.Add(Sr - A);
            }

            for (int i = a; i < b; i++)
            {
                sum1 += myAL1[i];
            }

            Sr1 = sum1 / b - a;


            for (int i = a; i < b; i++)
            {
                if (myAL1[i] > Sr1 * l / 100) myAL1[i] = Sr;

            }

        }

        static public void But_otr_9(List<int> myAL, List<int> myAL1, int l, int z, int a, int b)
        {

            int sum = 0, sum1 = 0, Sr, Sr1, A;

            for (int i = a; i < b; i++)
            {
                sum += myAL[i];
            }

            Sr = sum / b - a;


            for (int i = a; i < b; i++)
            {
                A = myAL[i];
                myAL1.Add(Sr - A);

            }

            for (int i = a; i < b; i++)
            {
                sum1 += myAL1[i];
            }

            Sr1 = sum1 / b - a;

            for (int i = a; i < b; i++)
            {
                if (myAL1[i] > Sr1 * l / 100) myAL1[i] = z;
            }
        }

        static public void But_norm(List<int> myAL, List<int> myAL1, int itemCount, int KolPart, int l, int z)
        {

            int Q = itemCount / KolPart;
            int Q1 = itemCount / KolPart;
            int W = itemCount - Q*KolPart;
            int F = 1;
            int i;

            while (Q > 0)
            {
                for (i = 0; i < KolPart; i += KolPart)
                {
                    if (F == 1)
                    {
                        But_otr_7(myAL, myAL1, i, i + KolPart);
                       
                        Q--;
                        if (Q>0) F = 2;
                    }
                    if (F == 2)
                    {
                        But_otr_8(myAL, myAL1, l, i, i + KolPart);
                              Q--;
                        if (Q > 0) F = 3;
                    }
                    if (F == 3)
                    {
                        But_otr_9(myAL, myAL1, l, z, i, i + KolPart);
                                               Q--;
                        if (Q > 0) F = 1;
                    }
                }
                
            }

            i = Q1 * KolPart;
            if (F == 1)
            {
                But_otr_7(myAL, myAL1, i, i + W);
                W--;
                if (W>0) F = 2;
            }
            if (F == 2)
            {
                But_otr_8(myAL, myAL1, l, i, i + W);
                W--;
                if (W > 0) F = 3;
            }
            if (F == 3)
            {
                But_otr_9(myAL, myAL1, l, z, i, i + W);
                W--;
                if (W > 0) F = 1;
            }
        }
    }
}
