#include <pthread.h>

typedef struct
{
    pthread_mutex_t mut;
    pthread_cond_t cond;
    int cur;
    int max;
} FizzBuzz;

FizzBuzz *fizzBuzzCreate(int n)
{
    FizzBuzz *obj = (FizzBuzz *)malloc(sizeof(FizzBuzz));
    pthread_mutex_init(&obj->mut, NULL);
    pthread_cond_init(&obj->cond, NULL);
    obj->max = n;
    obj->cur = 1;
    return obj;
}

// printFizz() outputs "fizz".
void fizz(FizzBuzz *obj)
{
    while (obj->cur < obj->max)
    {
        pthread_mutex_lock(&obj->mut);
        while (0 == ((obj->cur % 3) == 0 && (obj->cur % 5) != 0) && obj->cur <= obj->max)
        {
            pthread_cond_wait(&obj->cond, &obj->mut);
        }
        if (obj->cur <= obj->max)
        {
            printFizz();
            obj->cur++;
        }
        pthread_mutex_unlock(&obj->mut);
        pthread_cond_broadcast(&obj->cond);
    }
}

// printBuzz() outputs "buzz".
void buzz(FizzBuzz *obj)
{
    while (obj->cur <= obj->max)
    {
        pthread_mutex_lock(&obj->mut);
        while (0 == ((obj->cur % 3) != 0 && (obj->cur % 5) == 0) && obj->cur <= obj->max)
        {
            pthread_cond_wait(&obj->cond, &obj->mut);
        }
        if (obj->cur <= obj->max)
        {
            printBuzz();
            obj->cur++;
        }
        pthread_mutex_unlock(&obj->mut);
        pthread_cond_broadcast(&obj->cond);
    }
}

// printFizzBuzz() outputs "fizzbuzz".
void fizzbuzz(FizzBuzz *obj)
{
    while (obj->cur <= obj->max)
    {
        pthread_mutex_lock(&obj->mut);
        while (0 == ((obj->cur % 3) == 0 && (obj->cur % 5) == 0) && obj->cur <= obj->max)
        {
            pthread_cond_wait(&obj->cond, &obj->mut);
        }
        if (obj->cur <= obj->max)
        {
            printFizzBuzz();
            obj->cur++;
        }
        pthread_mutex_unlock(&obj->mut);
        pthread_cond_broadcast(&obj->cond);
    }
}

// You may call global function `void printNumber(int x)`
// to output "x", where x is an integer.
void number(FizzBuzz *obj)
{
    while (obj->cur <= obj->max)
    {
        pthread_mutex_lock(&obj->mut);
        while (0 == ((obj->cur % 3) != 0 && (obj->cur % 5) != 0) && obj->cur <= obj->max)
        {
            pthread_cond_wait(&obj->cond, &obj->mut);
        }
        if (obj->cur <= obj->max)
        {
            printNumber(obj->cur);
            obj->cur++;
        }
        pthread_mutex_unlock(&obj->mut);
        pthread_cond_broadcast(&obj->cond);
    }
}

void fizzBuzzFree(FizzBuzz *obj)
{
    pthread_mutex_destroy(&obj->mut);
    pthread_cond_destroy(&obj->cond);
    free(obj);
}