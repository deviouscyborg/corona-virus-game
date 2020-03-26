using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class RandomBackground : MonoBehaviour {
 
     public Sprite[] Backgrounds; //this is an array of type sprite
 
     public SpriteRenderer Render; //this is a variable of type sprite renderer
 
     // Use this for initialization
     void Start () {
            Render = GetComponent<SpriteRenderer>(); 
            /*assigning the Render to the object's SpriteRender, this will allow us to access the image from 
            code*/
            Render.sprite = Backgrounds[Random.Range(0, Backgrounds.Length)]; 
            /*this will change the current sprite of the sprite renderer to a random sprite that was chosen 
            randomly from the array of backgrounds */
         }
     // Update is called once per frame
     void Update () {
 
     }
 }