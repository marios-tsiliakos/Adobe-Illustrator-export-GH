  /// <summary>check if the specified layer exists and if not create it.</summary>
  private void create_layer(string l)
  {
    int layerslist = doc.Layers.Find(l, true);

    if(layerslist < 0){
      Rhino.DocObjects.Layer l0 = new Rhino.DocObjects.Layer();
      System.Drawing.Color m_color = RandomColour();
      l0.Color = m_color;
      l0.Name = l;
      layerslist = doc.Layers.Add(l0);
    }
  }
