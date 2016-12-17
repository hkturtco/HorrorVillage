#pragma strict

var bulletDamage = 20;

function OnCollisionEnter (info : Collision){
	
	info.transform.SendMessage("ApplyDamage",bulletDamage,SendMessageOptions.DontRequireReceiver);
	Destroy(gameObject);
}
