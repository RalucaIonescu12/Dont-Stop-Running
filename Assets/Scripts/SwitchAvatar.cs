using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SwitchAvatar : MonoBehaviour
{
    public GameObject avatar1, avatar2, avatar3, avatar4;
    int whichAvatarIsOn = 1;

    // Start is called before the first frame update
    void Start()
    {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
        avatar4.gameObject.SetActive(false);
    }

    public void AvatarSwitch()
    {
        switch (whichAvatarIsOn)
        {
            //case 1:
            //    whichAvatarIsOn = 2;

            //    avatar1.gameObject.SetActive(false);
            //    avatar2.gameObject.SetActive(true);

            //    break;

            //case 2:
            //    whichAvatarIsOn = 1;

            //    avatar1.gameObject.SetActive(true);
            //    avatar2.gameObject.SetActive(false);

            //    break;




            case 1:
                whichAvatarIsOn = 2;

                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(true);
                avatar3.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(false);

                break;

            case 2:
                whichAvatarIsOn = 3;

                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(true);
                avatar4.gameObject.SetActive(false);

                break;

            case 3:
                whichAvatarIsOn = 4;

                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(true);

                break;

            case 4:
                whichAvatarIsOn = 1;

                avatar1.gameObject.SetActive(true);
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(false);

                break;
        }
    }

    public void PlayGame()
    {
        if(whichAvatarIsOn == 1)
        {
            PrefabUtility.SaveAsPrefabAsset(avatar1, "Assets/Prefab/AvatarPrefab.prefab");
            SceneManager.LoadScene("Game");
        }
        else if(whichAvatarIsOn == 2)
        {
            PrefabUtility.SaveAsPrefabAsset(avatar2, "Assets/Prefab/AvatarPrefab.prefab");
            SceneManager.LoadScene("Game");
        }
        else if (whichAvatarIsOn == 3)
        {
            PrefabUtility.SaveAsPrefabAsset(avatar3, "Assets/Prefab/AvatarPrefab.prefab");
            SceneManager.LoadScene("Game");
        }
        else if (whichAvatarIsOn == 4)
        {
            PrefabUtility.SaveAsPrefabAsset(avatar4, "Assets/Prefab/AvatarPrefab.prefab");
            SceneManager.LoadScene("Game");
        }

    }
}
