using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("walk", true);
            animator.SetBool("idle", false);
        }
        else
        {
            animator.SetBool("idle", true);
            animator.SetBool("walk", false);
        }
    }
}
