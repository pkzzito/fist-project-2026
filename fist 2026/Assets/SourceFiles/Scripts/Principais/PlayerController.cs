using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float speedIncrease = 0.5f;

    private Vector2 moveInput;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(
            moveInput.x,
            0f,
            moveInput.y
        );

        Vector3 newPosition =
            rb.position +
            movement * speed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }

    public void IncreaseSpeed()
    {
        speed += speedIncrease;

        Debug.Log(
            gameObject.name +
            " ficou mais rápido! Velocidade: " +
            speed
        );
    }
}