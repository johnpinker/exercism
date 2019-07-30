class Bob {
    hey(message: string) {

      message = message.trim();
      let punctuation = message.charAt(message.length-1);
      //console.log("Punctuation:  " + punctuation);

      const regex = new RegExp(/[ \,.!?\n\r\t]/);
      let words = message.split(regex).filter((word) => word.length == 0 ? false : true);

      //const regex = new RegExp(/(?<!\\)[a-zA-Z-']+/);
      //const regex = new RegExp(/\w+/);
      //var words = message.match(regex);
      let capWordCount = 0;
      let allCaps = false;
      let numWords = 0;
      if (words != null) {
        //words.map((word) => console.log("word is: " + word + " length is: " + word.length));
        //console.log("length: " + words.length);
        capWordCount = words.reduce((capWords, word) => {
          return( (word == word.toUpperCase() && word.match(/[0-9]+/) == null) ? capWords + 1 : capWords); 
        }, 0);
        numWords = words.reduce((wrd, word) => {
          return((word.match(/.+/) != null && word.match(/[0-9]+/) == null )? wrd + 1 : wrd); 
        }, 0);
        //console.log("regular  word count: " + numWords);
        //console.log("Cap  word count: " + capWordCount);
        //numWords = words.length;
        allCaps = (capWordCount == numWords && capWordCount > 0) ? true : false;
      }

      if (words != null && words.length == 0) {
        return "Fine. Be that way!";
      }
      else if (allCaps && punctuation != "?")
      {
        return "Whoa, chill out!";
      }
      else if (allCaps && punctuation == "?") {
        return "Calm down, I know what I'm doing!";
      }
      else if (punctuation == "?") {
        return "Sure.";
      }
      else {
        return "Whatever.";
      }

    }
}

export default Bob
