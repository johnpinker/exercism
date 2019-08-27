#!/bin/zsh

for x in *; do cd $x; dotnet clean; ..; done


