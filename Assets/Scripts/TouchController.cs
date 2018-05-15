using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour
{
    private Controll player;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;


    void Start()
    {
        player = FindObjectOfType<Controll>();
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
}