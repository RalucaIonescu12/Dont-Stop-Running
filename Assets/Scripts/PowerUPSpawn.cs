using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Magnet;
    [SerializeField] private GameObject Wings;

    private void OnTriggerEnter(Collider other)
    {
        GameObject Power = Wings;
        if(Random.value > 0.5)
        {
            Power = Wings;
        }
        Power.SetActive(true);
        Power.transform.position = this.transform.position;
    }
 }
