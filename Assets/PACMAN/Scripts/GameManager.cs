using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static public PacmanGrid pacmanGrid { get; private set; }
    static public Camera cam { get; private set; }
    static GameManager _instance;

    static public GameManager Instance()
    {
        if (_instance == null) {
            _instance = FindObjectOfType<GameManager>().GetComponent<GameManager>();
            _instance.Intitialize();
        }
        return _instance;
    }

    private void Intitialize()
    {
        pacmanGrid = FindObjectOfType<PacmanGrid>().GetComponent<PacmanGrid>();
        cam = FindObjectOfType<Camera>().GetComponent<Camera>();
    }
}
