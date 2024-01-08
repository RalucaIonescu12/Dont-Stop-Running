using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using static Score;
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinsCollected;
    [SerializeField] private TextMeshProUGUI FinalScore;
    void Start()
    {
        CoinsCollected.text = PlayerPrefs.GetInt("CoinsCollected").ToString();
        FinalScore.text = ((int)Score.GetCurrentScore()).ToString();

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
 