var join = function(arr1, arr2){
    const result = {};

    // add first items
    arr1.forEach(item => {
        result[item.id] = item;
    });
    // join second items
    arr2.forEach(item => {
        if (result[item.id]) {
            Object.keys(item).forEach(key => {
                result[item.id][key] = item[key];
            });
        } else {
            result[item.id] = item;
        }
    });

    return Object.values(result);
}
