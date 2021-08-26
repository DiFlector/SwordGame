using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1f, rotationSpeed = 2f;
    private int moveDir = 0;
    [Range(0, 100)]
    public float hp = 100f, exp = 0f;
    private bool isMoving = false;
    private GameObject sword;
    private Animator swordAnim;
    private Rigidbody rb;
    private MobileController mc;
    private Animator rightLeg;
    private Animator leftLeg;
    public int level = 1;
    private float getExp = 5f;

    [SerializeField, Space]
    private GameObject DiedMenu;
    [SerializeField]
    private GameObject UpgradeMenu, Controller;

    private bool isActive = true;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        sword = GameObject.FindGameObjectWithTag("Sword");
        swordAnim = sword.GetComponent<Animator>();
        mc = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
        rightLeg = GameObject.FindGameObjectWithTag("RightLeg").GetComponent<Animator>();
        leftLeg = GameObject.FindGameObjectWithTag("LeftLeg").GetComponent<Animator>();
    }

    void Update()
    {
        if (mc.Vertical() > 0) moveDir = 1;
        else if (mc.Vertical() < 0) moveDir = -1;
        else moveDir = 0;

        if (mc.Vertical() != 0 || mc.Horizontal() != 0) isMoving = true;
        else isMoving = false;

        if (isMoving)
        {
            swordAnim.SetBool("isMoving", true);
            rightLeg.SetBool("isMoving", true);
            leftLeg.SetBool("isMoving", true);
        }
        else
        {
            swordAnim.SetBool("isMoving", false);
            rightLeg.SetBool("isMoving", false);
            leftLeg.SetBool("isMoving", false);
        }

        if (hp <= 0 && isActive == true)
        {
            DiedMenu.SetActive(true);
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("UIBars"))
            {
                obj.SetActive(false);
            }
            GameObject.FindGameObjectWithTag("RightLeg").GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("LeftLeg").GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Sword").GetComponentInChildren<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<Animator>().SetBool("die", true);
            GetComponentInChildren<ParticleSystem>().Play();
            Invoke("Pause", 0.7f);
            isActive = false;
        }

        if (exp >= 100)
        {
            exp = 0;
            getExp -= 0.1f;
            Controller.SetActive(false);
            UpgradeMenu.SetActive(true);
        }

        if (getExp <= 0f) getExp = 1f;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * speed * Time.fixedDeltaTime * moveDir);
        transform.rotation *= Quaternion.Euler(0, mc.Horizontal() * rotationSpeed, 0);
    }
    public void damageTake(int dmg)
    {
        hp -= dmg;
    }

    public void pointTake()
    {
        exp += getExp;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
}

