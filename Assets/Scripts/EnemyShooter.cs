using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 簡単な飛び道具発射クラス(敵)
/// </summary>
public class EnemyShooter : Shooter
{
    [SerializeField] float _interval = 2.0f;

    Character _character;
    Vector3 _dir = Vector3.zero;
    float _timer = 0.0f;

    public bool Valid;

    void Start()
    {
        _character = GetComponent<Character>();
    }

    void Update()
    {
        if (_character.CharId == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) _dir = new Vector3(0, 0, 0);
            if (Input.GetKeyDown(KeyCode.DownArrow)) _dir = new Vector3(0, 180, 0);
            if (Input.GetKeyDown(KeyCode.LeftArrow)) _dir = new Vector3(0, -90, 0);
            if (Input.GetKeyDown(KeyCode.RightArrow)) _dir = new Vector3(0, 90, 0);
        }
        if (_character.CharId == 2)
        {
            if (Input.GetKeyDown(KeyCode.W)) _dir = new Vector3(0, 0, 0);
            if (Input.GetKeyDown(KeyCode.S)) _dir = new Vector3(0, 180, 0);
            if (Input.GetKeyDown(KeyCode.A)) _dir = new Vector3(0, -90, 0);
            if (Input.GetKeyDown(KeyCode.D)) _dir = new Vector3(0, 90, 0);
        }

        if (_interval <= 0.0f) return;
        if (!Valid) return;

        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            _timer -= _interval;
            Shot(_dir);
        }
    }
}
