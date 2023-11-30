using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    bool fall;
    float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (fall && timer >= 0.5f)
        {
            transform.position += 4f * Time.deltaTime * Vector3.down;
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= 0.5f)
            {
                Destroy(gameObject, t: 2f);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fall = true;
        }
    }
}
