using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) GetComponentInParent<PlayerMove>().damageTake(other.GetComponent<Enemy>().damage);
        if (other.CompareTag("ExpPoint")) GetComponentInParent<PlayerMove>().pointTake();
    }
}
