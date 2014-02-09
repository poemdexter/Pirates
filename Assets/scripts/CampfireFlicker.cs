using UnityEngine;
using System.Collections;

public class CampfireFlicker : MonoBehaviour
{
    public void BurnOutStart()
    {
        GetComponent<Animator>().SetBool("IsGoingOut", true);
    }
    
    void BurnOutFinish()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().FireIsOut();
    }
}
