pub struct Solution;

impl Solution {
    pub fn rotate(nums: &mut Vec<i32>, k: i32) {
        let mut tmp = nums.split_off(nums.len() - (k as usize % nums.len()));
        tmp.append(nums);
        *nums = tmp;
    }
}
