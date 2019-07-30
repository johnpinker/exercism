/*
Package acronym to provide a solution to the go exercise acronym
*/
package acronym

import (
	"strings"
)

/*
given a character, return whether it is whitespace or not
*/
func isWhiteSpace(b byte) bool {
	if b == ' ' || b == '-' || b == '_' {
		return true
	}
	return false

}

/*
Given a string and where to start looking within it, return the next character
and the position that was searched until
*/
func getNextChar(s string, i int) (byte, int) {
	var sc byte
	for !isWhiteSpace(s[i]) && i < len(s)-1 {
		i++
	}
	for isWhiteSpace(s[i]) && i < len(s)-1 {
		i++
	}
	if i != len(s)-1 {
		sc = s[i]
	} else {
		sc = 0
	}
	return sc, i
}

/*
Abbreviate given a string s, return a string representing its abbreviation
*/
func Abbreviate(s string) string {
	var i = 1
	var sb strings.Builder
	var tmpByte byte
	var rs string
	sb.WriteByte(s[0])
	for i < len(s)-1 {
		tmpByte, i = getNextChar(s, i)
		if tmpByte != 0 {
			sb.WriteByte(tmpByte)
		}
	}
	rs = sb.String()
	rs = strings.ToUpper(rs)
	return rs
}
