using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Transform centralObject;  
    public float orbitSpeed = 10f;   
    private bool isClockwise = true; 
    private int score = 0;           

    void Update()
    {
        float direction = isClockwise ? 1f : -1f;
        transform.RotateAround(centralObject.position, Vector3.up, direction * orbitSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            isClockwise = !isClockwise;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (other.CompareTag("Collectible"))
        {
            score++;
            GameManager.Instance.UpdateScore(score);
            Destroy(other.gameObject);
        }
    }
}
