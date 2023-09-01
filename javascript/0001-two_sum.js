/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSum = function (nums, target) {
  for (let start = 0; start < nums.length; start++) {
    for (let end = start + 1; end < nums.length; end++) {
      if (nums[start] + nums[end] == target) {
        return [start, end];
      }
    }
  }
  return [-1, -1];
};
