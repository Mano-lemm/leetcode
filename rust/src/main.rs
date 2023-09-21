use merge_k_sorted::ListNode;

#[path = "./0023-merge_k_sorted_lists.rs"]
mod merge_k_sorted;
#[path = "./0118-pascals_triangle.rs"]
mod pascals_triangle;
#[path = "./0189-rotate_array.rs"]
mod rotate_array;
#[path = "./0015-three_sum.rs"]
mod three_sum;

fn main() {
    let l1: Vec<Option<Box<ListNode>>> = vec![
        Some(Box::new(ListNode {
            val: 1,
            next: Some(Box::new(ListNode {
                val: 4,
                next: Some(Box::new(ListNode { val: 5, next: None })),
            })),
        })),
        Some(Box::new(ListNode {
            val: 1,
            next: Some(Box::new(ListNode {
                val: 3,
                next: Some(Box::new(ListNode { val: 4, next: None })),
            })),
        })),
        Some(Box::new(ListNode {
            val: 2,
            next: Some(Box::new(ListNode { val: 6, next: None })),
        })),
    ];
    let l3: Vec<Option<Box<ListNode>>> = vec![None];
    println!("{:?}", merge_k_sorted::Solution::merge_k_lists(l1));
    println!("{:?}", merge_k_sorted::Solution::merge_k_lists(vec![]));
    println!("{:?}", merge_k_sorted::Solution::merge_k_lists(l3));
}
