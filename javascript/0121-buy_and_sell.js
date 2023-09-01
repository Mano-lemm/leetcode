/**
 * @param {number[]} prices
 * @return {number}
 */
var maxProfit = function (prices) {
  if (prices.length < 2) {
    return 0;
  }
  let max = 0;
  for (let min = 0; min < prices.length; min++) {
    for (let idx = min + 1; idx < prices.length; idx++) {
      if (prices[idx] < prices[min]) {
        idx = min - 1;
        break;
      }
      if (-1 * prices[min] + prices[idx] > max) {
        max = -1 * prices[min] + prices[idx];
      }
    }
  }
  return max;
};

console.log(maxProfit([7, 6, 4, 3, 1]));
console.log(maxProfit([7, 1, 5, 3, 6, 4]));
