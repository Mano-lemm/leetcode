/**
 * @param {number[]} stones
 * @return {boolean}
 */
var canCross = function (stones) {
  if (stones.length >= 2) {
    if (stones[1] != 1) {
      return false;
    }
  }
  /** @type {{k: number, pos: number}[]} */
  const possibilities = [{ k: 1, pos: stones[0] }];
  const seen = new Set();
  let curpos = possibilities.shift();
  while (curpos != undefined) {
    if (curpos.pos == stones[stones.length - 1]) {
      return true;
    }
    if (stones.indexOf(curpos.pos + (curpos.k + 1)) != -1 && curpos.pos != 0) {
      const next = { k: curpos.k + 1, pos: curpos.pos + curpos.k + 1 };
      if (!seen.has(JSON.stringify(next))) {
        possibilities.push(next);
        seen.add(JSON.stringify(next));
      }
    }
    if (stones.indexOf(curpos.pos + curpos.k) != -1) {
      const next = { k: curpos.k, pos: curpos.pos + curpos.k };
      if (!seen.has(JSON.stringify(next))) {
        possibilities.push(next);
        seen.add(JSON.stringify(next));
      }
    }
    if (stones.indexOf(curpos.pos + (curpos.k - 1)) != -1 && curpos.pos != 0) {
      const next = { k: curpos.k - 1, pos: curpos.pos + curpos.k - 1 };
      if (!seen.has(JSON.stringify(next))) {
        possibilities.push(next);
        seen.add(JSON.stringify(next));
      }
    }
    curpos = possibilities.shift();
  }
  return false;
};
