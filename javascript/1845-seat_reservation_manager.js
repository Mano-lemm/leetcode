/**
 * @param {number} n
 */
var SeatManager = function(n) {
    this.top = 1;
    /**
     * @type {number[]}
     */
    this.values = []
};

/**
 * @return {number}
 */
SeatManager.prototype.reserve = function() {
    let s = this.values.shift();
    return s == undefined ? this.top++ : s;
};

/** 
 * @param {number} seatNumber
 * @return {void}
 */
SeatManager.prototype.unreserve = function(seatNumber) {
    if(this.top == seatNumber + 1){
        this.top--
    } else {
        this.values.push(seatNumber)
        this.values.sort((a, b) => a - b)
    }
};