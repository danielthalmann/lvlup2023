using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTarget : MonoBehaviour
{
    public Camera cam;

    private Vector3 offset;
    public float smoothSpeed = 0.125f;
    public Transform target;

    private void Start()
    {
        offset = cam.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, offset.z);
        Vector3 SmoothPosition = Vector3.Lerp(cam.transform.position, desiredPosition, smoothSpeed);
        cam.transform.position = SmoothPosition;
    }

    [SerializeField] private Rigidbody2D rb;
    public GameObject bullet;
    public Transform throwPoint;
    // Update is called once per frame
    void Update()
    {
        if (rb.tag == "Truand" && Input.GetKeyDown(KeyCode.E))
            Shooting();
    }

    void Shooting()
    {
        GameObject bulletClone = (GameObject)Instantiate(bullet, throwPoint.position, throwPoint.rotation);
        bulletClone.transform.localScale = transform.localScale;
        Destroy(bulletClone, 0.5f);
    }
}
