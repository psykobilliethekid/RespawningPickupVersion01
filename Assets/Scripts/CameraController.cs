using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

	public GameObject player; //player object
	private Vector3 offset; //offset value from player to camera

	public float mouseSensitivity = 0.1f; //how sensitive the camera is when moving
	public float UpDownRange = 60.0f;  //restricts range of up/down movement on camera
	
	// Use this for initialization
	void Start () 
	{
		offset = transform.position; //distance the player is from the camera
	}
	
	// Update is called once per frame
	void LateUpdate()
	{
		transform.position = player.transform.position + offset; //changes the distance as the player moves
		
	}

	void Update()
	{
		//Character Camera Rotation//
		
		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity; //rotating left and right - Right analog stick
		transform.Rotate (0, rotLeftRight, 0);      //rotate the object

		float rotUpDown = Input.GetAxis("Mouse Y") * mouseSensitivity; //rotating up and down - Right analog stick
		transform.Rotate (rotUpDown,0, 0);      //rotate the object

		//float currentUpDown = Camera.main.transform.rotation.eulerAngles.x;
		//float desiredUpDown = currentUpDown - rotUpDown;

		//Camera.main.transform.rotation = Quaternion.Euler(desiredUpDown, 0, 0);
	
	}

}
