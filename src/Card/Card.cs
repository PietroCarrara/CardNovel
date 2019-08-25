using Godot;
using System;
using System.Diagnostics;

namespace CardNovel.Cards
{
    public class Card : Node2D
    {
        [Export]
        public Texture Art;

        [Export]
        public string Title;

        private Container infoContainer;

        public override void _Ready()
        {
            validateAtrributes();

            var title = this.GetNode<Label>("ViewRoot/InfoContainer/CardTitle");
            title.Text = this.Title;

            var art = this.GetNode<TextureRect>("ViewRoot/ArtContainer/CardArt");
            art.Texture = this.Art;

            this.infoContainer = this.GetNode<Container>("ViewRoot/InfoContainer");
        }

        public void ArtHoverHandlerMouseEntered()
        {
            this.infoContainer.Show();
        }

        public void ArtHoverHandlerMouseExited()
        {
            this.infoContainer.Hide();
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