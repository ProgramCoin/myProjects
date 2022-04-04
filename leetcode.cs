using System;
using System.Collections;
using System.Text;
using System.Dynamic;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace leetcode
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };    
            int target = 10;

            Array.Sort<int>(nums); 
            //We can use a sorted array to our advantage for the final result by subtracting 1 from the actual answer
            //to show the arrays index

            for (int i=0; i < nums.Length; i++)
            {
                for (int j = i + 1; j<nums.Length; j++)

                {
                    int difference = target - nums[i];

                    if (difference == j)
                    {
                        if (difference == nums[i])

                        {
                            if (difference != j)
                            {

                                Console.WriteLine("No second numbers found");

                            }

                            continue;
                        }

                        Console.WriteLine("Result is: Array[{0},{1}]", nums[i] - 1, difference - 1);
                        
                    }

                }

            }
        }
    }
}
//aa
