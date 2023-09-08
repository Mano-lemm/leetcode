#!/usr/bin/env bash

cat 0193-valid_phone_numbers.txt | grep -P '^\d{3}-\d{3}-\d{4}$|^\(\d{3}\) \d{3}-\d{4}$'
