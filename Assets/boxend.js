#pragma strict

function Start () {

}

function Update () {

}

 function OnGUI () {
 
 if ( Input.GetKeyDown(KeyCode.R)) {
 
 Application.LoadLevel(Application.loadedLevel);
 Time.timeScale = 1;
 
   }
 }