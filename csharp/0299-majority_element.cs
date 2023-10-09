using System;

namespace majority_element
{
    public class Solution
    {
        public IList<int> MajorityElement(int[] nums) {
            var dict = new Dictionary<int, int>();
            foreach(var val in nums)
            {
                if(dict.ContainsKey(val)) {
                    dict[val]++;
                } else {
                    dict.Add(val, 1);
                }
            }
            return new List<int>(from kv in dict where kv.Value > nums.Length / 3 select kv.Key);
        }
    }
}
