/**
 * @param {string} s
 * @return {boolean}
 */
var isValid = function (s) {
  const order = [];
  for (const char of s) {
    if (char == "(") {
      order.push("(");
    } else if (char == ")") {
      if (order.pop() != "(") {
        return false;
      }
    } else if (char == "[") {
      order.push("[");
    } else if (char == "]") {
      if (order.pop() != "[") {
        return false;
      }
    } else if (char == "{") {
      order.push("{");
    } else if (char == "}") {
      if (order.pop() != "{") {
        return false;
      }
    }
  }
  return order.length == 0;
};

console.log(isValid("()[]{}"));
console.log(isValid("(]"));
