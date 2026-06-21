using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;
    [SerializeField] private int moveSpeed = 100;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            rb.AddForce(0, 100, 0);
        }
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveInput = Vector2.zero;
        }
    }


    private void Update()
    {
        rb.linearVelocity = new Vector3(moveInput.x*moveSpeed*Time.deltaTime, rb.linearVelocity.y, moveInput.y*moveSpeed*Time.deltaTime);
    }

}
