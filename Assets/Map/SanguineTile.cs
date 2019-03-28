using Grandma;
using Grandma.Tiles;
using System;
using UnityEngine;

namespace Sanguine
{
    public class SanguineTile : Tile
    {
        //Private variable
        [NonSerialized]
        private SanguineTileData sanguineTileData;

        public Placeable Placeable { get; private set; }

        #region Overrides
        //Properties
        public override GrandmaComponentData Data
        {
            get => base.Data;

            protected set
            {
                base.Data = value;

                sanguineTileData = Data as SanguineTileData;
            }
        }

        protected override void OnRead(GrandmaComponentData data)
        {
            base.OnRead(data);

            Placeable = GrandmaObjectManager.Instance.GetComponentByID<Placeable>(sanguineTileData.placeableID);

            if(Placeable != null)
            {
                Placeable.transform.position = transform.position;
            }

            //Temp?
            sRenderer.color = new Color(sanguineTileData.color[0], sanguineTileData.color[1], sanguineTileData.color[2], sanguineTileData.color[3]);
        }
        #endregion

        //Writing method
        public void OnPlaceableAdded(Placeable newPlaceable)
        {
            if(newPlaceable != null)
            {
                sanguineTileData.placeableID = newPlaceable.ComponentID;

                Refresh();
            }
        }

        //Writing method
        public void OnPlaceableRemoved()
        {
            if(Placeable != null)
            {
                sanguineTileData.placeableID = "";

                Refresh();
            }
        }
    }
}
