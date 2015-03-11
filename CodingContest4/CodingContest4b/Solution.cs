using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public static void Main(string[] args)
    {
        //string input = Console.ReadLine(); // read from standard input

        //Console.WriteLine(new Solution().Go(input));


        Console.WriteLine(new Solution().Go("a2 * a3,b2 + 4,a2 - 7,a1 + a3 + b2 + c1,5,a1 * 3,b3 * 2,b3 * c1,c2 - 9")); //18,9,2,133,5,54,108,5832,5823
        Console.WriteLine(new Solution().Go("a1,a2,a3,b1,b2,b3,c1,c2,c3")); // cycle
        Console.WriteLine(new Solution().Go("a2 - 1,a3 - 1,b1 - 1,b2 - 1,b3 - 1,c1 - 1,c2 - 1,c3 - 1,9")); // 1,2,3,4,5,6,7,8,9
    }

    static string[,] holder = new string[3, 3];

    void Init()
    {
        // init
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                PutInSpot(row, col,"");
            }
        }
    }

    void PutInSpot(int row, int col, string s)
    {
        holder[row, col] = s;
    }

    string GetFromSpot(int row, int col)
    {
        return holder[row, col];
    }

    string GetFromSpot(string s)
    {
        if (s.Length == 2)
        {
            int row = int.Parse(s[1].ToString());
            int col = int.Parse((s[0] - 'a').ToString());
            return holder[row, col];
        }
        else
        {
            throw new Exception();
        }
    }

    public string Go(string input)
    {

        string retVal = "";
        Init();

        string[] cellList = input.Split(',');

        PutInSpot(0, 0, cellList[0]);
        PutInSpot(1, 0, cellList[1]);
        PutInSpot(2, 0, cellList[2]);
        PutInSpot(0, 1, cellList[3]);
        PutInSpot(1, 1, cellList[4]);
        PutInSpot(2, 1, cellList[5]);
        PutInSpot(0, 2, cellList[6]);
        PutInSpot(1, 2, cellList[7]);
        PutInSpot(2, 2, cellList[8]);
        
        // round 1
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                int t = 0;
                if (int.TryParse(GetFromSpot(row,col), out t))
                {
                    PutInSpot(row,col,t.ToString());
                }
                //string cell = Solve(s);

            }
        }

        // round 2
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                string solved = Solve( GetFromSpot(row, col), 1);
                PutInSpot(row, col, solved);
            }
        }

        return retVal;

    }

    private string Solve(string s, int depth)
    {
        string retVal = "";
        
        string[] parts = s.Split(' ');
        int o = 0;
        if (parts.Count() == 1 && int.TryParse(parts[0], out o))
        {
            return o.ToString();
        }
        else if (parts.Contains("a") || parts.Contains("b") || parts.Contains("c"))
        {

            while (depth > 0)
            {
                for (int i = 0; i < parts.Length; i++)
                {
                    string thisOne = parts[i];

                    int curentResult = 0;
                    int val = 0;
                    if (int.TryParse(thisOne, out val))
                    {
                        parts[i] = thisOne;
                    } 
                    else 
                    if (thisOne.Length == 2)
                    {
                        parts[i] = GetFromSpot(thisOne);
                    }

                    else if (thisOne.Equals("+"))
                    {
                        //parts[i - 1] = parts[i - 1] + parts[i + 1];
                        //for (int j = 0; j < parts.Length - 2; j++)
                        //{
                        //    parts[i + j] = parts[i + j + 2];
                        //    i = i + 2;
                        //}

                    }
                    else if (thisOne.Equals("-"))
                    {

                    }
                    else if (thisOne.Equals("*"))
                    {

                    }
                    else if (thisOne.Equals("/"))
                    {

                    }
                }
                foreach (var part in parts)
                {
                }

                depth--;
            }
        }


        else
        {


        }
        return retVal;
    }
}