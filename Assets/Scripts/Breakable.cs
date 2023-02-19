using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public GameObject bullet;
    public Transform throwPoint;
    // Update is called once per frame
    void Update()
    {
        if (rb.tag == "Brute" && Input.GetKeyDown(KeyCode.E))
            Shoot();
    }

    void Shoot()
    {
        Debug.Log("Wakanda");
        GameObject bulletClone = (GameObject)Instantiate(bullet, throwPoint.position, throwPoint.rotation);
        bulletClone.transform.localScale = transform.localScale;
        Destroy(bulletClone, 1f);
    }
}

