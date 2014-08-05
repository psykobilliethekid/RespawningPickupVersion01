//Coder: Danielle Moss
//Code referenced from Quill18Creates - Simple FPS Shooter Tutorial
//Video #1: http://youtu.be/mbm9lPB5GPw
//Video #2: http://youtu.be/rhpJPx8fICQ
//Video #3: http://youtu.be/mHk21MHyuqI
//Pickup and Counter referenced Unity Roll-A-Ball Tutorial: http://unity3d.com/learn/tutorials/projects/roll-a-ball
using UnityEngine;
using System.Collections;

public class ThirdPersonController1 : MonoBehaviour {
	
	//Variables for movement
	public float movementSpeed = 5.0f;
	float verticalVelocity = 0;
	public float jumpSpeed = 20;
	CharacterController character;

	//Variables for Pickup and Counter
	public GUIText countText; //shows how many spheres have been picked up
	public GUIText winText; //shows message when you win the game
	private int count; //counting the spheres as they are picked up

	public bool guiIsOn = false;

	bool isPickedUp = false;
	GameObject PickedUp;
	GameObject Pickup;

	void Awake()
	{
		Time.timeScale = 1;
	}

	// Use this for initialization
	void Start () 
	{
		count = 0; //starts count at 0
		SetCountText(); //called method to add spheres as they are picked up
		winText.text = "";  //empty at game start
	}
	
	// Update is called once per frame
	void Update () 
	{

		//Get the Character Controller//
		CharacterController character = GetComponent<CharacterController>();


		//Character Movement//
		float FBSpeed = Input.GetAxis("Vertical") * movementSpeed; //forward and back movement
		float LRSpeed = Input.GetAxis("Horizontal") * movementSpeed; //left and right movement
		
		verticalVelocity += Physics.gravity.y * Time.deltaTime; //jump velocity aka how high you jump
		Vector3 speed = new Vector3(LRSpeed, verticalVelocity, FBSpeed); //get the Vector for the speed
		speed = transform.rotation * speed;  //storing the speed
		character.Move(speed * Time.deltaTime); //get the character movement speed


		//Check to see if the Character is on the ground and Jump is pressed
		if (Input.GetButtonDown("Jump") && (character.isGrounded))
		{
			verticalVelocity = jumpSpeed;
		}
	}

	//when the player hits the game object labeled "Pickup"
	//the game object will deactivate and disappear
	void OnTriggerEnter(Collider other) 
	{
			if(other.gameObject.tag =="Pickup")
			{
				Pickup = other.gameObject; 
				Pickup.SetActive(false);
				count = count + 1; //increases number of spheres picked up
				SetCountText(); //called method to add spheres as they are picked up
				isPickedUp = true;
				Debug.Log ("Picked up!");
				StartCoroutine(RespawnItem());
			}
	}

	//Respawn the pickup
		 IEnumerator RespawnItem ()
		 {
		 	if(isPickedUp)
			 {
				 int respawnTime = 3;
				 yield return new WaitForSeconds(respawnTime);
				 Pickup.SetActive(true);
				 Debug.Log ("Spawned!");
			 }
		
			isPickedUp = false;
		 }

	void SetCountText()  //shows the number of picked up spheres in the GUI
	{
		countText.text = "Count: " + count.ToString();

		//if all 7 spheres are picked up show win text
		if(count >= 7)
		{
			winText.text = "You Win!";
			Debug.Log ("hey!");
			Time.timeScale = 0;
			guiIsOn = true;
			OnGUI();
		}
	}

	void OnGUI()
	{ 
		if (guiIsOn)
		{
			// Make the first button. If it is pressed, Application.LoadLevel(Application.loadedLevel) will be executed
			if(GUI.Button(new Rect(Screen.width/2-40, Screen.height/2+10,80,20), "Play Again?")) 
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}