using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pueba_objetoaplastante : MonoBehaviour
{
    public GameObject chain;
    public GameObject objectToDrop;
    public float chainLife = 100f;

    private bool isChainBroken = false;
    private Rigidbody objectToDropRigidbody;

    private void Start()
    {
        objectToDropRigidbody = objectToDrop.GetComponent<Rigidbody>();
        objectToDropRigidbody.isKinematic = true;
    }

    private void Update()
    {
        if (chainLife <= 0f && !isChainBroken)
        {
            BreakChain();
        }
    }

    private void BreakChain()
    {
        isChainBroken = true;
        objectToDropRigidbody.isKinematic = false;

        // Puedes a�adir aqu� cualquier efecto o animaci�n cuando el objeto asignado caiga

        Destroy(chain);

        // L�neas adicionales para hacer que el objeto asignado caiga
        objectToDrop.transform.parent = null;
        objectToDropRigidbody.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            chainLife -= 10f; // Valor de vida que disminuye cuando el objeto con Trigger colisiona

            // Puedes a�adir aqu� cualquier efecto o animaci�n cuando la cadena recibe da�o
        }
    }
}






