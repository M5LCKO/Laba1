using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Laba_1
{
    class SpaseBall
    {
        private int min = 1;
        private int max = 50;

        private int length;

        private bool state = true;

        private int free;

        private ArrayList array = new ArrayList();

        public SpaseBall(int length)
        {
            this.length = length;
            free = length;
        }

        public SpaseBall(int length, bool state)
        {
            this.length = length;
            free = length;
            this.state = state;
        }
        public SpaseBall(int length, int min, int max)
        {
            this.length = length;
            free = length;
            this.min = min;
            this.max = max;
        }

        public SpaseBall(int length, int min, int max, bool state)
        {
            this.length = length;
            free = length;
            this.min = min;
            this.max = max;
            this.state = state;
        }

        private void genFirst()
        {
            Random rnd = new Random();
            array.Add(min + rnd.Next(max));
            free--;
        }

        private void genSequence(int first, int length)
        {
            if (free < length)
                length = free;

            Random rnd = new Random();

            if (state)
            {
                for (int i = first; i < first + length; i++)
                {
                    array.Add((int)array[i] + (min + rnd.Next(max)));
                }
            }
            else
            {
                for (int i = first; i < first + length; i++)
                {
                    array.Add((int)array[i] - (min + rnd.Next(max)));
                }
            }

            free -= length;
            state = !state;
        }

        public ArrayList genArray()
        {
            genFirst();

            Random rnd = new Random();

            while(free > 0)
            {
                genSequence(array.Count - 1, rnd.Next(length / 4) + 3);
            }

            return array;
        }
    }
}
