using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearCollectables : MonoBehaviour
{

    float lifeTime = 5.0f;

    void Awake()
    { Destroy(gameObject, lifeTime); }
}
