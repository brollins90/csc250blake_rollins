using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(new Solution().S("ban{1,3} {0,6}"));
        //string input = Console.ReadLine(); // read from standard input

        //Console.WriteLine(new Solution().S(input)); // write to standard output
    }

    string S(string s)
    {
        string ret = "";

        int index = 0;
        Stack<char> = new Stack<char>();



        //        while (index < s.Length)
        //        {
        //            char[] chars = s.ToCharArray();
        //            char cur = chars[index];
        //            if (cur == '{') {
        //                index++;
        //                string temp = s.Substring(index);
        //                int newIndex = temp.IndexOf(',');
        //                int i1 = int.Parse(temp.Substring(0, newIndex));
        //                int endIndex = temp.IndexOf('}');
        //                int i2 = int.Parse(temp.Substring(newIndex + 1, endIndex - (newIndex + 1)));

        //                string nextPiece = s.Substring(i1, i2);

        //                bool done = false;

        //                while (!done)
        //                {

        //                    int braceindex = nextPiece.IndexOf('{');
        //                    if (braceindex == -1) {
        //                        ret += nextPiece;
        //                        done = true;
        //                    } else {

        //                        int howMuchMore = nextPiece.Substring(braceindex).Length;


        //                    }
        //                }


        //                    while (howMuchMore > 0)
        //                    {
        //                        string more = nextPiece.Substring(0, howMuchMore);
        //                        howMuchMore = more.IndexOf('{');
        //                        if (howMuchMore == -1)
        //                        {
        //                            ret += nextPiece;
        //                            ret += more;
        //                        }
        //                    }
        //                    string morePiece = "";
        //                } else {
        //                    ret += nextPiece;
        //                }

        //                index = index + endIndex;
        //            } else {
        //                ret += chars[index];
        //            }
        //            index++;
        //        }
        //        return ret;
        //    }
        //}
    }
}
