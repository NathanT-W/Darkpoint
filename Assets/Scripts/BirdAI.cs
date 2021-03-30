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

        if (other.gameObject.CompareTag("Player")) // should be Fairy, but for testing it is Player
        {
            Instantiate(cogwheel, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate((moveTowardsRight ? 2 : -2) * Time.deltaTime * speed, 0, 0);
    }
}
