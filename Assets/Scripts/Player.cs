using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public Rigidbody2D rigid;
    public SpriteRenderer spriter;
    public float speed;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
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

    private void LateUpdate()
    {
        if (inputVec.x != 0)
        {
            // 0 이면 고정. -1 좌측이라 flip true, 1 우측은 flip false
            spriter.flipX = inputVec.x < 0;
        }
    }
}
