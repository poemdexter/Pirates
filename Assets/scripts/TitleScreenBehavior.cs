using UnityEngine;
using System.Collections;

public class TitleScreenBehavior : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Select"))
            Application.LoadLevel("game");
    }
}
