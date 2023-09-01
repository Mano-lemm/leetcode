/**
 * @param {number[]} nums
 *   sorted, ascending
 *   possibly rotated
 *   pivot unknown
 *
 * @param {number} target
 * @return {number}
 *
 *   algorithm must be O(log n) or less runtime
 */
var search = function (nums, target) {
  if (nums[0] > nums[nums.length - 1]) {
    let pivot = findPivot(nums);
    let left = nums.slice(0, pivot);
    let right = nums.slice(pivot, nums.length);
    let tmp = search([...right, ...left], target);
    if (tmp == -1) {
      return tmp;
    }
    if (tmp >= right.length) {
      return tmp - right.length;
    }
    return pivot + tmp;
  }
  let start = 0;
  let end = nums.length - 1;
  let idx = (start + end) >> 1;
  while (start <= end) {
    idx = (start + end) >> 1;
    if (target < nums[idx]) {
      end = idx - 1;
    } else if (target > nums[idx]) {
      start = idx + 1;
    } else {
      return idx;
    }
  }
  return -1;
};

/**
 * @param {number[]} nums
 * @return {number} pivot
 */
var findPivot = (nums) => {
  let start = 0;
  let end = nums.length - 1;
  let pivot = (start + end) >> 1;
  while (start <= end) {
    pivot = (start + end) >> 1;
    if (nums[pivot] > nums[pivot + 1]) {
      return pivot + 1;
    }
    if (nums[start] < nums[pivot]) {
      start = pivot + 1;
    } else if (nums[pivot] < nums[end]) {
      end = pivot - 1;
    }
  }
  return -1;
};
