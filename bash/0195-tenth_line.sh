#!/usr/bin/env bash

sed '10q;d' ./0195-tenth_line.txt

awk 'NR == 10' ./0195-tenth_line.txt
