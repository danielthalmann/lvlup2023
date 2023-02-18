using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public GameObject bullet;
    public Transform throwPoint;
    // Update is called once per frame
    void Update()
    {
        if (name == "Brute" && Input.GetKeyDown(KeyCode.E))
            Break();
        else if (name == "Bon" && Input.GetKeyDown(KeyCode.E))
            Activate();
        else if (name == "Truant" && Input.GetKeyDown(KeyCode.E))
            Shoot();
    }

    void Activate()
    {
        Debug.Log("Activer !");
    }

    void Shoot()
    {
        GameObject bulletClone = (GameObject)Instantiate(bullet, throwPoint.position, throwPoint.rotation);
        bulletClone.transform.localScale = transform.localScale;
        Destroy(bulletClone, 0.5f);
    }

    void Break()
    {
        Debug.Log("C cassé");
    }
}
