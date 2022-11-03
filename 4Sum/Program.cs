using System;
using System.Collections.Generic;

namespace _4Sum
{
  class Program
  {
    static void Main(string[] args)
    {
      int target = - 294967296;
      var nums = new int[] { 1000000000, 1000000000, 1000000000, 1000000000 };
      var result = FourSum(nums, target);
      foreach(var res in result)
        Console.WriteLine(string.Join(",", res));
    }

    public static IList<IList<int>> FourSum(int[] nums, int target)
    {
      List<IList<int>> result = new List<IList<int>>();
      // base condition
      if (nums == null || nums.Length < 4) return result;
      Array.Sort(nums);
      int length = nums.Length;
      for (int i = 0; i < length - 3; i++)
      {
        // skip subsequesnt duplicates 
        if (i > 0 && nums[i] == nums[i - 1])
        {
          continue;
        }
        for (int j = i + 1; j < length - 2; j++)
        {
          // skip subsequesnt duplicates 
          if (j > i + 1 && nums[j] == nums[j - 1])
          {
            continue;
          }
          // binary search
          int left = j + 1, right = length - 1;
          while (left < right)
          {
            var sum = (long)nums[i] + nums[j] + nums[left] + nums[right];
            if(sum == target)
            {
              var temp = new List<int>();
              temp.Add(nums[i]);
              temp.Add(nums[j]);
              temp.Add(nums[left]);
              temp.Add(nums[right]);
              result.Add(temp);

              left++; right--;
              while (left < right && nums[left] == nums[left - 1]) left++;
              while (left < right && nums[right] == nums[right + 1]) right--;
            }
            else if(sum < target)
            {
              left++;
            }
            else
            {
              right--;
            }
          }
        }
      }
      return result;
    }
  }
}
