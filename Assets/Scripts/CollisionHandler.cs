using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private CogCounter counterRef;
    private bool hasCollided = false;
    public bool canInteract = true;

    void Start()
    {
        counterRef = GameObject.Find("GameManager").GetComponent<CogCounter>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && !canInteract)
            canInteract = true;

        if (this.hasCollided || !canInteract)
            return;

        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Fairy")
        {
            Destroy(this.gameObject);
            counterRef.Increment();
        }
    }
}
