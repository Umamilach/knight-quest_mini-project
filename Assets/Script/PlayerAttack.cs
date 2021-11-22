using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("attacking");
        }
    }
}
