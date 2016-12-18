using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 using UnityEngine.UI;

public class startbtn : MonoBehaviour {

      public void test(int index)
      {
          SceneManager.LoadScene(index);
          Resources.UnloadUnusedAssets();
      }
  
      public void test2(string levelName)
      {
          Application.LoadLevel(levelName);
      }
}
