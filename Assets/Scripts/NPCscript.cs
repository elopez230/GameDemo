using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : MonoBehaviour
{

    public static NPCscript instance;


    public Animator animator;

    // At start of game NPC status set to alive
    void Start()
    {
        animator.SetBool("IsAlive", true);
    }

    // Method to use NPC death animation
    public void NpcDead()
    {
        animator.SetBool("IsAlive", false);
    }

    void Update()
    {
        
    }
}
