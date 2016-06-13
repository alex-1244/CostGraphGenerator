using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphGenerator
{
    class Program
    {
        private static int[,] flows;
        private static int[,] costs;
        static void Main(string[] args)
        {
            int size = 1000;
            if (args.Length > 0)
            {
                try
                {
                    size = Int32.Parse(args[0]);
                    if (size <= 0)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Argument must be positiva integer");
                }
            }
            generateData(size);
            WriteData();
        }

        private static void WriteData()
        {
            StreamWriter sw = new StreamWriter("result"+Guid.NewGuid()+".csv");
            for (int i = 0; i < flows.GetLength(0); i++)
            {
                var line = "";
                for (int j = 0; j < flows.GetLength(0); j++)
                {
                    line += flows[i, j] + ",";
                }
                line = line.Trim(',');
                sw.WriteLine(line);
            }
            sw.WriteLine("");
            for (int i = 0; i < costs.GetLength(0); i++)
            {
                var line = "";
                for (int j = 0; j < costs.GetLength(0); j++)
                {
                    line += costs[i, j] + ",";
                }
                line = line.Trim(',');
                sw.WriteLine(line);
            }
            sw.Close();
        }

        private static void generateData(int size)
        {
            int[,] flowsTmp = new int[size, size];
            int[,] costsTmp = new int[size, size];
            Random r = new Random();
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    flowsTmp[i, j] = r.Next(1, 1000);
                    costsTmp[i, j] = r.Next(0, 100);
                    if (i == j)
                    {
                        flowsTmp[i, j] = 0;
                        costsTmp[i, j] = 0;
                    }
                }
            }
            flows = flowsTmp;
            costs = costsTmp;
        }
    }
}
