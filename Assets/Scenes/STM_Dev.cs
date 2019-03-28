using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sanguine;

public class STM_Dev : MonoBehaviour
{
    public SanguineTileMap stm;
    public SanguineAgent agentPrefab;

    private void Start()
    {
        var randTile = stm.TileAt(Random.Range(0, stm.Width), Random.Range(0, stm.Height)) as SanguineTile;
        var randTile2 = stm.TileAt(Random.Range(0, stm.Width), Random.Range(0, stm.Height)) as SanguineTile;

        SanguineAgent agent = Instantiate(agentPrefab);
        agent.Moveable.Place(randTile);

        agent.Moveable.NavigateTo(randTile2);
    }
}
