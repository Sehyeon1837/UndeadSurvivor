using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position; // 위치 판단
        Vector3 myPos = transform.position;
        
        // 이전 이동과 방향 판단
        // float diffX = Mathf.Abs(playerPos.x - myPos.x);
        // float diffY = Mathf.Abs(playerPos.y - myPos.y);
        
        // Vector3 playerDir = GameManager.instance.player.inputVec; // 방향 판단 
        // float dirX = playerDir.x < 0 ? -1 : 1;
        // float dirY = playerDir.y < 0 ? -1 : 1;
        
        // 변경된 이동과 방향 판단
        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;
        
        float diffX = Mathf.Abs(dirX);
        float diffY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        switch (transform.tag)
        {
            case "Ground":
                // 어느 방향으로 이동할 것인가?
                if (diffX > diffY) // diffX가 더 크면 X축으로 멀어졌으니, 수평 이동
                {
                    transform.Translate(Vector3.right * dirX * 40); // 이동 시키고 방향 곱하기
                }
                else if (diffX < diffY) // diffY가 더 크면 Y축으로 이동, 수직 이동
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":
                break;
        }
    }
}
