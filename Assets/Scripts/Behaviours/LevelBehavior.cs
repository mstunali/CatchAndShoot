using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehavior : MonoBehaviour {
   public List<GameObject> LevelObjects = new List<GameObject>();

   private void Start() {
      LevelObjects[Mathf.Min(GameManager.instance.levelCount, LevelObjects.Count-1)].SetActive(true);
   }
}
