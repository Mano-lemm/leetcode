#include <pthread.h>

typedef struct
{
    pthread_mutex_t mut;
    pthread_cond_t cond;
    int cur;
} Foo;

Foo *fooCreate()
{
    Foo *obj = (Foo *)malloc(sizeof(Foo));
    pthread_mutex_init(&obj->mut, NULL);
    pthread_cond_init(&obj->cond, NULL);
    obj->cur = 0;
    return obj;
}

void first(Foo *obj)
{
    printFirst();
    obj->cur = 1;
    pthread_cond_broadcast(&obj->cond);
}

void second(Foo *obj)
{
    pthread_mutex_lock(&obj->mut);
    while (obj->cur != 1)
    {
        pthread_cond_wait(&obj->cond, &obj->mut);
    }

    obj->cur = 2;
    printSecond();
    pthread_mutex_unlock(&obj->mut);
    pthread_cond_broadcast(&obj->cond);
}

void third(Foo *obj)
{
    pthread_mutex_lock(&obj->mut);
    while (obj->cur != 2)
    {
        pthread_cond_wait(&obj->cond, &obj->mut);
    }

    printThird();
    pthread_mutex_unlock(&obj->mut);
}

void fooFree(Foo *obj)
{
    pthread_cond_destroy(&obj->cond);
    pthread_mutex_destroy(&obj->mut);
    free(obj);
}