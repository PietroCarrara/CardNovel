using Godot;
using System;

public class InfoContainer : PanelContainer
{
    public override void _Ready()
    {
        var modulate = this.Modulate;
        modulate.a = 0;

        this.Modulate = modulate;
    }
}
