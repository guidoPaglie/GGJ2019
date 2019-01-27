using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvNoise : MonoBehaviour {
   public SpriteRenderer SpriteRenderer;

   public float tickTime;
   private float _timer;
   void Update() {
      if (_timer < tickTime) {
         _timer += Time.deltaTime;       
      }
      else {
         _timer = 0;
         SpriteRenderer.flipX = !SpriteRenderer.flipX;
      }
   }
}
