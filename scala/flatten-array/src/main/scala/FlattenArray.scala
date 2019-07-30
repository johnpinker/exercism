object FlattenArray {

  def flatten(x: List[Any]): List[Any] = flattenRec(x).filter(v => v != null)

  def flattenRec(x: List[Any]): List[Any] = {
  x match {
    case Nil => Nil
    case (head: List[_]) :: tail => flattenRec(head) ++ flattenRec(tail)
    case head :: tail => head :: flattenRec(tail)
  }
}
}