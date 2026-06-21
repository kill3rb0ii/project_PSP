using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log(context);
            rb.AddForce(0, 100, 0);
            
        }
        
    }


}
