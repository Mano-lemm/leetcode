#!/usr/bin/env bash

cat ./0192-words.txt | tr -s [:blank:] '\n' | sort | uniq -c | sort -r | awk '{print $2" "$1}'
