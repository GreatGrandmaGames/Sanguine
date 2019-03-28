using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Grandma;
using Grandma.Tiles;

namespace Sanguine
{
    public class SanguineMoveable : SanguinePositionable
    {
        [NonSerialized]
        private SanguineMoveableData moveData;

        private SanguineTile target;
        private AStarPath path;

        public override GrandmaComponentData Data
        {
            get => base.Data;

            protected set
            {
                base.Data = value;

                moveData = Data as SanguineMoveableData;
            }
        }

        protected override void OnRead(GrandmaComponentData data)
        {
            var prevTarget = target;

            base.OnRead(data);

            target = GrandmaObjectManager.Instance.GetComponentByID<SanguineTile>(moveData.targetTileID);

            if (prevTarget != target)
            {
                if(path != null)
                {
                    //Cancel navigation
                }

                if(target != null)
                {
                    path = new AStarPath(CurrentTile.TileMap, CurrentTile, target);

                    if (path.ValidPath != null)
                    {
                        StartCoroutine(NavigationCoroutine(path.ValidPath.OfType<SanguineTile>().ToList(), target));
                    }
                }
            }
        }

        //Writing Method
        public void NavigateTo(SanguineTile tile)
        {
            //Ensure tiles exist and are on the same map
            if(CurrentTile != null && tile != null && CurrentTile.TileMap == tile.TileMap)
            {
                moveData.targetTileID = tile.ComponentID;

                Refresh();
            }
        }

        //Writing Method
        public void CancelNavigate()
        {
            moveData.targetTileID = "";

            Refresh();
        }

        private IEnumerator NavigationCoroutine(List<SanguineTile> tiles, SanguineTile target)
        {
            int i = 0;

            while(CurrentTile != target)
            {
                i++;
                Place(tiles[i]);

                yield return new WaitForSeconds(1f / moveData.moveSpeed);
            }
        }
    }
}
