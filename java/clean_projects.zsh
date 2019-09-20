#!/bin/zsh

for x in *; do 
	if [ -d "$x" ]; then
		cd $x
		gradle clean
		cd ..
	fi
done 


