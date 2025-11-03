using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CannonballController : MonoBehaviour
{
    public Rigidbody2D cannon;
    // Start is called before the first frame update
    void Start()
    {
       
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
            ScoreboardController.Instance.Score += 1;
        Destroy(gameObject);
    }
}
