use std::char;

pub struct Solution;

impl Solution {
    fn get_available(board: &Vec<Vec<char>>, i: usize, j: usize) -> Vec<char> {
        let mut coll = vec![];
        for c in 1..10 {
            let c = char::from_digit(c, 10).unwrap();
            let mut add = true;
            for k in 0..9 {
                if board[i][k] == c || board[k][j] == c {
                    add = false;
                    break;
                }
            }
            'outer: for i in i-(i%3)..i+(3-i%3) {
                for j in j-(j%3)..j+(3-j%3) {
                    if board[i][j] == c {
                        add = false;
                        break 'outer;
                    }
                }
            }
            if add {
                coll.push(c);
            }
        }
        coll
    }

    fn solve_su_rec(board: &mut Vec<Vec<char>>, i: usize, j: usize) -> bool {
        if j == 9 {
            return true;
        }
        if board[i][j] != '.' {
            if i + 1 == 9 {
                return Self::solve_su_rec(board, 0, j + 1);
            }
            return Self::solve_su_rec(board, i + 1, j);
        }
        let avaible = Self::get_available(&board, i, j);
        for maybe in avaible {
            board[i][j] = maybe;
            if i + 1 == 9 {
                if Self::solve_su_rec(board, 0, j + 1) {
                    return true;
                }
                continue;
            }
            if Self::solve_su_rec(board, i + 1, j) {
                return true;
            }
        }
        board[i][j] = '.';
        false
    }

    pub fn pretty_print(board: & Vec<Vec<char>>) {
        for row in board {
            for c in row {
                print!("{}|", c);
            }
            println!("\n------------------");
        }
    }

    pub fn solve_sudoku(board: &mut Vec<Vec<char>>) {
        Self::solve_su_rec(board, 0, 0);
    }
}
