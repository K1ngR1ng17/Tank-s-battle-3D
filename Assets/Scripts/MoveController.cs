using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float _move, _rotate;
    private float _rotateTower;
    private Rigidbody rigidbody;

    public int _force;
    public float _moveSpeed, _rotateSpeed, _rotateSpeedTower;
    public GameObject tower;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        Turn();
        TurnTower();
    }

    void Update()
    {
        _move = Input.GetAxis("Vertical");
        _rotate = Input.GetAxis("Horizontal");
        _rotateTower = Input.GetAxis("HorizontalTower");
    }

    private void Move()
    {
        Vector3 _movement = transform.forward * _moveSpeed * _move * Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position + _movement);
    }
    private void Turn()
    {
        float turn = _rotate * _rotateSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigidbody.MoveRotation(turnRotation * rigidbody.rotation);
    }
    private void TurnTower()
    {
        tower.transform.Rotate(Vector3.up, _rotateTower * _rotateSpeedTower * Time.deltaTime, Space.World);
    }
}
