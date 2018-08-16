using System;
using System.Collections.Generic;

public class Solution
{
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0 && nums2.Length == 0)
                return 0;

            if (nums1.Length == 0 && nums2.Length != 0)
                return GetMedian(nums2);
            else if (nums2.Length == 0 && nums1.Length != 0)
                return GetMedian(nums1);

            List<int> nums3 = new List<int>();

            int maxlen = Math.Max(nums1.Length, nums2.Length);

            int i = 0, j = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums3.Contains(nums1[i]))
                {
                    i++;
                    continue;
                }
                else if (nums3.Contains(nums2[j]))
                {
                    j++;
                    continue;
                }

                if (nums1[i] < nums2[j])
                {
                    nums3.Add(nums1[i]);
                    i++;
                }
                else if (nums2[j] < nums1[i])
                {
                    nums3.Add(nums2[j++]);
                }
                else
                {
                    nums3.Add(nums1[i++]);
                    j++;
                }
            }

            if (i < nums1.Length)
            {
                for (int l = i; l < nums1.Length; l++)
                {
                    if (nums3.Contains(nums1[l]))
                        continue;
                    nums3.Add(nums1[l]);
                }
            }
            else if (j < nums2.Length)
            {
                for (int l = 0; l < nums2.Length; l++)
                {
                    if (nums3.Contains(nums2[l]))
                        continue;
                    nums3.Add(nums2[l]);
                }
            }
            int[] numu = nums3.ToArray();
            return GetMedian(numu);
        }

        public double GetMedian(int[] nums3)
        {
            if (nums3.Length == 1)
            {
                return nums3[0];
            }
            if (nums3.Length == 2)
            {
                return (double)(nums3[0] + nums3[1]) / 2;
            }

            if (nums3.Length % 2 == 0)
            {
                int mid = ((nums3.Length) / 2) - 1;
                double sum = nums3[mid] + nums3[mid + 1];
                return (sum) / 2;
            }
            else
            {
                int mid = (int)Math.Floor((decimal)nums3.Length / 2);
                return nums3[mid];
            }
        }
    }

    public static void Main()
    {
        Solution sol = new Solution();
        Console.WriteLine(sol.FindMedianSortedArrays(new int[] {1,1 }, new int[] { 1,1}));
        Console.Read();
    }
}