object Bob {


  def response(statement: String): String = statement.replaceAll("\\s+", "") match {
    case x if x.isEmpty => "Fine. Be that way!"
    case x if (x.toUpperCase equals x) && (x endsWith "?") && !(x.toLowerCase equals x) => "Calm down, I know what I'm doing!"
    case x if (x.toUpperCase equals x) && !(x.toLowerCase equals x) => "Whoa, chill out!"
    case x if x endsWith "?" => "Sure."
    case _ => "Whatever."
  }

}
