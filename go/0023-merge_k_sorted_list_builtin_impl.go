package main;

import (
    "container/heap"
)

type PrioQueue []*ListNode

func (pq PrioQueue) Len() int { return len(pq) }
func (pq PrioQueue) Less(i, j int) bool { return pq[i].Val < pq[j].Val }
func (pq PrioQueue) Swap(i, j int) { pq[i], pq[j] = pq[j], pq[i] }

func (pq *PrioQueue) Push(x any) {
	item := x.(*ListNode)
	*pq = append(*pq, item)
}

func (pq *PrioQueue) Pop() any {
	old := *pq
	n := len(old)
	item := old[n-1]
	old[n-1] = nil
	*pq = old[0 : n-1]
	return item
}

func mergeKLists_builtin(lists []*ListNode) *ListNode {
    if lists == nil || len(lists) == 0 { 
        return nil
    }
    pq := make(PrioQueue, 0)
    quit := true
    for _, v := range lists {
	if v != nil { 
	    pq = append(pq, v)
	    quit = false
	}
    }
    if quit {
	return nil
    }
    heap.Init(&pq)
    tmp := heap.Pop(&pq).(*ListNode)
    r := &ListNode{tmp.Val, nil}
    ass := r
    if tmp.Next != nil {
	heap.Push(&pq, tmp.Next)
    }
    for pq.Len() != 0 {
	tmp = heap.Pop(&pq).(*ListNode)
	ass.Next = &ListNode{
	    Val: tmp.Val, 
	    Next: nil,
	}
	ass = ass.Next
	if tmp.Next != nil {
	    heap.Push(&pq, tmp.Next)
	}
    }
    return r;
}

