/**
 * @param {number[]} nums
 * @return {number}
 */
var findMin = function (nums) {
  let start = 0;
  let end = nums.length - 1;
  let idx = (start + end) >> 1;
  while (start <= end) {
    // right unsorted => contains smallest
    if (nums[idx] > nums[end]) {
      start = idx + 1;
    }
    // left unsorted => contains smallest
    else if (nums[start] > nums[idx]) {
      end = idx;
    }
    // left and right sorted => smallest in left is min
    else {
      return Math.min(nums[start], nums[idx]);
    }
    idx = (start + end) >> 1;
  }
  return -1;
};
