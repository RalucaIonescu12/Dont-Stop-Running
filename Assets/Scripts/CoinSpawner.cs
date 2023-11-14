using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    [SerializeField] private GameObject Plane_Coin;

    public Transform StartPos;
    public Transform EndPos;
    
    private float Current_Coin_Position;
    // Start is called before the first frame update
    void Start()
    {

        Plane_Coin.SetActive(false);
       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Current_Coin_Position = StartPos.position.z;

        while (Current_Coin_Position < EndPos.position.z)
        {
            GameObject Coin = ObjectPool.SharedInstance.GetPooledObject();
            if (Coin != null)
            {
                Coin.transform.position = new Vector3(StartPos.position.x, StartPos.position.y + 1, Current_Coin_Position);
                Coin.SetActive(true);
            }

            Current_Coin_Position += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
