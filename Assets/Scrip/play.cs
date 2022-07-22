using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;


public class play : MonoBehaviour
{

    public GameObject Animation;
    public Rigidbody hips;
    AudioSource audioData;
    camera cam;
    public float speed = 5.0f;
    public float strafespeed;
    public float jumpForce;

    public bool move;
    public bool isGrounded = false;
    private int count;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI countLife;
    public GameObject Key1;
    public GameObject gameover;
    public GameObject winTextObject;
    public GameObject Eye;
    public GameObject Key;
    public GameObject Door;
    public GameObject Point;
    public GameObject Boss;
    public GameObject Direction;
    private bool keyE;
    public bool key;
    public bool sword;
    private int life ;

    void Start()
    {
        hips = GetComponent<Rigidbody>();
        count = 0;
        life = 3 ;
        SetCountLife();
        key = false;
        sword = false;
        SetCountText();
        keyE = false;
    }

   

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {

            Animation.GetComponent<Animator>().SetBool("isWalk", true);
            move = true;
        }
        else
        {
            Animation.GetComponent<Animator>().SetBool("isWalk", false);
            move = false;
        }
        PlayerMoverment();
        if (keyE==true)
        {
            if (Input.GetKey(KeyCode.E))
                Boss.gameObject.SetActive(false);
        }    

    }
    private void PlayerMoverment()
    {

        if (Input.GetKey(KeyCode.W))
        {

            hips.AddForce(hips.transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {

            hips.AddForce(-hips.transform.right * strafespeed);
        }
        if (Input.GetKey(KeyCode.S))
        {

            hips.AddForce(-hips.transform.forward * speed * 1.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {

            hips.AddForce(hips.transform.right * strafespeed);
        }
        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded != true)
            {
                return;
            }
            hips.AddForce(new Vector3(0, jumpForce, 0));
            isGrounded = false;
            Animation.GetComponent<Animator>().SetBool("Jump", true);
        }
        else
        {
            Animation.GetComponent<Animator>().SetBool("Jump", false);
        }


    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Coin"))
        {

            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.CompareTag("Door") && key==true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.CompareTag("Die"))
        {
            transform.position = Point.transform.position;
            life = life - 1;
            SetCountLife();
         
        }
        if (other.CompareTag("Win"))
        {
            StartCoroutine(Win());
        }
        if (other.CompareTag("Kiem"))
        {
            other.gameObject.SetActive(false);
            sword = true;
            Debug.Log("dã lấy kiếm");
        }
        if (other.CompareTag("Heart"))
        {
     
            life = life + 1;
            SetCountLife();
        }
        if (other.CompareTag("Mat") && sword==true)
        {
            StartCoroutine(Eyes());
            keyE = true;
        }



    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            isGrounded = true;
        }

    }
    void SetCountText()
    {
        
        countText.text = "a      " + count.ToString();
        if(count == 1)
        {  
            StartCoroutine(Direc());
            Debug.Log("2222");
        }    
        if (count == 4)
        {
            Key.SetActive(true);
            key = true;
            StartCoroutine(Run());

        }
    }
    void SetCountLife()
    {
        countLife.text = "Life : " + life.ToString();
        if (life == 0)
        {
            StartCoroutine(Run2());
        }
    }
    private IEnumerator Run()
    {
        {
            Key1.SetActive(true);
            yield return new WaitForSeconds(3);
            Key1.SetActive(false);
        }
    }
    private IEnumerator Eyes()
    {
        {
            Eye.SetActive(true);
            yield return new WaitForSeconds(3);
            Eye.SetActive(false);

        }
    }
    private IEnumerator Run2()
    {
        {

            gameover.SetActive(true);
            yield return new WaitForSeconds(3);
            gameover.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

        }
    }
    private IEnumerator Win()
    {
        {

            winTextObject.SetActive(true);
            yield return new WaitForSeconds(10);
            winTextObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }
    private IEnumerator Direc()
    {
        {

            Direction.SetActive(true);
            yield return new WaitForSeconds(3);
            Direction.SetActive(false);
            
        }
    }
}