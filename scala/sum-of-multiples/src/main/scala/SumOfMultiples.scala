object SumOfMultiples {

  def sum(factors: Set[Int], limit: Int): Int = (1 until limit)
    .filter(i => factors.exists(j => {i%j == 0}))
    .sum

  /*
  def isDivBy(x: Int, y: Int): Boolean = {
    if (x == 0 || y ==0) {
      false
    } else if (y % x == 0) {
      true
    } else {
      false
    }
  }

  def sumInSet(factors: Set[Int], currentNum: Int ): Int = {
    if (factors.nonEmpty) {
      if (isDivBy(factors.head, currentNum)) {
        currentNum
      } else {
        sumInSet(factors.tail, currentNum)
      }
    } else {
      0
    }
  }

  def sum(factors: Set[Int], limit: Int): Int = {
    if (limit != 1) {
      sumInSet(factors, limit-1) + sum(factors, limit-1)
    } else {
      0
    }
  }
   */
}

