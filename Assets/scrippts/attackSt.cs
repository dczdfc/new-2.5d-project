using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackSt : state
{
    private Camera mainCamera;
    public float stTime;
    private float curTime;

    public float speedMod, decel;
    public GameObject weapon;
    public Rigidbody2D RB { get; private set; }
    private Vector3 mousePos, speed;
    private void Awake(){
        RB = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    public override void start()
	{

        curTime = stTime;
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        
        if(rotZ > 90 || rotZ < -90){
            transform.localScale = new Vector3(-1,1,1);
            weapon.transform.rotation = Quaternion.Euler(0, 0, 180+rotZ);
        }else{
            weapon.transform.rotation = Quaternion.Euler(0, 0, rotZ);
            transform.localScale = new Vector3(1,1,1);
        } 
        
	RB.AddForce(rotation.normalized * speedMod, ForceMode2D.Force);
    speed = rotation.normalized * speedMod;
	}
    public override void update()
	{
	
	}
    public override void fixedupdate()
	{
        curTime -= Time.fixedDeltaTime;
        if (curTime <= 0){
            exitState();

        }
        float speedDifY = -RB.velocity.y;
        float speedDifX = -RB.velocity.x;
		
		Vector2 movement = speedDifX * decel * Vector2.right + speedDifY * decel * Vector2.up;

		
		RB.AddForce(movement, ForceMode2D.Force);
	
    }
    public override void exitState(){
        RB.velocity = Vector2.zero;
    }
}
