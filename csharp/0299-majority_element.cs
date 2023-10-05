using System;

namespace majority_element
{
    public class Solution
    {
        public IList<int> MajorityElement(int[] nums) {
            var dict = new Dictionary<int, int>();
            var returnList = new HashSet<int>();
            foreach(var val in nums)
            {
                if(dict.ContainsKey(val)) {
                    dict[val]++;
                } else {
                    dict.Add(val, 1);
                }
                if(dict[val] > nums.Length / 3)
                {
                    returnList.Add(val);
                }
            }
            return new List<int>(returnList);
        }
    }
}
