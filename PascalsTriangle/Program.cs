using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalsTriangle
{
    public static class StringExtensions
    {
        public static string PadBoth(this string str, int length)
        {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft).PadRight(length);
        }
    }
    public class Solution
    {
        public IList<int> GenerateNextRow(IList<int> baseRow)
        {
            if ((baseRow == null)||!baseRow.Any()) return new List<int>() {1};
            var length = baseRow.Count;
            var ret= new List<int>(length + 1) {1};
            for ( var i = 1;i<length;i++) ret.Add(baseRow[i-1]+ baseRow[i]);
            ret.Add(1);
            return ret;
        }
            public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> ret = new List<IList<int>>(numRows);
            IList<int> prev = null;
            for (int i = 0; i < numRows; i++) 
            {
                prev = GenerateNextRow(prev);
                ret.Add(prev);
            }
            return ret;
                
        }
        public void Show(IList<IList<int>> triangle,int scrL=80,int scrH=40) 
        {
            int longestNumber=triangle.Max(r => r.Max(e => e.ToString().Length));
            var strings=triangle.Select(r => string.Join(",", r.Select(e => e.ToString().PadLeft(longestNumber))).PadBoth(scrL));
            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }
            //StringBuilder sb =new StringBuilder();

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var s=new Solution();
            s.Show(s.Generate(3));
            Console.ReadLine();
        }
    }
}
