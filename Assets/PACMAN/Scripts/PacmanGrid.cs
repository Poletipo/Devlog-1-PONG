using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanGrid : MonoBehaviour {
    public enum TilesStates {
        Wall,
        Empty,
        Pellet,
        SuperPellet
    }

    public Vector2Int GridResolution = new Vector2Int(10, 20);
    public GameObject tileObject;

    TilesStates[,] tiles;

    // Start is called before the first frame update
    void Start()
    {
        tiles = new TilesStates[GridResolution.x, GridResolution.y];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
