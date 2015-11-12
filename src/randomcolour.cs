    /// <summary>new random number</summary>
  private readonly Random rand = new Random();
  
  /// <summary>assign new random color</summary>
  private Color RandomColour()
  {
    return Color.FromArgb(this.rand.Next(256), this.rand.Next(256), this.rand.Next(256));
  }
