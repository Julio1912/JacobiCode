using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jacobi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Math.Sqrt(2) / 2 * Math.Sqrt(2) / 2);
            Double[,] Matrix = { 
                               {4,2},
                               {2,4}
                               };
            Jacobi jacobi = new Jacobi(Matrix);
            Matrix=jacobi.Algorithm();
            Jacobi j = new Jacobi(Matrix);
            Matrix = j.Algorithm();
            for (int i = 0; i < Matrix.GetLength(0); i++)
                for (int k = 0; k < Matrix.GetLength(1); k++)
                    Console.WriteLine(Matrix[i, k]);
            Console.ReadKey();
        }
    }
}
