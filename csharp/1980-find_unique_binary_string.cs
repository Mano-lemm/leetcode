using System.Text;

namespace csharp;

public class _1980_find_unique_binary_string {
     public string FindDifferentBinaryString(string[] nums)
     {
          var sb = new StringBuilder(nums.Length);
          for (var i = 0; i < nums.Length; i++)
          {
               sb.Append(nums[i][i] == '1' ? '0' : '1');
          }
          return sb.ToString();
     }
     
     public string FindDifferentBinaryStringLINQ(string[] nums)
     {
          return nums
               .Select((x, i) => x[i] == '1' ? '0' : '1')
               .Aggregate(new StringBuilder(), (sb, c) => { sb.Append(c); return sb; })
               .ToString();
     }
}