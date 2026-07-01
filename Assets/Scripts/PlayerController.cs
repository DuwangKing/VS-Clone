using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 playerMovement = new Vector2(x, y).normalized * playerSpeed * Time.deltaTime;

        transform.Translate(playerMovement);
    }
}