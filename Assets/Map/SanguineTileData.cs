using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Grandma.Tiles;

namespace Sanguine
{
    [CreateAssetMenu(menuName = "Sanguine/Tile")]
    public class SanguineTileData : TileData
    {
        //Temp
        public float[] color;

        //Temp 
        public float zPos;

        public float walkSpeed;

        public string placeableID;
    }
}
