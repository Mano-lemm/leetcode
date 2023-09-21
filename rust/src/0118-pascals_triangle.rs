pub struct Solution;

impl Solution {
    pub fn generate(num_rows: i32) -> Vec<Vec<i32>> {
        let mut vec: Vec<Vec<i32>> = vec![];
        for i in 0..num_rows {
            let prevvec = vec.get((i - 1) as usize);
            let mut newvec: Vec<i32> = vec![];
            for j in 0..i {
                let a = prevvec.unwrap().get((j - 1) as usize).unwrap_or(&0);
                let b = prevvec.unwrap().get((j) as usize).unwrap_or(&0);
                newvec.push(a + b);
            }
            newvec.push(1);
            vec.push(newvec);
        }
        return vec;
    }
}
