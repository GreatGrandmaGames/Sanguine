﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Grandma.Tiles;

public class TileMapDev : MonoBehaviour
{
    public TileMap map;
    public GameObject tempTilePrfab;

    private void Awake() { }

    private void Start()
    {
        Tile start = map.AllTiles[0];
        Tile end = map.AllTiles[73];

        Debug.Log("AStarPath Test: Starting at " + start.Position + " and ending at " + end.Position);

        var path = map.GetPath(start, end)?.ValidPath;

        for (int i = 0; i < path.Count - 1; i++ )
        {
            Debug.LogFormat("Current {0} Next {1} Diff {2}", path[i].Position, path[i + 1].Position, path[i + 1].Position - path[1].Position);
        }

        //tileObjs[start.Position].GetComponentInChildren<Renderer>().material.color = Color.blue;
        //tileObjs[end.Position].GetComponentInChildren<Renderer>().material.color = Color.green;


        /*
        Debug.Log("Pre add");
        Debug.Log(t.TileConnections.LinkedComponents.Count);
        Debug.Log(t.TileConnections.Data);

        t.TileConnections.Add(new GrandmaAssociationData() {
           OtherComponentID = tile2.ComponentID,

        });

        tile2.TileConnections.Add(new GrandmaAssociationData()
        {
            OtherComponentID = t.ComponentID,
        });

        Debug.Log("Pre write");
        Debug.Log(t.TileConnections.LinkedComponents.Count);
        Debug.Log(t.TileConnections.Data);

        t.TileConnections.Refresh();

        Debug.Log("Post wrtie");
        Debug.Log(t.TileConnections.LinkedComponents.Count);
        Debug.Log(t.TileConnections.Data);
        */
    }

}