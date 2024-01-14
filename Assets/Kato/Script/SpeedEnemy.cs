using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemy : MonoBehaviour
{
    public float m_velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(m_velocity, 0, 0);
    }
}
