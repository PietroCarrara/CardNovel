using Godot;
using System;
using CardNovel.Repository;

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
            var cardRepository = CardRepository.GetInstance();
            var card = cardRepository.GetByName("The Mailman");
            this.AddChild(card);
        }
    }
}