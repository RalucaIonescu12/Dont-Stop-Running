using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_TRIGGER_FALSE : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}
