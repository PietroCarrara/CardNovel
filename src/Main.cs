using Godot;
using System;
using CardNovel.Cards;

namespace CardNovel
{
    public class Main : Node2D
    {
        [Export]
        public PackedScene CardScene;

        [Export]
        public Texture DefaultArt;

        public override void _Ready()
        {
            var card = (Card)this.CardScene.Instance();

            card.Art = this.DefaultArt;
            card.Title = "Seila :D";

            this.AddChild(card);
        }
    }
}