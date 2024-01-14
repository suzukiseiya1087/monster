using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ‰¼‚ÌˆÚ“®ˆ—
        if (Input.GetKey(KeyCode.RightArrow))
        {// ‰E•ûŒü‚ÌˆÚ“®“ü—Í
            Vector2 pos = transform.position;
            pos.x += 0.05f;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {// ¶•ûŒü‚ÌˆÚ“®“ü—Í
            Vector2 pos = transform.position;
            pos.x -= 0.05f;
            transform.position = pos;
        }
    }
}
