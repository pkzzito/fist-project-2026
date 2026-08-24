using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float speedIncrease = 0.5f;

    private Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        Vector3 movement = new Vector3(
            moveInput.x,
            0,
            moveInput.y
        );

        transform.Translate(
            movement * speed * Time.deltaTime,
            Space.World
        );
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