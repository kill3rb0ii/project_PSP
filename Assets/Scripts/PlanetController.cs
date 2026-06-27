using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] private float gravityForce = 1000f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log(gravityForce);
            Debug.Log("found player");
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.planetOrigin = gameObject.transform.position;
            //playerController.planetMass = rb.mass;
            playerController.gravityForce = gravityForce;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        Debug.Log("out");
    }


}
