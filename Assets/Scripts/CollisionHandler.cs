using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private CogCounter counterRef;
    private bool hasCollided = false;

    void Start()
    {
        counterRef = GameObject.Find("GameManager").GetComponent<CogCounter>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (this.hasCollided)
            return;

        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Fairy")
        {
            counterRef.Increment();
            Destroy(this.gameObject);
        }
    }
}
