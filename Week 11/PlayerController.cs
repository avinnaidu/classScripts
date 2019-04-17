using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent OnHitSomething;

    public float HorizontalSpeed = 1f;

    private GameManger m_CurrentGameManger;

    // The particle effect used when my flappy bird hits something
    public GameObject myExplosion;

    public List<GameObject> myExplosionCount = new List<GameObject>();

    private void OnEnable()
    {
        OnHitSomething.AddListener(Explosion);
    }

    private void OnDisable()
    {
        OnHitSomething.RemoveListener(Explosion);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Finds the current gamemanger in the scene
        m_CurrentGameManger = FindObjectOfType<GameManger>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);

        // calculate the new position using horiz speed
        Vector3 amountToMove = Vector3.right * HorizontalSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + amountToMove;

        // update the position
        transform.position = newPosition;

        // check if the space bar was pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // retrieve the player's rigid body
            Rigidbody rb = GetComponent<Rigidbody>();

            // if it was shove the player up
            rb.AddForce(Vector3.up * 200);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Passed through " + other.gameObject.name);

        m_CurrentGameManger.onPickUp?.Invoke();

        // destroy the thing we passed through
        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We hit " + collision.gameObject.name);

        Instantiate(myExplosion, transform.position, Quaternion.identity);

        OnHitSomething?.Invoke();
    }

    private void Explosion()
    {
        GameObject clone = Instantiate(myExplosion, transform.position, Quaternion.identity);
        myExplosionCount.Add(clone);
        Invoke("CleanUpExplosions", 2);
    }

    private void CleanUpExplosions()
    {
        if(myExplosionCount.Count > 0)
        {
            Destroy(myExplosionCount[0]);
            myExplosionCount.RemoveAt(0);
        }
    }
}
