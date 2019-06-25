using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

  private Rigidbody rb;
  private Animation anim;

  void Start(){
    rb = GetComponent<Rigidbody>();
    anim = GetComponent<Animation>();
  }

  void Update(){
    float x = CrossPlatformInputManager.GetAxis("Horizontal");
    float z = CrossPlatformInputManager.GetAxis("Vertical");

    Vector3 mov = new Vector3(x, 0, z);
    rb.velocity = mov * 2f;

    if (x != 0 && z != 0){
      transform.eulerAngles = new Vector3(
        transform.eulerAngles.x, 
        Mathf.Atan2(x, z)  * Mathf.Rad2Deg, 
        transform.eulerAngles.z);
    }
    if (x != 0 || z != 0){
     // anim.Play("Walk");
    }else{
     // anim.Play("Wait");
    }
  }

  public void Attack(){
    anim.Play("Attack");
  }

  private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player")){
      
      GameObject crackedObject = Instantiate(Resources.Load("Whisky_Bottle_Cracked", typeof(GameObject))) as GameObject;
      crackedObject.transform.position = other.transform.position;
      crackedObject.transform.rotation = other.transform.rotation;
      Destroy(other.gameObject);
    }
  }
}
