using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void Start()
    {
        GameObject van = GameObject.FindGameObjectWithTag("Player");
        GameObject ava = GameObject.FindGameObjectWithTag("Fairy");

        if (van)
            Physics2D.IgnoreCollision(van.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        if (ava)
            Physics2D.IgnoreCollision(ava.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
