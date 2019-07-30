// Package twofer represents a solution to the two-fer problem
package twofer

// ShareWith returns response based on name
func ShareWith(name string) string {

	s := "you"
	if name != "" {
		s = name
	}
	return "One for " + s + ", one for me."
}
