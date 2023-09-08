#[path ="./0118-pascals_triangle.rs"] mod pascals_triangle;
#[path ="./0189-rotate_array.rs"] mod rotate_array;

fn main() {
    println!("{:?}", pascals_triangle::Solution::generate(5));
}
