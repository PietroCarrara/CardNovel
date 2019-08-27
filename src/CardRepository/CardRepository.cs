using Godot;
using System;
using CardNovel.Cards;

namespace CardNovel.Repository
{
    public class CardRepository
    {
        private static CardRepository instance;

        private PackedScene cardScene;

        public static CardRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new CardRepository();
            }

            return instance;
        }

        private CardRepository()
        {
            this.cardScene = GD.Load<PackedScene>("res://src/Card/Card.tscn");
        }

        public Card GetByName(string name)
        {
            var res = GD.Load<CardInfo>($"res://res/cards/{name}.tres");
            var cardScene = (Card)this.cardScene.Instance();

            cardScene.SetResource(res);

            return cardScene;
        }
    }
}
