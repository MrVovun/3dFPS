using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _gravity = 9.81f;

    // Start is called before the first frame update
    void Start () {
        _controller = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update () {
        CalculateMovement ();
    }

    void CalculateMovement () {
        float horizontalInput = Input.GetAxis ("Horizontal");
        float verticalInput = Input.GetAxis ("Vertical");
        Vector3 _direction = new Vector3 (horizontalInput, 0, verticalInput);
        Vector3 _velocity = _direction * _speed;
        _velocity.y -= _gravity;
        _velocity = transform.TransformDirection (_velocity);
        _controller.Move (_velocity * Time.deltaTime);
    }
}
