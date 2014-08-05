using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour 
{
	bool isPickedUp = false;

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag =="Player")
		{
			isPickedUp = true;
			Debug.Log ("Picked up!");
			//StartCoroutine(RespawnItem());
		}
		
		//isPickedUp = false;
	}

	//Respawn the pickup
	IEnumerator RespawnItem()
	{
		if(isPickedUp)
		{
			int respawnTime = 3;
			yield return new WaitForSeconds(respawnTime);
			//GameObject.GetComponent(MeshRenderer).enabled = true;
			//Mesh = gameObject.GetComponent("Mesh Renderer") as MeshRenderer;
			gameObject.GetComponent<MeshRenderer>().enabled = true;
			gameObject.GetComponent<Collider>().enabled = true;
			//collider.enabled = true;
			//GameObject.GetComponent(Collider).enabled = true;
			Debug.Log ("Spawned!");
		}	
		
	}

}
