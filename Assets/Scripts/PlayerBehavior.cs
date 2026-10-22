using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        //wasd input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //calculate direction
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //move
        controller.Move(direction * moveSpeed * Time.deltaTime);

        //rotate player towards direction
        if(direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed*Time.deltaTime);
        }
        
    }
}
