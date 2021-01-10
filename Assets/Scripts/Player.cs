using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool grounded;
    private bool readyToJump;
    public GameObject line;
    private float jumpForce = 100;
    public Rigidbody2D player;

    // Visuals
    public LineRenderer lr;
    void Start()
    {
        line = new GameObject();
        line.transform.position = player.transform.position;
        line.AddComponent<LineRenderer>();
        player = GetComponent<Rigidbody2D>();
        readyToJump = true;
    }
    // Update is called once per frame
    void Update()
    {
        player.freezeRotation = true;
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0)) 
        {
            
            DrawLine(mousepos);
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
            lookPos = lookPos - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            player.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
            if (!readyToJump) return;
            float force = Vector3.Distance(player.transform.position, mousepos);
            player.velocity = player.transform.up * force * 1.5f;
            readyToJump = false;
            
            
        }

       
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        readyToJump = true;
        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 direction = new Vector3(collision.GetContact(0).point.x, collision.GetContact(0).point.y - 0.4f) - player.transform.position;
            direction = -direction;
            player.velocity = direction * 30;
            Destroy(collision.gameObject);
        }


    }

    void DrawLine(Vector3 mousepos)
    {
        lr = line.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Unlit/Texture"));
        lr.enabled = true;
        lr.loop = true;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, player.transform.position);
        lr.SetPosition(1, mousepos);
    }
    

}
