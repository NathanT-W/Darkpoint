using UnityEngine;

public class BirdAI : MonoBehaviour
{
    public GameObject cogwheel;

    public int speed = 8;

    bool moveTowardsRight = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "TurningPoint")
            moveTowardsRight = !moveTowardsRight;

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Fairy")) // should be only Fairy?
        {
            GameObject cogwheelInstance = Instantiate(cogwheel, transform.position, transform.rotation);
            cogwheelInstance.GetComponent<Rigidbody2D>().gravityScale = 0.8f;
            cogwheelInstance.GetComponent<CollisionHandler>().canInteract = false;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate((moveTowardsRight ? 2 : -2) * Time.deltaTime * speed, 0, 0);
        transform.localScale = new Vector2(moveTowardsRight ? -1 : 1, 1);
    }
}
