using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : MonoBehaviour
{

    public static NPCscript instance;


    public Animator animator;

    void Start()
    {
        animator.SetBool("IsAlive", true);
        //animator.SetBool("IsAlive2", true);
    }

    public void NpcDead()
    {
        animator.SetBool("IsAlive", false);
        //animator.SetBool("IsAlive2", false);
    }

    void Update()
    {
        
    }
}
