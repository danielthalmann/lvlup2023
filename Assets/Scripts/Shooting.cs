using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public GameObject bullet;
    public Transform throwPoint;
    // Update is called once per frame
    void Update()
    {
        if (rb.tag == "Truand" && Input.GetKeyDown(KeyCode.E))
            Shoot();
    }

    void Shoot()
    {
        GameObject bulletClone = (GameObject)Instantiate(bullet, throwPoint.position, throwPoint.rotation);
        bulletClone.transform.localScale = transform.localScale;
        Destroy(bulletClone, 0.5f);
    }
}
