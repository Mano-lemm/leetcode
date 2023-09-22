package main

import (
	pq "github.com/emirpasic/gods/queues/priorityqueue"
)

type ListNode struct {
	Val  int
	Next *ListNode
}

func less(a, b interface{}) int {
	return a.(*ListNode).Val - b.(*ListNode).Val
}

func mergeKLists(lists []*ListNode) *ListNode {
	if lists == nil || len(lists) == 0 {
		return nil
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
	return r.(*ListNode)
}
