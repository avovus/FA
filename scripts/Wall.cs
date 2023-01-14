using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Animator anim;

    private void Start(){
        anim = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag != "Player" && other.gameObject.GetComponent<Pick>().id == 0){
            Destroy(other.gameObject);
            anim.SetTrigger("isTriggered");
        }
    }
}
