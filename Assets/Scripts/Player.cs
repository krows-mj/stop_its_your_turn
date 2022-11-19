using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedX, speedY;
    private float horizontal, vertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal += speedX * Input.GetAxis("Mouse X");
        vertical -= speedY * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(vertical, horizontal, 0.0f);
    }
}
