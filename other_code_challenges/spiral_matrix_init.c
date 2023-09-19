#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>

int** spiral(int rows, int columns){
    int** mat = malloc(sizeof(int*) * rows);
    for (int i = 0; i < rows; i++) {
        mat[i] = malloc(sizeof(int) * columns);
    }

    bool** seen = malloc(sizeof(bool) * rows);
    for (int i = 0; i < rows; i++) {
        seen[i] = malloc(sizeof(bool) * columns);
        memset(seen[i], 0, sizeof(bool) * columns);
    }

    int cur = 1;
    int direction[4][2] = {{0 ,1}, {1 ,0}, {0, -1}, {-1, 0}};
    int curdir = 0;
    int loc[] = {0, 0};
    int tryloc[] = {0, 0};

    for (int i = 0; i < rows * columns; i++) {
        mat[loc[0]][loc[1]] = cur++;
        seen[loc[0]][loc[1]] = true;
        tryloc[0] = loc[0] + direction[curdir][0];
        tryloc[1] = loc[1] + direction[curdir][1];

        if (
            tryloc[0] >= 0 && tryloc[0] < rows &&
            tryloc[1] >= 0 && tryloc[1] < columns &&
            !seen[tryloc[0]][tryloc[1]])
        {
            loc[0] = tryloc[0];
            loc[1] = tryloc[1];
        } else {
            curdir = (curdir + 1) % 4;
            loc[0] += direction[curdir][0];
            loc[1] += direction[curdir][1];
        }
    }

    free(seen);
    return mat;
}

int main() {
    int** mat = spiral(3, 4);
    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 4; j++) {
            printf("%02d ", mat[i][j]);
        }
        printf("\n");
    }
    free(mat);
    return 0;
}
