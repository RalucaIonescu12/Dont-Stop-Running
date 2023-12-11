using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTIVATE_FLY_POWER : MonoBehaviour
{
    [SerializeField] private GameObject PlayerWings;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement.IsFlying = true;
        PlayerWings.SetActive(true);
        gameObject.SetActive(false);
    }
}
