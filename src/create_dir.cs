  /// <summary>create a new directory in your system</summary>
  public void create_dir(string path)
  {
    string directoryName = Path.GetDirectoryName(path);
    if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
    {
      Directory.CreateDirectory(directoryName);
    }
  }
