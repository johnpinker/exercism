//
// This is only a SKELETON file for the 'Pangram' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const isPangram = (testStr) => {
  let charSet = new Set();
  [...testStr].forEach(element => {
    let tmpChar = element.toLowerCase();

    if (isChar(tmpChar))
      charSet.add(tmpChar);
  });
  return charSet.size == 26;
};

const isChar = (c) => (c.charCodeAt(0) >= 'a'.charCodeAt(0) && c.charCodeAt(0) <= 'z'.charCodeAt(0)); 
