//ElevatorCrushCollider.cs by Azuline StudiosÂ© All Rights Reserved
using UnityEngine;
using System.Collections;
//script for instant death collider which kills player on contact
public class ElevatorCrushCollider : MonoBehaviour {
	public AudioClip squishSnd;
	void OnTriggerEnter ( Collider col  ){
		FPSPlayer player = col.GetComponent<FPSPlayer>();
		
		if (player) {
			player.ApplyDamage(player.maximumHitPoints + 1);
			AudioSource.PlayClipAtPoint(squishSnd, player.transform.position, 0.75f);
		}
	}
	
	void Reset (){
		if (GetComponent<Collider>() == null){
			gameObject.AddComponent<BoxCollider>();
			GetComponent<Collider>().isTrigger = true;
		}
	}
}