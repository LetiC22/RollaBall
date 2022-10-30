using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerVController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private float movementJump;


    // Start is called before the first frame update
    void Start()
    {
      rb= GetComponent<Rigidbody>();  
      count = 0;
      movementJump = 0;

      SetCountText();
      winTextObject.SetActive(false);

    }

  void OnMove(InputValue movementValue)
  {
    Vector2 movementVector = movementValue.Get<Vector2>();


    movementX = movementVector.x;
    movementY = movementVector.y;
  }

  private void OnJump(){

  if(transform.position.y <= 1)  
  {
    movementJump = 12.0f;
  }

  }

  void SetCountText(){
  
  countText.text = "Count: " + count.ToString();
  if(count >= 12)
  {
    winTextObject.SetActive(true);
  }
   

   if (count == 12)
            {
                Scene ActualScene = SceneManager.GetActiveScene();
                if (ActualScene.name == "MiniGame")
                {
                    SceneManager.LoadScene(2);
                }
                else
                {

                    SceneManager.LoadScene(0);
                }
               

            }


 /*if(count == 12){
    SceneManager.LoadScene(2);
  }*/

  }

void FixedUpdate()
{


    Vector3 movement = new Vector3(movementX, movementJump, movementY);


rb.AddForce(movement * speed);
movementJump = 0;



}
 private void OnTriggerEnter(Collider other)
{

    if(other.gameObject.CompareTag("PickUp")){

      
    other.gameObject.SetActive(false);
    count = count + 1;

    SetCountText();
    }


}
}
