using Godot;
using System;
using System.Collections.Generic;

public static class NodeExtensions
{

    public static void AddChildRange(this Node self, IEnumerable<Node> range)
    {
        foreach (var child in range)
        {
            self.AddChild(child);
        }
    }
}
