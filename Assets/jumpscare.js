#pragma strict

var scare : GameObject;
var played = false;
var trigger = false;
var ssound : AudioClip;

function Start () {
played = false;
scare.GetComponent.<Renderer>().enabled = false;
}

function OnTriggerEnter (other : Collider){
trigger = true;
}

function Update () {
if(trigger ==true){
scare.GetComponent.<Renderer>().enabled = true;
removeovertime();
sound();
}
}

function removeovertime(){
yield WaitForSeconds(0.6); 
scare.GetComponent.<Renderer>().enabled=false;
}
function sound(){
if (!played){
played = true;
GetComponent.<AudioSource>().PlayOneShot(ssound);
}
}
