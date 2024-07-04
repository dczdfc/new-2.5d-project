

using System.Collections;
using UnityEngine;

public class PlayerMovement : state
{

	public PlayerData Data;

	
    public Rigidbody2D RB { get; private set; }
	private Vector2 _moveInput;
	public GameObject TurnObject;
	public bool IsFacingRight { get; private set; }

	
    private void Awake()
	{
		RB = GetComponent<Rigidbody2D>();
	}

	public override void start()
	{
		IsFacingRight = true;
	
	}

	public override void update()
	{
        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
		

		if (_moveInput.x != 0)
			CheckDirectionToFace(_moveInput.x < 0);
	}	

    public override void fixedupdate()
	{
		Run();
    }

	private void Run(){

		float targetSpeedX = _moveInput.x * Data.speed;
		float accelRateX;
		accelRateX = (Mathf.Abs(targetSpeedX) > 0.01f) ? Data.acceleration : Data.deccel;
		float speedDifX = targetSpeedX - RB.velocity.x;

		float targetSpeedY = _moveInput.y * Data.speed;
		float accelRateY;
		accelRateY = (Mathf.Abs(targetSpeedY) > 0.01f) ? Data.acceleration : Data.deccel;
		float speedDifY= targetSpeedY - RB.velocity.y;
		
		Vector2 movement = speedDifX * accelRateX * Vector2.right + speedDifY * accelRateY * Vector2.up;

		
		RB.AddForce(movement, ForceMode2D.Force);
		

		


	}
	private void Turn()
	{
		//stores scale and flips the player along the x axis, 
		Vector3 scale = TurnObject.transform.localScale; 
		scale.x *= -1;
		TurnObject.transform.localScale = scale;

		IsFacingRight = !IsFacingRight;
	}
    


    
    public void CheckDirectionToFace(bool isMovingRight)
	{
		if (isMovingRight != IsFacingRight)
			Turn();
	}
	public override void exitState(){
		RB.velocity = Vector2.zero;

	}
    

}