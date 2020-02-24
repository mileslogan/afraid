﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    
    public float forwardBackward;
    public float rightLeft;

    public float mouseX;
    public float mouseY;

    public float moveSpeed;

    public Vector3 inputVector;

    public CharacterController thisCharacterController;

    public bool isTalking;

    // Start is called before the first frame update
    void Start()
    {
        thisCharacterController = GetComponent<CharacterController>();
        isTalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTalking)
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

            transform.Rotate(0, mouseX, 0);

            Camera.main.transform.Rotate(-mouseY, 0, 0);

            forwardBackward = Input.GetAxis("Vertical");
            rightLeft = Input.GetAxis("Horizontal");

            inputVector = transform.forward * forwardBackward;
            inputVector += transform.right * rightLeft;

            thisCharacterController.Move(inputVector * moveSpeed + (Physics.gravity * .69f) * Time.deltaTime);
        }
        
    }
}