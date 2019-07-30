object SpaceAge {

  def onEarth(secondAge: Double): Double = secondAge/31557600.0
  def onMercury(secondAge: Double): Double = onEarth(secondAge) / 0.2408467
  def onVenus(secondAge: Double): Double = onEarth(secondAge) / 0.61519726
  def onMars(secondAge: Double): Double = onEarth(secondAge) / 1.8808158
  def onJupiter(secondAge: Double): Double = onEarth(secondAge) / 11.862615
  def onSaturn(secondAge: Double): Double = onEarth(secondAge) / 29.447498
  def onUranus(secondAge: Double): Double = onEarth(secondAge) / 84.016846
  def onNeptune(secondAge: Double): Double = onEarth(secondAge) / 164.79132
}
