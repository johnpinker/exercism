//
// This is only a SKELETON file for the 'Space Age' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const age = (planet, ageVal) => {
  let retVal
  switch(planet) {
    case "earth": retVal = earthAge(ageVal); break;
    case "mercury": retVal = earthAge(ageVal)/0.2408467; break;
    case "venus": retVal = earthAge(ageVal)/0.61519726; break;
    case "mars": retVal = earthAge(ageVal)/1.8808158; break;
    case "jupiter": retVal = earthAge(ageVal)/11.862615; break;
    case "saturn": retVal = earthAge(ageVal)/29.447498; break;
    case "uranus": retVal = earthAge(ageVal)/84.016846; break;
    case "neptune": retVal = earthAge(ageVal)/164.79132; break;
  }
  return strip(retVal);
};
const earthAge = (ageVal) => ageVal/31557600;

function strip(v) {
  return parseFloat(v.toFixed(2));
}
