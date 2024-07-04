using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")] //Create a new playerData object by right clicking in the Project Menu then Create/Player/Player Data and drag onto the player
public class PlayerData : ScriptableObject
{
	

	[Header("Run")]
	public float speed;
	public float acceleration;
	public float deccel;
	
	
	
}