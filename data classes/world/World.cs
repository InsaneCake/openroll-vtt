using System;
using System.Collections.Generic;
using Godot;

public partial class World : Node
{
    List<Location> locations = new();

    public List<Location> Locations
    {
        get => locations;
        set => locations = value;
    }
}
