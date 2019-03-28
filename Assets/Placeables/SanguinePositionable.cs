using System;
using System.Collections.Generic;
using UnityEngine;

using Grandma;
using Grandma.Tiles;

namespace Sanguine
{
    public class SanguinePositionable : GrandmaComponent
    {
        [SerializeField] protected SpriteRenderer sRenderer;

        public SanguineTile CurrentTile { get; private set; }
        public TileMap TileMap
        {
            get
            {
                return CurrentTile.TileMap;
            }
        }

        [NonSerialized]
        private SanguinePositionableData posData;

        public override GrandmaComponentData Data
        {
            get => base.Data;

            protected set
            {
                base.Data = value;

                posData = Data as SanguinePositionableData;
            }
        }

        protected override void OnRead(GrandmaComponentData data)
        {
            var prevTile = CurrentTile;

            base.OnRead(data);

            CurrentTile = GrandmaObjectManager.Instance.GetComponentByID<SanguineTile>(posData.currentTileID);

            if (CurrentTile != prevTile)
            {
                if (CurrentTile != null)
                {
                    OnPlaced(CurrentTile);
                }
                else
                {
                    OnRemoved(prevTile);
                }
            }
        }

        protected virtual void OnPlaced(SanguineTile tile)
        {
            if (sRenderer != null)
            {
                sRenderer.enabled = true;
            }

            transform.position = tile.transform.position;
        }

        protected virtual void OnRemoved(SanguineTile tile)
        {
            if (sRenderer != null)
            {
                sRenderer.enabled = false;
            }
        }

        public void Place(SanguineTile tile)
        {
            if (CanPlace(tile))
            {
                posData.currentTileID = tile.ComponentID;

                Refresh();
            }
        }

        public void Remove()
        {
            if (CanRemove())
            {
                posData.currentTileID = "";

                Refresh();
            }
        }

        public virtual bool CanPlace(SanguineTile tile)
        {
            return tile != null;
        }

        public virtual bool CanRemove()
        {
            return CurrentTile != null;
        }
    }
}
