

//
// This is only a SKELETON file for the 'Resistor Color Duo' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

//export const value = (colorList) => parseInt(resistorListValue(colorList, 0));
export const value = (colorList) => parseInt(colorList.reduce((val, x) => val.toString() + COLORS.indexOf(x).toString(), ""));

const COLORS = ["black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"];

function resistorListValue(listVals, listIndex) {
    if (listIndex >= listVals.length) return "";
    else {
      return COLORS.indexOf(listVals[listIndex]).toString() + resistorListValue(listVals, listIndex+1);
    }
}