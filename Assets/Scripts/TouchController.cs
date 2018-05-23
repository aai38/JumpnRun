using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour
{
    private Controll player;
 


    void Start()
    {
        player = FindObjectOfType<Controll>();
    }

    void Update() {
        SwipeCheck();
    }

   
    public void LeftArrow()
    {
        player.moveright = false;
        player.moveleft = true;
    }
    public void RightArrow()
    {
        player.moveright = true;
        player.moveleft = false;
    }
    public void ReleaseLeftArrow()
    {
        player.moveleft = false;
    }
    public void ReleaseRightArrow()
    {
        player.moveright = false;

    }

    private void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0)
            {
                jumpAllowed = true;
            }
        }
    }

    private void FixedUpdate()
    {
        JumpIfAllowed();
    }

    private void JumpIfAllowed()
    {
        if (jumpAllowed)
        {
            rb.AddForce(Vector2.up * jumpForce);
            jumpAllowed = false;
        }
    }
}