using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent OnHitSomething;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Retreive the player's regid body
        Rigidbody rb = GetComponent<Rigidbody>();

        // check if the space bar was presssed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // if it was shove the player up
            rb.AddForce(Vector3.up * 200);
        }
    }

    private void OnCollisionEnter(Collision collison)
    {
        Debug.Log("We hit " + collison.gameObject.name);

        OnHitSomething?.Invoke();
    }
}
