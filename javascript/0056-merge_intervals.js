/**
 * @param {number[][]} intervals
 * @return {number[][]}
 */
var merge = function(intervals) {
    let rval = [intervals[0]]
    for(const interval of intervals.slice(1)){
	let done = false;
	for(const realInterval of rval.slice().reverse()){
	    if(interval[0] <= realInterval[1] 
	    && interval[1] >= realInterval[0]){
		realInterval[0] = Math.min(interval[0], realInterval[0])
		realInterval[1] = Math.max(interval[1], realInterval[1])
		done = true;
	    } 
	}
	if(!done){
	    rval.push(interval)
	} else {
	    rval = merge(rval)
	}
    }
    return rval
};


