#pragma strict
var maxHealth =1000;
var Health = 1000;
var scale=1f;
var enemyHP : GameObject;
enemyHP = GameObject.Find("Health");
function ApplyDamage (TheDamage:int) {
 Health -= TheDamage;
 scale=parseFloat((Health*1.0f)/maxHealth);
 enemyHP.gameObject.transform.localScale = new Vector3(scale, 1f, 1f);
   
 if(Health <=0){
	 Dead();
 }
}

function Dead () {
	Destroy(gameObject);
}