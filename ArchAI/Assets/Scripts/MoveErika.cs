using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MoveErika : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;
    public static MoveErika Instance;
    public bool hasDied = false;
    public ParticleSystem plasma;
    public bool isRunning = false;
    public VideoPlayer player;
    public GameObject panelintro;
    public Button button;
    public GameObject endScene;
    public VideoPlayer win;
    public bool hasEnd = false;
    public GameObject poisonbut;
    public AudioClip level1;
    public AudioClip level2;
    public AudioClip level3;
    public AudioSource ari;
    public VideoClip l1;
    public VideoClip l2;
    public VideoClip l3;
    public VideoPlayer levelplayer;
    public GameObject lvlpanel;
    public bool LevelIntroDone = false;
    public GameObject info_panel;
    public Text text;
    public bool showInfo11 = false;
    public GameObject info_2;
    public GameObject greyscale;

    // Start is called before the first frame update
    void Start()
    {
        info_2.SetActive(false);
        info_panel.SetActive(true);
        text.text = "Go to the First Level - Refer Minimap";
         
        lvlpanel.SetActive(false);
        //  button.enabled = false;
        poisonbut.SetActive(false);
        hasEnd = false;
        panelintro.SetActive(true);
        PlayerPrefs.SetInt("rewindOver", 0);
    }
    public void hideInfo()
    {
        StartCoroutine(hideInfo1());
        // showInfo11 = false;
    }
    public void showInfo(string text1)
    {
        showInfo11 = true;
        //StopCoroutine(hideInfo1());
        info_panel.SetActive(true);
        text.text = text1;
       //hideInfo();
    }
    IEnumerator hideInfo1()
    {


        yield return new WaitForSeconds(13);
        info_panel.SetActive(false);
    /*    yield return new WaitForSeconds(3);
        info_panel.SetActive(true);*/

    }
    public void hideInstructions()
    {
        info_panel.SetActive(false);
    }
    void Awake()
    {
        if(Instance==null)
        {
            DontDestroyOnLoad(gameObject);
        }
        Instance = this;

    }
    // Update is called once per frame
    void Update()
    {
       
        if (levelplayer.isPaused)
        {
            lvlpanel.SetActive(false);
            
            LevelIntroDone = false;

        }
      /*  if (LevelIntroDone)
        {
            LevelIntroDone = false;
            lvlpanel.SetActive(false);
        }*/
        /*if(player.isPaused)
        {
            hideInfo();
            panelintro.SetActive(false);

        }*/
        /*if(SceneManager.GetActiveScene()==SceneManager.GetSceneAt(1))
        {
            DestroyObject(this.gameObject);
        }*/
        if(PlayerPrefs.GetInt("reverse")==1)
            {
            hasDied = false;
        }
        if (hasDied == true)
        {
            animator.SetBool("IsDie", true);
            animator.SetBool("IsWalking", false);

            animator.SetBool("IsIdle", false);

            animator.SetBool("IsRunning", false);
            StartCoroutine(waitForTime());

        }
        else if  (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetBool("Punch", true);
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsWalking", true);
            }
            else
        {
            if (Input.GetKey(KeyCode.W) && hasDied == false)
            {
                //rb.AddForce(Vector3.right*2);
                //animator.SetBool("IsWalking", true);
                if (Input.GetKeyDown(KeyCode.Space) && hasDied == false)
                {
                    animator.SetBool("IsJumping", true);
                }
                else //if(!isRunning)
                {
                    animator.SetBool("IsJumping", false);
                }

                animator.SetBool("IsWalking", true);

                animator.SetBool("IsIdle", false);
                if (Input.GetKey(KeyCode.LeftShift) && hasDied == false)
                {
                    isRunning = true;
                    animator.SetBool("IsWalking", false);
                    animator.SetBool("IsRunning", true);
                    if (Input.GetKeyDown(KeyCode.Space) && hasDied == false)
                    {
                        animator.SetBool("IsJumping", true);

                    }
                    else
                    {
                        animator.SetBool("IsJumping", false);
                    }

                }
                else
                {
                    isRunning = false;
                    animator.SetBool("IsWalking", true);
                    animator.SetBool("IsRunning", false);
                }




            }
            else
            {
                //animator.SetBool("IsRunning", false);
                animator.SetBool("IsWalking", false);

                animator.SetBool("IsIdle", true);

                animator.SetBool("IsRunning", false);
            }
        }

        if (Input.GetKey(KeyCode.F))
        {
            animator.SetBool("IsSlowTime", true);

        }
        else
        {
            animator.SetBool("IsSlowTime", false);
        }
        

    }
  
    IEnumerator waitForTime()
    {
        yield return new WaitForSeconds(3);

        animator.SetBool("IsDied", true);
        animator.SetBool("IsDie", false);
    }
    public void resetJump()
    {
        animator.SetBool("IsJumping", false);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tree")
        {
            // button.enabled = true;
            poisonbut.SetActive(true);
            showInfo("Press The Poison Button on Left");
          
        }
        if (other.gameObject.tag == "level1")
        {
            hideInstructions();
            // button.enabled = true;
            Debug.Log("triggered");
            other.gameObject.SetActive(false);
            ari.PlayOneShot(level1);
            lvlpanel.SetActive(true);
            levelplayer.clip = l1;
            levelplayer.Play();
            if(levelplayer.isPaused)
            {
                LevelIntroDone = false;
                
            }
            



        }
        if (other.gameObject.tag == "level2")
        {
            showInfo("Pass the Barrels, SPACE to Jump");
            // button.enabled = true;
            other.gameObject.SetActive(false);
            ari.PlayOneShot(level2);
            lvlpanel.SetActive(true);
            levelplayer.clip = l2;
            levelplayer.Play();
            if (levelplayer.isPaused)
            {
                lvlpanel.SetActive(false);
                LevelIntroDone = false;

            }
        }
        if (other.gameObject.tag == "level3")
        {

            // button.enabled = true;
            //showInfo("Hold R to Pull The LumberJack and Destroy Guard");
            info_panel.SetActive(false);
            info_2.SetActive(true);

            other.gameObject.SetActive(false);
           ari.PlayOneShot(level3);
            lvlpanel.SetActive(true);
            levelplayer.clip = l3;
            levelplayer.Play();
            if (levelplayer.isPaused)
            {
                lvlpanel.SetActive(false);
                LevelIntroDone = false;

            }
           

        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="poison")
        {
            other.gameObject.SetActive(false);
            showInfo("Refer Minimap and go till the Gravitree");
            //poisonbut.SetActive(true);
        }
        
        if (other.gameObject.tag == "thorn")
        {
            if(PlayerPrefs.GetInt("rewindOver")==1)
            {
                SceneManager.LoadScene("LoseScreen");
            }
            Debug.Log("THorrrnn");
            hasDied = true;

            /*animator.SetBool("IsDie", true);
            animator.SetBool("IsWalking", false);

            animator.SetBool("IsIdle", false);

            animator.SetBool("IsRunning", false);*/
            showInfo("HOLD E to Reverse Time & REBIRTH");
            animator.SetBool("IsDie", true);
            animator.SetBool("IsWalking", false);

            animator.SetBool("IsIdle", false);

            animator.SetBool("IsRunning", false);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsDied", false);
        }
        else
        {
            animator.SetBool("IsDie", false);
            animator.SetBool("IsWalking", false);

            animator.SetBool("IsIdle", true);

            animator.SetBool("IsRunning", false);
        }
        if (other.gameObject.tag == "barrel")
        {
            showInfo("HOLD E to Reverse Time and Rebirth");
            if (PlayerPrefs.GetInt("rewindOver") == 1)
            {
                SceneManager.LoadScene("LoseScreen");
            }
            Debug.Log("barrel");
            hasDied = true;
            plasma.Play();
           
            /*animator.SetBool("IsDie", true);
            animator.SetBool("IsWalking", false);

            animator.SetBool("IsIdle", false);

            animator.SetBool("IsRunning", false);*/

        }
        else
        {
            animator.SetBool("IsDie", false);
            animator.SetBool("IsWalking", false);

            animator.SetBool("IsIdle", true);

            animator.SetBool("IsRunning", false);
        }
        
        if(win.isPaused&&hasEnd==true)
        {
            SceneManager.LoadScene("Moon");
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            endScener();
        }
    }

    public void endScener()
    {
        Debug.Log("triggered");
        poisonbut.SetActive(false);
        endScene.SetActive(true);
        win.Play();
         hasEnd = true;
    }


}
