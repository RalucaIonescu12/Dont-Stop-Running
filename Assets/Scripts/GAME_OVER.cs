using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinsCollected;
    void Start()
    {
        CoinsCollected.text = PlayerPrefs.GetInt("CoinsCollected").ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
}
 