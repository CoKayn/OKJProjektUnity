using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Rigidbody2D player;
    public Rigidbody2D hook;

    public float releaseTime = .15f;
    public float maxDragDistance = 2f;

    private bool isPressed = false;
    
    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                player.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            }
            else
            {
                player.position = mousePos;
            }

        }

        

     
    }
    void OnMouseDown()
    {
        isPressed = true;
        player.isKinematic = true;
    }
    void OnMouseUp()
    {
        isPressed = false;
        player.isKinematic = false;

        StartCoroutine(Release());
    }
    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(2f);

    }
}
