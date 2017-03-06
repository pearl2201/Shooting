//InstantDeathCollider.cs by Azuline StudiosÂ© All Rights Reserved
using UnityEngine;
using System.Collections;
//script for instant death collider which kills player on contact
public class InstantDeathCollider : MonoBehaviour {
	void OnTriggerEnter ( Collider col  ){
		FPSPlayer player = col.GetComponent<FPSPlayer>();
		
		if (player) {
			player.ApplyDamage(player.maximumHitPoints + 1);
		} else if (col.GetComponent<Rigidbody>()) {	
			Destroy(col.GetComponent<Rigidbody>().gameObject);
		} else {
			Destroy(col.gameObject);
		}
	}
	
	void Reset (){
		if (GetComponent<Collider>() == null){
			gameObject.AddComponent<BoxCollider>();
			GetComponent<Collider>().isTrigger = true;
		}
	}
}