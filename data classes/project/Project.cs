using System;
using System.Collections.Generic;
using Godot;

public partial class Project() : GodotObject
{
    string name;

    public string Name
    {
        get => name;
        set => name = value;
    }

    World world;

    public World World
    {
        get => world;
        set => world = value;
    }

    List<Spell> spellbook;

    public List<Spell> Spellbook
    {
        get => spellbook;
        set => spellbook = value;
    }

    List<Monster> bestiary;

    public List<Monster> Bestiary
    {
        get => bestiary;
        set => bestiary = value;
    }

    string dirPath;

    public string DirPath
    {
        get => dirPath;
        set => dirPath = value;
    }
}
