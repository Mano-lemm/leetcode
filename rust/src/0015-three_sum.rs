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
    
    pub fn three_sum_2ptr(nums: Vec<i32>) -> Vec<Vec<i32>> {
        let mut ordered_nums: Vec<i32> = nums.clone();
        ordered_nums.sort();
        let mut r: Vec<Vec<i32>> = Vec::new();
        for i in 0..ordered_nums.len()-2 {
           if i > 0 && ordered_nums[i-1] == ordered_nums[i] {
               continue;
           }
           let n1 = ordered_nums[i];
           let mut j = i + 1;
           let mut k = ordered_nums.len() - 1;

           while j < k {
               let n2 = ordered_nums[j];
               let n3 = ordered_nums[k];
               let sum = n1 + n2 + n3;

               if sum < 0{
                   j += 1;
               } else if sum > 0{
                   k -= 1;
               } else {
                   r.push(vec![n1, n2, n3]);
                   while j < k && ordered_nums[j] == n2 {
                       j += 1;
                   }
                   while j < k && ordered_nums[k] == n3 {
                       k -= 1;
                   }
               }
           }
        }
        return r;
    }
}
