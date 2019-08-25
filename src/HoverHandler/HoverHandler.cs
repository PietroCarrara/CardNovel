using Godot;
using System;
using System.Diagnostics;

public class HoverHandler : Node2D
{
    [Signal]
    delegate void MouseEntered();

    [Signal]
    delegate void MouseExited();

    [Export]
    public readonly float Width = 0;

    [Export]
    public readonly float Height = 0;

    [Export]
    public readonly bool FillParent = true;

    [Export]
    public readonly bool DrawDebug = false;

    private Rect2 hitbox;

    private bool mouseInside = false;

    public override void _Ready()
    {
        if (this.FillParent)
        {
            var parent = this.GetParent();

            if (parent is Control c)
            {
                this.hitbox = c.GetRect();
            }
            else
            {
                throw new Exception("HoverHandler not implemented for " + parent.GetType() + "!");
            }
        }
        else
        {
            this.hitbox = new Rect2(this.GetPosition(), new Vector2(this.Width, this.Height));
        }
    }

    public override void _Process(float delta)
    {
        var isInside = this.hitbox.HasPoint(this.GetLocalMousePosition());

        if (isInside != this.mouseInside)
        {
            if (isInside)
            {
                this.EmitSignal(nameof(MouseEntered));
            }
            else
            {
                this.EmitSignal(nameof(MouseExited));
            }
        }

        this.mouseInside = isInside;
    }

    public override void _Draw()
    {
        this.DoDrawDebug();
    }

    [Conditional("DEBUG")]
    public void DoDrawDebug()
    {
        if (this.DrawDebug)
        {
            this.DrawRect(this.hitbox, Color.ColorN("blue", .2f), true);
        }
    }
}
