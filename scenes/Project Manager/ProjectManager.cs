using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Godot;

public partial class ProjectManager : Control
{
    [Signal]
    public delegate void ProjectSelectedEventHandler(string path);

    string[] projectDirs = new string[]
    {
        "world/locations",
        "characters/players",
        "characters/npcs",
        "bestiary/monsters",
        "spellbook/spells",
        "items",
        "campaigns",
        "assets",
    };

    string recentProjectsListFilePath = Path.Combine(
        OS.GetUserDataDir(),
        "cfg",
        "recent_projects.ini"
    );

    string latestProjectDir = "";

    List<string> recentProjects = [];

    [Export]
    VBoxContainer RecentProjectsContainer;

    [Export]
    FileDialog NewProjectDialog;

    [Export]
    FileDialog OpenProjectDialog;

    static void Log(string msg) => GD.PrintRich($"[color=#7986CB]ProjectManager:[/color]{msg}");

    public override void _Ready()
    {
        LoadRecentProjects();
    }

    public void NewWorld(string path)
    {
        Log($"Creating world at: {path}");

        var dirAcc = DirAccess.Open(path);

        foreach (string dir in projectDirs)
        {
            Log($"Creating directory: {dir}");
            dirAcc.MakeDirRecursive(dir);
        }

        LoadWorld(path);
    }

    public void LoadWorld(string path)
    {
        Log($"Loading world at: {path}");
        recentProjects.Remove(path);
        recentProjects.Insert(0, path);
        SaveRecentProjectsList();
        EmitSignal(SignalName.ProjectSelected, path);
    }

    void LoadRecentProjects()
    {
        Log($"Loading recent projects list from: {recentProjectsListFilePath}");
        if (File.Exists(recentProjectsListFilePath))
        {
            recentProjects = File.ReadAllLines(recentProjectsListFilePath).ToList();
        }

        if (recentProjects.Count != 0)
        {
            latestProjectDir = Directory.GetParent(recentProjects[0]).FullName;
            NewProjectDialog.RootSubfolder = latestProjectDir;
            OpenProjectDialog.RootSubfolder = latestProjectDir;
        }

        UpdateRecentProjectsButtons();
    }

    void SaveRecentProjectsList()
    {
        Log($"Saving recent projects list to: {recentProjectsListFilePath}");
        Directory.CreateDirectory(Path.GetDirectoryName(recentProjectsListFilePath));
        File.WriteAllLines(recentProjectsListFilePath, recentProjects.ToArray());
        UpdateRecentProjectsButtons();
    }

    void UpdateRecentProjectsButtons()
    {
        Helpers.ClearNode(RecentProjectsContainer);
        foreach (string path in recentProjects)
        {
            Button _b = new()
            {
                Text = path,
                Alignment = HorizontalAlignment.Left,
                Flat = true,
            };

            if (Directory.Exists(path) == false)
            {
                _b.Disabled = true;
            }
            else
            {
                _b.Pressed += () => LoadWorld(path);
            }

            RecentProjectsContainer.AddChild(_b);
        }
    }
}
