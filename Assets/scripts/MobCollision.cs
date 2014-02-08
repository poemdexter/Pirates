using UnityEngine;
using System.Collections;

public class MobCollision : MonoBehaviour
{
    public GameObject deathParts;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerWeapon")) {
            // get player's arm rotation and player's scale (facing direction)
            Explode(col.transform.parent.rotation, col.transform.parent.parent.localScale);
        }
        
        if (col.CompareTag("Chest")) {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GameOver();
        }
    }
    
    void Explode(Quaternion rotation, Vector3 scale)
    {
        // shake screen
        Camera.main.GetComponent<ScreenShake>().Shake();
        // create parts
        rigidbody2D.isKinematic = true;
        GameObject obj = (GameObject)Instantiate(deathParts, transform.position, rotation);
        obj.transform.localScale = scale;
        obj.transform.parent = transform.parent;
        Destroy(gameObject);
    }
}
