#[path ="./0118-pascals_triangle.rs"] mod pascals_triangle;
#[path ="./0189-rotate_array.rs"] mod rotate_array;
#[path ="./0015-three_sum.rs"] mod three_sum;

fn main() {
    // println!("{:?}", pascals_triangle::Solution::generate(5));
    println!("{:?}", three_sum::Solution::three_sum(vec![1, -1, 0]));
    println!("{:?}", three_sum::Solution::three_sum(vec![-1,0,1,2,-1,-4]));
    println!("{:?}", three_sum::Solution::three_sum(vec![0,1,1]));
    println!("{:?}", three_sum::Solution::three_sum(vec![0,0,0]));
    println!("{:?}", three_sum::Solution::three_sum(vec![0,0,1]));
}
