using Grandma;
using UnityEngine;

namespace Sanguine
{
    [RequireComponent(typeof(SanguineMoveable))]
    public class SanguineAgent : Agent
    {
        public SanguineMoveable Moveable { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            Moveable = GetComponent<SanguineMoveable>();
        }

    }
}
