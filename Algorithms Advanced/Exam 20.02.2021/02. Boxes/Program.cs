namespace _02._Boxes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public class Box
        {
            public int Width { get; set; }

            public int Depth { get; set; }

            public int Height { get; set; }

            public override string ToString()
            {
                return $"{this.Width} {this.Depth} {this.Height}";
            }
        }

        static void Main(string[] args)
        {
            var linesCount = int.Parse(Console.ReadLine());
            var boxes = new List<Box>();

            for (int i = 0; i < linesCount; i++)
            {
                var box = Console.ReadLine().Split().Select(int.Parse).ToArray();

                boxes.Add(new Box
                {
                    Width = box[0],
                    Depth = box[1],
                    Height = box[2],
                });
            }

            var len = new int[boxes.Count];
            var prev = new int[boxes.Count];

            var bestLen = 0;
            var lastIndex = 0;

            for (int i = 0; i < boxes.Count; i++)
            {
                prev[i] = -1;

                var currNumber = boxes[i];
                var currBestSeq = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevNumber = boxes[j];

                    if (prevNumber.Width < currNumber.Width &&
                        prevNumber.Depth < currNumber.Depth && 
                        prevNumber.Height < currNumber.Height && 
                        len[j] + 1 >= currBestSeq)
                    {
                        currBestSeq = len[j] + 1;
                        prev[i] = j;
                    }
                }

                if (currBestSeq > bestLen)
                {
                    bestLen = currBestSeq;
                    lastIndex = i;
                }

                len[i] = currBestSeq;
            }

            var stack = new Stack<Box>();

            while (lastIndex != -1)
            {
                stack.Push(boxes[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
