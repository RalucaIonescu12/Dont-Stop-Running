using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Magnet;

    private void OnTriggerEnter(Collider other)
    {
        Magnet.SetActive(true);
        Magnet.transform.position = this.transform.position;
    }
 }
