using System;
using System.Collections.Generic;
using UnityEngine;

using Grandma;

namespace Sanguine
{
    public class Placeable : SanguinePositionable
    {
        /*
        [NonSerialized]
        private PlaceableData placeableData;

        public override GrandmaComponentData Data
        {
            get => base.Data;

            protected set
            {
                base.Data = value;

                placeableData = Data as PlaceableData;
            }
        }
        */

        protected override void OnPlaced(SanguineTile tile)
        {
            base.OnPlaced(tile);

            tile.OnPlaceableAdded(this);
        }

        protected override void OnRemoved(SanguineTile tile)
        {
            base.OnRemoved(tile);

            tile.OnPlaceableRemoved();
        }
    }
}
