
var SmallestInfiniteSet = function() {
    this.rest = 1; 
    /** @type {number[]}*/
    this.below = [];
};

/**
 * @return {number}
 */
SmallestInfiniteSet.prototype.popSmallest = function() {
    if(this.below.length > 0){
	return (/** @type number */(this.below.shift()))
    }
    return this.rest++;
};

/** 
 * @param {number} num
 * @return {void}
 */
SmallestInfiniteSet.prototype.addBack = function(num) {
    if(num >= this.rest){
	return
    }
    let start = 0;
    let end = this.below.length - 1;
    let idx = (start + end) >> 1;
    while(start <= end){
	if(num < this.below[idx]){
	    end = idx - 1
	} else if(num > this.below[idx]){
	    start = idx + 1
	} else {
	    return
	}
	idx = (start + end) >> 1
    }
    this.below.splice(idx + 1, 0, num)
};

