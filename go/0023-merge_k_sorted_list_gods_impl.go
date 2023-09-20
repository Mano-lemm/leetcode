package main

import (
	pq "github.com/emirpasic/gods/queues/priorityqueue"
	"fmt"
)

type ListNode struct {
    Val int
    Next *ListNode
}

func less(a, b interface{}) int {
	return a.(*ListNode).Val - b.(*ListNode).Val
}

func mergeKLists(lists []*ListNode) *ListNode {
	if lists == nil || len(lists) == 0 {
		return nil;
	}
	queue := pq.NewWith(less)
	for _, v := range lists {
		if v != nil {
			queue.Enqueue(v)
		}
	}
	if queue.Empty() {
		return nil
	}
	r, _ := queue.Dequeue()
	ass := r.(*ListNode)
	if ass.Next != nil {
		queue.Enqueue(ass.Next)
	}
	for !queue.Empty() {
		itmp, _ := queue.Dequeue()
		tmp := itmp.(*ListNode)
		ass.Next = &ListNode{Val: tmp.Val, Next: nil}
		ass = ass.Next
		if tmp.Next != nil {
			queue.Enqueue(tmp.Next)
		}
	}
	return r.(*ListNode);
}

func main() {
	l1 := []*ListNode{
		{1, &ListNode{4, &ListNode{5, nil}}},
		{1, &ListNode{3, &ListNode{4, nil}}},
		{2, &ListNode{6, nil}},
	}
	fmt.Println("Test 1:")
	for _, value := range l1 {
		for value != nil {
			fmt.Printf("%d -> ", value.Val)
			value = value.Next
		}
		fmt.Println("nil")
	}
	merged := mergeKLists(l1)
	for merged != nil {
		fmt.Printf("%d -> ", merged.Val)
		merged = merged.Next
	}
	fmt.Println("nil")
}
