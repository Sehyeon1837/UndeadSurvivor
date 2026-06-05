using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 장면이 하나라 싱글톤은 쓰지 않음
    public static GameManager instance;
    public Player player;

    private void Awake()
    {
        instance = this; // 초기화
    }
}
