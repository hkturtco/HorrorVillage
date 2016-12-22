#pragma strict
var maxHealth =1000;
var Health = 1000;
var scale=1f;
var enemyHP : GameObject;
var monster_animator : Animator;
var audio_gethit : GameObject;
function ApplyDamage (TheDamage:int) {
 	Health -= TheDamage;
 	scale=parseFloat((Health*1.0f)/maxHealth);
 	enemyHP.gameObject.transform.localScale = new Vector3(scale, 1f, 1f);
 	var animatorstateinfo = monster_animator.GetCurrentAnimatorStateInfo(0);
 	if (!animatorstateinfo.IsName("GetHit")){
			monster_animator.SetTrigger("GetHit");
			audio_gethit.gameObject.SetActive(true);
	}

 	if(Health <=0){
	 	monster_animator.SetTrigger("dead");
 	}
}

