using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlowTime : MonoBehaviour
{
    [SerializeField] Animator animator;
    public static SlowTime instance;
    private float fixedDeltaTime;
    public int slowUsedTime;
    public Image image;
    public Text slow;
    public GameObject grey;
    private void Awake()
    {// Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
        slow.text = "3";
        if (instance==null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F)&&slowUsedTime<4)
        {
            ++slowUsedTime;
            slow.text = (3 - slowUsedTime).ToString();
            Debug.Log("slow used" + slowUsedTime);
            Time.timeScale = 0.33F;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            LookAtCamera.Instance.IncreaseFreeSpeed();
            animator.SetFloat("IdleSpeed", 3.5f);
            animator.SetFloat("WalkSpeed", 3.5f);
            animator.SetFloat("RunSpeed", 3.5f);
            animator.SetFloat("JumpingSpeed", 3.5f);
           // grey.SetActive(true);
            WaitForTime.Instance.waitTime(3);

        }
        if(slowUsedTime>=3)
        {
            
                var tempColor = image.color;
                tempColor.a = 0.3f;
                image.color = tempColor;
           
        }
       
    }
    public void ResetValues()
    {
        animator.SetFloat("IdleSpeed", 1);
        animator.SetFloat("WalkSpeed", 1);
        animator.SetFloat("RunSpeed", 1);
        animator.SetFloat("JumpingSpeed", 1);
    }
    public void SlowTimer()
    {
       
    }
}
