use std::collections::{HashSet, HashMap};

pub struct Solution;

impl Solution {
    pub fn three_sum(nums: Vec<i32>) -> Vec<Vec<i32>> {
        let mut r: HashSet<Vec<i32>> = HashSet::new();
        let mut set: HashMap<i32, usize> = HashMap::new();
        for i in &nums {
            set.insert(*i, set.get(i).unwrap_or(&0) + 1);
        }
        for i in 0..nums.len()-2 {
            for j in i+1..nums.len()-1  {
                let k = -(&nums[i] + &nums[j]);
                let count = if &nums[i] == &k { 1 } else { 0 } + if &nums[j] == &k { 1 } else { 0 };
                if set.contains_key(&k) {
                    if set.get(&k).unwrap_or(&0) > &count{
                        let mut v = vec![nums[i], nums[j], -(&nums[i] + &nums[j])];
                        v.sort();
                        r.insert(v);
                    }
                }
            }
        }
        return r.iter().cloned().collect();
    }   
}
