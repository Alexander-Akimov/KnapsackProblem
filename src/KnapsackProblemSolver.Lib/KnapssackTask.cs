using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblemSolver.Lib
{
    public class KnapssackTask
    {
        public int MaxWeight { get; set; }

        public int MaxValue { get; private set; }

        public List<Item> Items { get; private set; }

        private int[,] A;

        public List<Item> Ans { get; private set; } = new List<Item>();

        public List<int> AnsInt { get; private set; } = new List<int>();

        public KnapssackTask(List<Item> items, int maxWeight)
        {
            if (items == null || maxWeight <= 0)
                throw new ArgumentException("Invalid Argumets");

            this.Items = items;
            this.MaxWeight = maxWeight;
            A = new int[Items.Count + 1, MaxWeight + 1];
        }
        public List<Item> Solve()
        {
            this.Sort();
            for (int i = 0; i <= MaxWeight; i++)
                A[0, i] = 0;

            for (int i = 0; i <= Items.Count; i++)
                A[i, 0] = 0;

            for (int k = 1; k <= Items.Count; k++)
            {
                for (int s = 1; s <= MaxWeight; s++)
                {
                    var item = Items[k - 1];
                    if (s >= item.Weight)
                        A[k, s] = (A[k - 1, s]) > (A[k - 1, s - item.Weight] + item.Value) ?
                        (A[k - 1, s]) : (A[k - 1, s - item.Weight] + item.Value);
                    else
                        A[k, s] = A[k - 1, s];
                    Console.Write(A[k, s] + " ");
                }
                Console.WriteLine();
            }

            FindAns(Items.Count, MaxWeight);
            return Ans;
        }

        private int GetMaxValue()
        {
            return Ans.Sum(item => item.Value);
        }
        private void Sort()
        {
            var items = Items.OrderBy(item => item.Weight).ToList();
            Items.Clear();
            Items.AddRange(items);
        }

        private void FindAns(int k, int s)
        {
            if (A[k, s] == 0)
                return;
            if (A[k - 1, s] == A[k, s])
                FindAns(k - 1, s);
            else
            {
                FindAns(k - 1, s - Items[k - 1].Weight);
                Ans.Add(Items[k - 1]);
                MaxValue += Items[k - 1].Value;
            }
        }
    }
}
