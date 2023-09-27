#include <string>
#include <unordered_set>
#include <unordered_map>
#include <vector>
#include <limits.h>
#include <stdio.h>

using namespace std;
class Solution {
public:
    string removeDuplicateLetters(string s) {
        unordered_map<char, int> counts;
        for (char c : s) {
            if (!counts.contains(c)) {
                counts.emplace(c, 1);
            } else {
                counts[c]++;
            }
        }
        unordered_set<char> seen;
        vector<char> rvec;
        for (char c : s) {
            if (seen.contains(c)) {
                counts[c]--;
                continue;
            }
            while (!rvec.empty() && rvec[rvec.size() - 1] > c && counts[rvec[rvec.size() - 1]] > 0) {
                seen.erase(seen.find(rvec[rvec.size() - 1]));
                rvec.pop_back();
            }
            rvec.push_back(c);
            counts[c]--;
            seen.insert(c);
        }
        return string(rvec.begin(), rvec.end());
    }
};

int main() {
    Solution s = Solution();
    printf("%s\n", s.removeDuplicateLetters("bcabc").c_str());
    printf("%s\n", s.removeDuplicateLetters("cbacdcbc").c_str());
    return 0;
}
