// Package bob solution to the bob exercise
package bob

import "strings"

// hasLetters given a string return whether it has (letters, numbers)
func hasLetters(str string) (bool, bool) {
	var hasChar bool
	var hasNum bool
	for _, v := range str {
		if (v >= 'a' && v <= 'z') || (v >= 'A' && v <= 'Z') {
			hasChar = true
		} else if v >= 0 && v <= 9 {
			hasNum = true
		}
	}
	return hasChar, hasNum
}

// Hey returns a message given a message
func Hey(remark string) string {
	trimStr := strings.TrimSpace(remark)
	var c byte
	var retVal = "Fine. Be that way!"
	if len(trimStr) > 0 {
		c = trimStr[len(trimStr)-1]
	} else {
		return retVal
	}

	var hasChar, hasNum bool = hasLetters(remark)
	if strings.ToUpper(remark) == remark && hasChar && c == '?' {
		retVal = "Calm down, I know what I'm doing!"
	} else if c == '?' {
		retVal = "Sure."
	} else if strings.ToUpper(remark) == remark && hasChar {
		retVal = "Whoa, chill out!"
	} else if !hasChar && !hasNum && c == '.' {
		retVal = "Fine. Be that way!"
	} else {
		retVal = "Whatever."
	}
	return retVal
}
