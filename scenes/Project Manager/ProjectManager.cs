using System;
using System.IO;
using Godot;

public partial class ProjectManager : Control
{
    string[] projectDirs = new string[]
    {
        "world",
        "characters/players",
        "characters/npcs",
        "bestiary/monsters",
        "spellbook/spells",
        "items",
        "campaigns",
    };

    public void NewWorld(string path)
    {
        GD.Print("Creating world at: ", path);

        var dirAcc = DirAccess.Open(path);

        foreach (string dir in projectDirs)
        {
            GD.Print("Creating directory: ", dir);
            dirAcc.MakeDirRecursive(dir);
        }

        LoadWorld(path);
    }

    public void LoadWorld(string path)
    {
        GD.Print("Loading world at: ", path);
    }
}
