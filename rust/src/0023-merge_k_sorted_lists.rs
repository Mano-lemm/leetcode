pub use std::collections::BinaryHeap;

pub struct Solution;

#[derive(PartialEq, Eq, Clone, Debug)]
pub struct ListNode {
    pub val: i32,
    pub next: Option<Box<ListNode>>,
}

impl ListNode {
    #[inline]
    fn new(val: i32) -> Self {
        ListNode { next: None, val }
    }
}

impl PartialOrd for ListNode {
    fn partial_cmp(&self, other: &Self) -> Option<std::cmp::Ordering> {
        Some(self.cmp(other))
    }
}

impl Ord for ListNode {
    fn cmp(&self, other: &Self) -> std::cmp::Ordering {
        self.val.cmp(&other.val).reverse()
    }
}

impl Solution {
    pub fn merge_k_lists(lists: Vec<Option<Box<ListNode>>>) -> Option<Box<ListNode>> {
        let mut heap = lists
            .into_iter()
            .filter_map(|x| x)
            .collect::<BinaryHeap<_>>();
        let mut head = None;
        let mut tail = &mut head;
        while let Some(node) = heap.pop() {
            tail = &mut tail.insert(node).next;
            if let Some(next) = tail.take() {
                heap.push(next)
            }
        }
        return head;
    }
}
