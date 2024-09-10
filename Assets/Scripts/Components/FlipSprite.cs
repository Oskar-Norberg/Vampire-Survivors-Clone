using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody.velocity.x > 0.0f)
        {
            if (transform.localScale.x > 0.0f) return;
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x);
            transform.localScale = newScale;
        }
        else
        {
            if (transform.localScale.x < 0.0f) return;
            Vector3 newScale = transform.localScale;
            newScale.x = -Mathf.Abs(newScale.x);
            transform.localScale = newScale;
        }
    }
}
