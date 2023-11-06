/**
 * @param {number} n
 */
var SeatManagerMonad = function(n) {
    this.top = 1;
    /**
     * @type {number[]}
     */
    this.values = []
};

/**
 * @return {{sm: SeatManagerMonad, r:number}}
 */
SeatManagerMonad.prototype.reserve = function() {
    let s = this.values[0];
    if(s == undefined) {
        let r = new SeatManagerMonad(0);
        r.top = this.top + 1;
        r.values = this.values;
        return {sm: r, r: this.top}
    }
    let r = new SeatManagerMonad(0);
    r.top = this.top;
    r.values = this.values.slice(1, this.values.length);
    return {sm: r, r: s}
};

/** 
 * @param {number} seatNumber
 * @return {SeatManagerMonad}
 */
SeatManagerMonad.prototype.unreserve = function(seatNumber) {
    if(this.top == seatNumber + 1){
        let r = new SeatManagerMonad(0);
        r.top = this.top - 1;
        r.values = this.values;
        return r
    } else {
        let r = new SeatManagerMonad(0);
        r.top = this.top - 1;
        r.values = [...this.values, seatNumber];
        r.values.sort((a, b) => a - b)
        return r
    }
};