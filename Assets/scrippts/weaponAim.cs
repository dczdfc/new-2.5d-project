using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponAim : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.rotation.z > 0.7f || transform.rotation.z < -0.7f){
            transform.localScale = new Vector3(1,-1,1);
            
        }else transform.localScale = new Vector3(1,1,1);
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        
    }
}
