class EventEmitter {
    /**
     * @type {Map<string, Function[]>}
     */
    eventMap = new Map();

    /**
     * @param {string} eventName
     * @param {Function} callback
     * @return {{unsubscribe: Function}}
     */
	subscribe(eventName, callback) {
      	if (!this.eventMap.has(eventName)) {
            this.eventMap.set(eventName, [])
        }
        this.eventMap.get(eventName)?.push(callback)
		return {
			unsubscribe: () => {
                let ls = this.eventMap.get(eventName)
                ls?.splice(ls?.indexOf(callback), 1)
			}
		};
	}
    
    /**
     * @param {string} eventName
     * @param {Array<any>} args
     * @return {Array<any>}
     */
	emit(eventName, args = []) {
        let ls = this.eventMap.get(eventName)
        return ls?.map(x => x(...args)) ?? []
	}
}

let ev = new EventEmitter()
let un = ev.subscribe("firstEvent", (/** @type {any[]} */ ...args) => args.join(','))
console.log(ev.emit("firstEvent", [1,2,3]))
un.unsubscribe()
console.log(ev.emit("firstEvent", [4,5,6]))