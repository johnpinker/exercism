class School {
  type DB = Map[Int, Seq[String]]

  var _db:DB = Map()

  def add(name: String, g: Int) = {
    if (this._db.keys.exists(_ == g)) {
      var names = this._db.get(g)
      if (names.nonEmpty) {
        var tmpNames:Seq[String] = names.get
        tmpNames = tmpNames :+ name
        this._db = this._db - g
        this._db = this._db + (g -> tmpNames)
      }
    } else {
      this._db = this._db + (g -> Seq(name))
    }
  }

  def db: DB = this._db

  def grade(g: Int): Seq[String] =  {
    if (this._db.get(g).nonEmpty) {
      this._db.get(g).head
    } else {
      Seq()
    }
  }

  def sorted: DB = {
    var v:DB = Map()
    this._db.toSeq.sortBy(_._1).foreach(x => { v = v + (x._1 -> x._2.sortWith(_ < _)) })
    v
  }
}
