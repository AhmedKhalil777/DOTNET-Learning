using System;
using System.IO;
using System.Linq;

record FilePath : IEquatable<FilePath>
{
    public string Path {get;}

    public FilePath (string path)
    {
        Path = string.IsNullOrWhiteSpace(path) ? throw new ArgumentException("path must not be null or a white space")
        : System.IO.Path.GetInvalidPathChars().Intersect(path).Any() ?  throw new ArgumentException("path contains illegal characters")
        : System.IO.Path.GetFullPath(path.Trim());
    }

    public override string ToString() => Path;

    
    public virtual bool Equals(FilePath? other) => (Path).Equals(other?.Path, StringComparison.InvariantCultureIgnoreCase);

    public override int GetHashCode() => Path.ToLowerInvariant().GetHashCode(); 

    public static implicit operator FilePath(string name) => new FilePath(name);
    public FileInfo GetInfo() => new FileInfo(Path);

    public FilePath Compine(params string[] paths) => System.IO.Path.Combine(paths.Prepend(Path).ToArray());

}