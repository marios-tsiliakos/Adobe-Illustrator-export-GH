  private void RunScript(List<Curve> curves, int series, string name, string layername, string filepath, bool execute)
  {
    if (!execute)return;

    else
    {
      //check
      for (int i = 0; i < curves.Count;i++){
        if ((curves.Count == 0) || (curves[i] == null))
        {
          Print("No curves or valid curves provided");
          return;
        }
      }
      //create alist of guids
      List<Guid> mycurves = new List<Guid>();
      // layer to bake the objects to
      create_layer(layername);
      //create a directory to store the ai files
      create_dir(filepath);

      for(int i = 0; i < curves.Count; i++){
        //declare the objects attributes
        Rhino.DocObjects.ObjectAttributes attr = new Rhino.DocObjects.ObjectAttributes();
        //set attributes
        attr.LayerIndex = doc.Layers.Find(layername, true);

        Guid id = Guid.Empty;

        //bake the curves
        if(curves[i].ObjectType == Rhino.DocObjects.ObjectType.Curve)
        {
          id = doc.Objects.AddCurve((Curve) curves[i], attr);
        }

        // add the curves to the mycurve_guid list
        if(id.ToString().Length > 0) mycurves.Add(id);
      }
      // select the curves in Rhino to successfully export them
      for(int i = 0; i < mycurves.Count; i++)
      {
        doc.Objects.Select(mycurves[i], true);
      }
      //where to save
      string save_directory = filepath + ("\\" + name) + series.ToString("0000") + ".ai";
      //and export them
      Rhino.RhinoApp.RunScript("-_Export\n\"" + save_directory + "\"\n _Enter", false);
      //delete the curves after exporting them
      for(int i = 0; i < mycurves.Count; i++) doc.Objects.Delete(mycurves[i], true);
    }
  }
