using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float speed = 2f;
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }
}
