using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Range(.1f, 1.5f)]
    public float cooldown = .5f;
    private float cooldownTimer;
    GameObject simpleBullet;

    void Start()
    {

    }

    void Update()
    {
        if (cooldownTimer < 0)
        {
            cooldownTimer = 0;
        }
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        Instantiate(Resources.Load("simpleBullet"),this.transform);

    }
}
