using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : MonoBehaviour
{
    public float m_velocity = 0;
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
