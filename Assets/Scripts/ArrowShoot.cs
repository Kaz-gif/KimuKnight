using UnityEngine;

public partial class ArrowProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f; // Seconds before the arrow is destroyed

    void Start()
    {
        // Destroy the arrow after a few seconds so they don't fly forever
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the arrow forward (Right in its local space)
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
