using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
