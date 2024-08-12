pub struct Solution;

impl Solution {
    pub fn max_sub_array(nums: Vec<i32>) -> i32 {
        let mut current = 0;
        let mut max = std::i32::MIN;

        for num in nums {
            current = if num > current + num {
                num
            } else {
                current + num
            };
            max = if max > current { max } else { current };
        }
        max
    }
}
