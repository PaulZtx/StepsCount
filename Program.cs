using System;
using System.Text.RegularExpressions;

namespace FolderLinks
{
    class Program
    {
        public static void Main()
        {
            List<string[]> ops = new List<string[]>();
            ops.Add(new []{"d1/","d2/","../","d21/","./"});
            ops.Add(new []{"d13232/","d213/","d3/","d21/","./"});
            ops.Add(new []{"../","../","../","../","../"});
            Console.WriteLine(MinStepsToMain(ops[2]));
        }


        public static int MinStepsToMain(string []ops)
        {
            string pattern = @"([a-z]+\/)|(\d+\/)|([a-z]+\d+\/)";
            int stepsCount = 0;
            for (int i = 0; i < ops.Length; ++i)
            {
                switch(ops[i])
                {
                    case "./":
                        break;
                    case "../":
                        if(stepsCount > 0)
                            stepsCount--;
                        break;
                    //default case could be without regular expressions,
                    //but if the user makes a mistake, then there is a check
                    default:
                        
                        if (Regex.IsMatch(ops[i], pattern))
                            stepsCount++;
                        break;
                }
            }

            return stepsCount;
        }
    }
}
