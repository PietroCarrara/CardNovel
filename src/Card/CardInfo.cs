using Godot;
using System;

namespace CardNovel.Cards
{
    public class CardInfo : Resource
    {
        [Export]
        public string Title;
        [Export]
        public Texture Art;
    }
}
