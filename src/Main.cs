using Godot;
using CardNovel.Repository;
using CardNovel.UI;
using System.Collections.Generic;
using CardNovel.Cards;

namespace CardNovel
{
    public class Main : Node2D
    {
        private PlayerHand hand;

        public override void _Ready()
        {
            var cardRepository = CardRepository.GetInstance();

            var cards = new List<Card>();

            cards.Add(cardRepository.GetByName("The Mailman"));
            cards.Add(cardRepository.GetByName("The Mailman"));
            cards.Add(cardRepository.GetByName("The Mailman"));

            hand = this.GetNode<PlayerHand>("UI/PlayerHand");
            hand.AddChildRange(cards);
        }

        public override void _Process(float delta)
        {
            var cr = CardRepository.GetInstance();

            if (Input.IsActionJustPressed("add_card"))
            {
                hand.AddChild(cr.GetByName("The Mailman"));
            }
        }
    }
}