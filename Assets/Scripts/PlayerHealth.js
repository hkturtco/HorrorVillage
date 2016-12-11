#pragma strict

var curHealth : int = 100;
var maxHealth : int = 100;
var healthtext : GUIText;
var regenActive : boolean=true;
function Start(){
    healthRegen();
}
 
function Update(){
 
    healthtext.text = curHealth + " / " + maxHealth;
 
    if(curHealth < 0 ) {
        curHealth = 0;
    }
 
    if(curHealth > 100) {
        curHealth = 100;
    }
 
    if(Input.GetKeyDown("e")) {
        curHealth -= 10;
    }
}
 
function healthRegen(){
 
    while(regenActive) {
        yield WaitForSeconds(0.5);
 
        if(curHealth < maxHealth) {
            curHealth++;
        }
    }
}
