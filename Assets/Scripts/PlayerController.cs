using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool toLook = false;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject camPivot;
    private Vector3 camPlayerDist;
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

    public void Look(InputAction.CallbackContext context)
    {
        if (context.started && toLook == true)
        {
            lookInput = context.ReadValue<Vector2>();
            //camPlayerDist = (gameObject.transform.position - cam.transform.position);
            //cam.transform.position -= new Vector3 (lookInput.x/10, lookInput.y/10, 0);
            camPivot.transform.eulerAngles += new Vector3(-lookInput.y, lookInput.x, 0); 

            if((gameObject.transform.position - cam.transform.position).magnitude > camPlayerDist.magnitude)
            {
                cam.transform.position = gameObject.transform.position - ((gameObject.transform.position - cam.transform.position).normalized * 10); //10 is distance between cam and player
            }

            Debug.Log(cam.transform.position);
        }
    }
    
    public void ToLook(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            toLook = true;
        }
        else if (context.canceled)
        {
            toLook = false;
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
