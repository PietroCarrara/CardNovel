using Godot;
using CardNovel.Cards;
using System.Collections.Generic;
using System;

namespace CardNovel.UI
{
    public class PlayerHand : Container
    {
        private Container container;

        private List<Card> cards;

        public override void _Notification(int what)
        {
            switch (what)
            {
                case NotificationSortChildren:
                    this.SortChildren();
                    break;
            }
        }

        private void SortChildren()
        {
            var children = this.GetChildren();
            float total = children.Count;

            int i = 0;
            foreach (Card child in children)
            {
                var maxIndex = total - 1;
                // The leftmost card should have this value as -1,
                // the middlemost should have this as 0,
                // and the rightmost should be 1
                var range = (i - maxIndex / 2) / (maxIndex < 1 ? 1 : maxIndex / 2);

                var cardSize = child.GetSize() * 0.5f;

                // Center position
                var position = (new Vector2(cardSize.x, 0) * i) -
                               ((new Vector2(total * cardSize.x, 0)) / 2);

                var rect = new Rect2(position, child.GetSize());

                this.FitChildInRect(child, rect);
                child.RectPivotOffset = new Vector2(rect.Size.x / 2f, rect.Size.y);
                child.SetRotationDegrees(45 * range);

                i++;
            }
        }
    }
}