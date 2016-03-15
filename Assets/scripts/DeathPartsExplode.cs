using UnityEngine;
using System.Collections;

public class DeathPartsExplode : MonoBehaviour
{
    public float pushForce;
    public float rotationForce;
    bool isExploded = false;
    
    void Update()
    {
        if (!isExploded) {
            isExploded = true;
            GetComponent<AudioSource>().Play();
            foreach (Transform child in transform) {
                child.GetComponent<Rigidbody2D>().AddForce(GetRandomKnockbackForce());
                child.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-rotationForce, rotationForce));
            }
        }
    }
    
    Vector2 GetRandomKnockbackForce()
    {
        Vector3 forward = transform.right;
        return (new Vector2(Random.Range(forward.x - 1.0f, forward.x + 1.0f) * transform.localScale.x, Random.Range(forward.y - 1.0f, forward.y + 1.0f)) * pushForce);
    }
}
