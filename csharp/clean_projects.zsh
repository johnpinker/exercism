#!/bin/zsh

for x in *; do 
	if [ -d "$x" ]; then
		cd $x
		dotnet clean
		cd ..
	fi
done 


