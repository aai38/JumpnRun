using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearCollectables : MonoBehaviour
{

    float lifeTime = 10.0f;

    void Awake()
    { Destroy(gameObject, lifeTime); }
}
