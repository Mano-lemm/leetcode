#[derive(Debug)]
pub struct KthLargest {
    k: i32,
    nums: Vec<i32>,
}

/**
 * `&self` means the method takes an immutable reference.
 * If you need a mutable reference, change it to `&mut self` instead.
 */
impl KthLargest {
    pub fn new(k: i32, mut nums: Vec<i32>) -> Self {
        nums.sort();
        Self { k, nums }
    }

    pub fn add(&mut self, val: i32) -> i32 {
        let idx = match self.nums.binary_search(&val) {
            Ok(idx) => idx,
            Err(idx) => idx,
        };
        self.nums.insert(idx, val);
        self.nums[self.nums.len() - self.k as usize]
    }
}
