#include <string>
#include <unordered_set>
#include <vector>
#include <limits.h>
#include <stdio.h>

using namespace std;
class Solution {
public:
    string removeDuplicateLetters(string s) {
        unordered_set<char> seen;
        vector<char> rvec;
        for (int i = 0; i < s.size(); i++) {
            if (!seen.contains(s[i])) {
                rvec.push_back(s[i]);
                seen.insert(s[i]);
                continue;
            }
            int location = -1;
            for (int j = 0; j < rvec.size(); j++) {
                if (rvec[j] == s[i]) {
                    location = j;
                    break;
                }
            }
            if (location == rvec.size() - 1) {
                continue;
            }
            if (rvec[location] < rvec[location + 1]) {
                rvec.erase(rvec.begin() + location);
                rvec.push_back(s[i]);
            }
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
