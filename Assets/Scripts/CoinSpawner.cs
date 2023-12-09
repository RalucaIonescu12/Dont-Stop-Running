using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Plane_Coin;
    public Transform StartPos;
    public Transform EndPos;

    private float Current_Coin_Position;
    [SerializeField] private BoxCollider m_collider;
    // Start is called before the first frame update
    void Start()
    {
        Plane_Coin.SetActive(false);
        m_collider.center = new Vector3(m_collider.center.x, m_collider.center.y, m_collider.center.z / transform.localScale.z);
        m_collider.size = new Vector3(m_collider.size.x, m_collider.size.y, m_collider.size.z / transform.localScale.z);
        //Current_Coin_Position = StartPos.position.z;
        //while (Current_Coin_Position < EndPos.position.z)
        //{
        //    GameObject Coin = ObjectPool.SharedInstance.GetPooledObject();
        //    if (Coin != null)
        //    {
        //        Coin.transform.position = new Vector3(StartPos.position.x, StartPos.position.y + 0.5f, Current_Coin_Position);
        //        Coin.SetActive(true);
        //    }
        //    Current_Coin_Position++;
        //}
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Current_Coin_Position = StartPos.position.z;
        while (Current_Coin_Position < EndPos.position.z)
        {
            GameObject Coin = ObjectPool.SharedInstance.GetPooledObject();
            if (Coin != null)
            {
                Coin.transform.position = new Vector3(StartPos.position.x, StartPos.position.y + 0.5f, Current_Coin_Position);
                Coin.SetActive(true);
            }
            Current_Coin_Position++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}