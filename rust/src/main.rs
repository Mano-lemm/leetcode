#[path ="./0189-rotate_array.rs"] mod rotate_array;

fn main() {
    let mut nums = vec![1,2,3,4,5,6,7];
    let k = 3;
    println!("{:?}", nums);
    rotate_array::Solution::rotate(&mut nums, k);
    println!("{:?}", nums);
}
