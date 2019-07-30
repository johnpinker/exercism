package space

// Planet string type used for planet
type Planet string

// Age returns the number of years of age on planet given seconds
func Age(seconds float64, planet Planet) float64 {
	fp := func(sec2 float64) float64 {
		return Age(sec2, "Earth")
	}
	switch planet {
	case "Earth":
		return seconds / 31557600
	case "Mercury":
		return fp(seconds) / 0.2408467
	case "Venus":
		return fp(seconds) / 0.61519726
	case "Mars":
		return fp(seconds) / 1.8808158
	case "Jupiter":
		return fp(seconds) / 11.862615
	case "Saturn":
		return fp(seconds) / 29.447498
	case "Uranus":
		return fp(seconds) / 84.016846
	case "Neptune":
		return fp(seconds) / 164.79132
	default:
		return 0.0
	}
}
