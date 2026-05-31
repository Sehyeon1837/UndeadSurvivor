using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public Rigidbody2D rigid;
    public float speed;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate() 
    {
        // 입력받은 이동 값 적용
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
