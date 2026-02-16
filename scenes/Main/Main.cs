using System;
using Godot;

public partial class Main : Control
{
    [Export]
    ProjectManager projectManager;

    [Export]
    ProjectEditor projectEditor;

    public void onProjectManagerProjectSelected(string path)
    {
        projectEditor.LoadProject(path);
        projectEditor.Show();
        projectManager.Hide();
    }
}
