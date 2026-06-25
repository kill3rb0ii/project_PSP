using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;
    //[SerializeField] private int moveSpeed = 100;
    private bool engineIgn = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //rb.AddForce(0, 100, 0);
            engineIgn = true;
        }

        else if (context.canceled)
        {
            engineIgn = false;
        }
        
    }

    public void Controls(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
            
            //Debug.Log(moveInput);
        }
        else if (context.canceled)
        {
            moveInput = Vector2.zero;
        }
    }


    private void Update()
    {
        //converting from vector2 to quaternion (WILL ADD MORE DIRECTIONS HERE!!!)
        //transform.rotation = transform.rotation*Quaternion.Euler(0, 0, -moveInput.x*Time.deltaTime*100);

        rb.AddRelativeTorque(0, 0, -moveInput.x * Time.deltaTime * 100);

        //temporary thrust value
        if(engineIgn == true)
        {
            rb.AddRelativeForce(0,1000*Time.deltaTime,0);
        }
    }

}
