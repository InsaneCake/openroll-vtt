using System;
using Godot;

public partial class ProjectEditor : Control
{
    static void Log(string msg) => GD.PrintRich($"[color=#FFB74D]ProjectEditor:[/color]{msg}");

    public void LoadProject(string path)
    {
        Log($"Loading project {path}");
    }
}
