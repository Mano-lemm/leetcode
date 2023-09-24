#include <algorithm>
#include <iostream>
#include <queue>
#include <vector>

struct ListNode {
  int val;
  ListNode *next;
  ListNode() : val(0), next(nullptr) {}
  ListNode(int x) : val(x), next(nullptr) {}
  ListNode(int x, ListNode *next) : val(x), next(next) {}
};

using namespace std;

class Solution {
public:
  ListNode *mergeKLists(vector<ListNode *> &lists) {
    // c++ is fucked up man...
    auto cmp = [](const ListNode *l1, const ListNode *l2) {
      return l1->val > l2->val;
    };
    priority_queue<ListNode *, vector<ListNode *>, decltype(cmp)> heap(cmp);
    for (int i = 0; i < lists.size(); i++) {
      if (lists[i] != nullptr) {
        heap.push(lists[i]);
        lists[i] = lists[i]->next;
      }
    }
    ListNode *head = nullptr;
    ListNode **ass = &head;
    while (!heap.empty()) {
      *ass = heap.top();
      heap.pop();
      if ((*ass)->next != nullptr) {
        heap.push((*ass)->next);
      }
      ass = &(*ass)->next;
    }
    return head;
  }
};
