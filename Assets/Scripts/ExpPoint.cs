using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            GetComponentInChildren<Animator>().SetBool("pick", true);
            GetComponentInChildren<ParticleSystem>().Play();
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject, 0.5f);
        }
    }
}
