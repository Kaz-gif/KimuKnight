using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Controls
    public InputAction MoveAction;
    public InputAction shootAction;
    public Transform launchPoint; // Where the arrow starts (e.g., the bow)
    public GameObject arrowPrefab;

    void OnEnable() => shootAction.Enable();
    void OnDisable() => shootAction.Disable();
    
    public float speed = 0.1f;
    Animator animator;
    void Start()
    {
        MoveAction.Enable();
        animator = GetComponent<Animator>();
    }

    void Update()
    {  
        Vector2 move = MoveAction.ReadValue<Vector2>();
        //Feedback for unity console
        Debug.Log(move);
        Vector2 position = (Vector2)transform.position + move * speed;
        transform.position = position;


        // Running animation
        
        if (move.x != 0)
        {
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }

        // Rotate Character when going backwards

        if (move.x < 0)
        {
            transform.localScale = new Vector2(-5, 5);
        }
        else if (move.x > 0)
        {
            transform.localScale = new Vector2(5, 5);
        }

        // WasPressedThisFrame(); prevents the player from "machine-gunning" arrows just by holding the button down.

        if (shootAction.WasPressedThisFrame())
        {
            Shoot();
        }

    }

    void Shoot()
    {
        // Create the arrow at the launch point
        GameObject arrow = Instantiate(arrowPrefab, launchPoint.position, transform.rotation);

        // Adjust arrow direction based on player scale (flipping)
        // If your player is flipped (localScale.x is negative), flip the arrow
        if (transform.localScale.x < 0)
        {
            arrow.transform.rotation = Quaternion.Euler(0, 0, 180f);
        }
    }
}
