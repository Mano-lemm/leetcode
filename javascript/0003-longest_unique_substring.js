/**
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstring = function (s) {
  /**
   *  @param {string} s
   *  @param {number} start
   *  @param {number} acc
   *
   *  @return {number}
   */
  let maxlen = (s, start, acc) => {
    let max = { len: 0, str: "" };
    let pos = start;
    while (pos < s.length) {
      if (max.str.includes(s.charAt(pos))) {
        return maxlen(s, start + 1, Math.max(max.len, acc));
      }
      max.len++;
      max.str += s.charAt(pos);
      pos += 1;
    }
    return Math.max(max.len, acc);
  };
  return maxlen(s, 0, 0);
};
