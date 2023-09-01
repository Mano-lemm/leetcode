#import <stdio.h>
#import <string.h>
#import <stdbool.h>
#import <limits.h>

#define MIN(a,b) (((a)<(b))?(a):(b))
#define MAX(a,b) (((a)>(b))?(a):(b))

int myAtoi(char * s){
    long val = 0;
    bool parsedAny = false;
    bool negative = false;
    int i = 0;
    while(s[i] == ' ') {
	i++;
    }
    if(s[i] == '-'){
	negative = true;
    }
    if(s[i] == '-' || s[i] == '+') i++;
    while(s[i] >= '0' && s[i] <= '9'){
	val *= 10;
	if(val > INT_MAX){
	    if(negative) {return INT_MIN;}
	    return INT_MAX;
	}
	val += (int)(s[i]) - 48;
	i++;
    }
    if(negative) {
	val = ~val + 1;
	return MAX(val, INT_MIN);
    }
    return MIN(val, INT_MAX);
}

int main(){
    printf("%d\n", myAtoi("42"));
    printf("%d\n", myAtoi("   -42"));
    printf("%d\n", myAtoi("-91283472332"));
    printf("%d\n", myAtoi("2147483648"));
    return 0;
}

