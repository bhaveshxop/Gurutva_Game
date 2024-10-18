using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class moveMe : MonoBehaviour
{
    [SerializeField] GameObject sam;
    Vector3 pos;
    [SerializeField] Animator animator;
    [SerializeField] Text text;
    [SerializeField] ParticleSystem particle;
    public bool goTo = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("close", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(goTo)
        {
            pos = sam.transform.position;
            pos.y = pos.y;
            pos.x = pos.x;
            transform.localPosition = pos;
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
           pos=sam.transform.position;
            pos.y = pos.y;
            pos.x = pos.x;
            goTo = true;
            transform.localPosition = pos;
            animator.enabled = false;
            text.text="Press E for time travel";
            particle.Play();
        }
        if(Input.GetKeyDown(KeyCode.E))
            {
            SceneManager.LoadScene("Main Scene");
        }
    }
}
