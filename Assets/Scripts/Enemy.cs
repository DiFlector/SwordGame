using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.001f;
    public float hp = 3f;
    public int damage = 1;
    public bool isDamaget = false, attack = false;
    private Sword sword;
    private GameObject player;
    private Rigidbody rb;
    private Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger")) attack = true;
        else if (other.CompareTag("Sword") && isDamaget == false)
        {
            hp -= sword.damage;
            isDamaget = true;
        }
        Check();
    }

    private void OnTriggerExit(Collider other)
    {
        isDamaget = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        sword = GameObject.FindGameObjectWithTag("Sword").GetComponent<Sword>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void FixedUpdate()
    {
        var target = new Vector3(player.transform.position.x, 0.7f, player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
    }

    void Check()
    {
        if (hp <= 0)
        {
            anim.SetBool("isDied", true);
            Destroy(gameObject.GetComponent<CapsuleCollider>());
            Destroy(gameObject.GetComponent<CapsuleCollider>());
            Destroy(gameObject, 1f);
        }

        if (attack == true)
        {
            anim.SetBool("attack", true);
            GetComponentInChildren<ParticleSystem>().Play();
            Destroy(gameObject.GetComponent<CapsuleCollider>());
            Destroy(gameObject.GetComponent<CapsuleCollider>());
            Destroy(gameObject, 0.5f);
        }
    }
}
