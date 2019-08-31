using Godot;
using System;
using System.Diagnostics;

namespace CardNovel.Cards
{
    public class Card : Control
    {
        private CardInfo info;
        private AnimationPlayer infoContainer;

        [Export]
        public CardInfo Info
        {
            get => info;
            set
            {
                this.info = value;

                var title = this.GetNode<Label>("InfoContainer/CardTitle");
                title.Text = info.Title;

                var art = this.GetNode<TextureRect>("ArtContainer/CardArt");
                art.Texture = info.Art;
            }
        }

        public override void _Ready()
        {
            validateAtrributes();

            this.infoContainer = this.GetNode<AnimationPlayer>("InfoContainer/AnimationPlayer");
        }

        public void OnMouseEntered()
        {
            this.infoContainer.Play("Appear");
        }

        public void OnMouseExited()
        {
            this.infoContainer.Play("Disappear");
        }

        [Conditional("DEBUG")]
        private void validateAtrributes()
        {
            if (this.Info.Title == "") {
                throw new Exception("The card title can't be empty!");
            }

            if (this.Info.Art == null) {
                throw new Exception("The card art can't be empty!");
            }
        }
    }
}