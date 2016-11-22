using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 using UnityEngine.UI;

public class startbtn : MonoBehaviour {

      public void test(int index)
      {
          Application.LoadLevel(index);
      }
  
      public void test2(string levelName)
      {
          Application.LoadLevel(levelName);
      }
}
