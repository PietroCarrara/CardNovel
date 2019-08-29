using Godot;
using System;
using System.Diagnostics;

namespace CardNovel.Cards
{
    public class Card : Control
    {
        [Export]
        public Texture Art;

        [Export]
        public string Title;

        private AnimationPlayer infoContainer;


        public virtual void OnPlay()
        {}
        public virtual void OnDiscard()
        {}

        public override void _Ready()
        {
            validateAtrributes();

            var title = this.GetNode<Label>("InfoContainer/CardTitle");
            title.Text = this.Title;

            var art = this.GetNode<TextureRect>("ArtContainer/CardArt");
            art.Texture = this.Art;

            this.infoContainer = this.GetNode<AnimationPlayer>("InfoContainer/AnimationPlayer");
        }

        public void SetResource(CardInfo info)
        {
            this.Art = info.Art;
            this.Title = info.Title;
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
            if (this.Title == "") {
                throw new Exception("The card title can't be empty!");
            }

            if (this.Art == null) {
                throw new Exception("The card art can't be empty!");
            }
        }
    }
}