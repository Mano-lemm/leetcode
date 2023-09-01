/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number[]}
 */
var maxSlidingWindow = function(nums, k) {
    /** @type number[] */
    const rval = []
    for(let i = 0; i < nums.length - (k - 1); i++){
	let max = nums[i]
	for(let j = i + 1; j < i + k; j++){
	    if(nums[j] > max){
		max = nums[j]
	    }
	}
	rval.push(max)
    }
    return rval
};


