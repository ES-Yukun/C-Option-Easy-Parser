using System;
using System.Collections.Generic;
using System.Linq;

namespace DockerCDR
{
    class Program
    {

        static void Main(string[] args)
        {
        }
        static Dictionary<string, string[]> optionParser(string[] args)
        {
            Dictionary<string, string[]> Parsed = new Dictionary<string, string[]>();
            string parentTmp = "";
            string[] childTmp = new string[] { };
            foreach (string i in args) if (i.StartsWith("-"))
                {
                    if (i.StartsWith("--")) parentTmp = i.Remove(0, 2);
                    //else if (i.StartsWith("-")) parentTmp = i.Remove(0, 1);
                    Parsed.Add(parentTmp, new string[] { });
                    childTmp = new string[] { };
                }
                else
                {
                    if (parentTmp != "")
                    {
                        childTmp = childTmp.Concat(new string[] { i }).ToArray();
                        Parsed[parentTmp] = childTmp;
                    }
                }
            return Parsed;
        }
    }
}
