/**
 * @param {number[]} coins
 * @param {number} amount
 * @return {number}
 */
var coinChange = function(coins, amount) {
    const map = new Map();
    map.set(0, 0);
    let curset = new Set();

    for(const coin of coins) {
      map.set(coin, 1);
      curset.add(coin);
    }

    while(!map.has(amount) && curset.size != 0) {
      let newset = new Set();
      for(const curamt of curset) {
        for(const coin of coins) {
          if(!map.has(curamt + coin) && curamt + coin <= amount) {
            map.set(curamt + coin, map.get(curamt) + 1);
            newset.add(curamt + coin);
          }
        }
      }
      curset = newset;
    }

    return map.has(amount) ? map.get(amount) : -1;
};
  
/**
 * @param {number[]} coins
 * @param {number} amount
 * @return {number}
 */
var coinChange2 = function(coins, amount) {
  /** @type {number[]} */
  const amounts = new Array(amount + 1).fill(Infinity);
  amounts[0] = 0;

  for (let i = 0; i < amount + 1; i++) {
    for (const coin of coins) {
      if (coin > i) continue;
      amounts[i] = Math.min(amounts[i], amounts[i - coin] + 1);
    }
  }

  return amounts[amount] === Infinity ? -1 : amounts[amount]
};
