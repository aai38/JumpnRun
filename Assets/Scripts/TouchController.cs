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
    public void UpArrow() {
        player.moveup = true;
    }
    public void ReleaseUpArrow() {
        player.moveup = false;
    }
    public void Shoot () {
        player.shoot = true;
    }
    public void ReleaseShoot(){
        player.shoot = false;
    }


}