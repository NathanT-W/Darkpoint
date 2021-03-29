using UnityEngine;

public class BirdAI : MonoBehaviour
{
    public int speed = 8;

    bool moveTowardsRight = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "TurningPoint")
            moveTowardsRight = !moveTowardsRight;
    }

    void Update()
    {
        transform.Translate((moveTowardsRight ? 2 : -2) * Time.deltaTime * speed, 0, 0);
    }
}
