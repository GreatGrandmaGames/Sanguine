using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sanguine
{
    [Serializable]
    public class SanguineMoveableData : SanguinePositionableData
    {
        public string targetTileID;

        public float moveSpeed = 1f;
    }
}