using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> Tiles;
    int RandomTile;
    int CurrentTile = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        RandomTile = Random.Range(CurrentTile + 1, Tiles.Capacity);
        Tiles[RandomTile].transform.position = new Vector3(0, 0, Tiles[CurrentTile].transform.position.z+100);
    }
}
