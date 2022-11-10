using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class portalController : MonoBehaviour
{
    public GameObject destinyPortal;

    private bool inPortal =false;
    private GameObject player;
    private Vector3 portalPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inPortal)
        {
            Debug.Log("EnterPortal");
            Debug.Log(portalPosition);
            player.transform.position = portalPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("InPortal");
            portalPosition = new Vector3(destinyPortal.transform.position.x, destinyPortal.transform.position.y-1.6f, 0);
            inPortal = true;
            Debug.Log(portalPosition);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            portalPosition = Vector3.zero;
            inPortal = false;
            Debug.Log(portalPosition);
            Debug.Log("ExitPortal");
        }
    }
}
