using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior1 : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float catchDistance = 1.5f;
    [SerializeField] private float rotationSpeed = 5f;

    private bool hasCaughtPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
       if (animator = null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(player == null)
        {
            Debug.Log("Player not assigned");
            return;
        }

        if (hasCaughtPlayer)
        {
            return;
        }


        //direction from zombie to player
        Vector3 direction = player.position - transform.position;

        //keep zombie on the ground
        direction.y = 0f;

        float distance = direction.magnitude;

        //check if caught player
        if(distance <= catchDistance)
        {
            hasCaughtPlayer = true;
            Debug.Log("Zombie has caught the player");
            return;
        }

        //move toward player
        Vector3 moveDirection = direction.normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //zombie rotation
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void SetMoving(bool moving)
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", moving ? 1f : 0f);
        }
    }
}
