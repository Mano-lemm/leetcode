package main

import (
	"strconv"
)

func decodeAtIndex(s string, k int) string {
	n := len(s)
    length := 0
    idx := 0
    for idx < n && length < k{
        item := s[idx]
        value,_ :=strconv.Atoi(string(item))
        if value == 0{
            length++
        }else{
            length*=value
        }
        idx++
    }

    for idx >= 0{
        value,_ := strconv.Atoi(string(s[idx-1]))
        if value != 0{
            length /= value
            k %= length
        }else{
            if k % length == 0{
                break
            }
            length--
        }
        idx--
    }

    return string(s[idx-1])
}
