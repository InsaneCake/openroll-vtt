using System.IO;
using Godot;

public partial class Helpers : Node
{
    public static void ClearNode(Node node)
    {
        foreach (var child in node.GetChildren())
        {
            node.RemoveChild(child);
            child.QueueFree();
        }
    }

    public static void DirRecursiveDelete(DirectoryInfo baseDir)
    {
        if (!baseDir.Exists)
        {
            GD.PrintErr("Path does not exists!");
            return;
        }

        foreach (var dir in baseDir.EnumerateDirectories())
        {
            DirRecursiveDelete(dir);
        }
        baseDir.Delete(true);
    }
}
