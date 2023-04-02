using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] Array1 = StringExtensions.getMatrix("..\\..\\input1.txt");
            int[,] Array2 = StringExtensions.getMatrix("..\\..\\input2.txt");
            int NumHigh1 = StringExtensions.getCount(Array1);
            int NumHigh2 = StringExtensions.getCount(Array2);
            if (NumHigh1<= NumHigh2)
            {
                StringExtensions.calc(Array1, Array2, NumHigh1);
            }
            else
            {
                StringExtensions.calc(Array2, Array1, NumHigh2);
            }
            Console.ReadKey();  
        }
    }
}
public static class StringExtensions
{
   public static int[,] getMatrix(string path)
    {
        StreamReader file = new StreamReader(path);
        int n = int.Parse(file.ReadLine());
        int[,] array = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                { array[i, j] = int.Parse(file.ReadLine()); }
            }
        }
        return array;
    }
    public static int getCount(int[,] array)
    {
        int i, j, count = 0;
        for (i = 0; i < array.GetLength(0); i++)
        {
            for (j = 0; j < array.GetLength(1) - i; j++)
            {
                if (array[array.GetLength(0) - i - 1, array.GetLength(1) - j - 1] > 0)
                { count++; }
            }
        }
        return count;
    }
    public static void calc(int[,] array1, int[,] array2, int a)
    {
        int i, j;

        for (i = 0; i < array2.GetLength(0); i++)
        {
            for (j = 0; j < array2.GetLength(1); j++)
            {
                array2[i, j] *= a;
            }
        }
        for (i = 0; i < array1.GetLength(0); i++)
        {
            for (j = 0; j < array1.GetLength(1); j++)
            {
                array1[i, j] += array2[i, j];
            }
        }
            StreamWriter file = new StreamWriter("..\\..\\result.txt");
            for (i = 0; i < array1.GetLength(0); i++)
                for (j = 0; j < array1.GetLength(1); j++)
                    file.WriteLine(array1[i, j]);
            file.Close();
    }
}