using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC : MonoBehaviour
{
    /*Miscellaneous Player Code*/
    public float speed = 10f;
    public bool grounded = true;
    private Rigidbody2D rb2d;
    public float jumpPower;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformsLayerMask;

    /*Variables related to the Death Animation*/
    GameObject deathMessage;
    CameraFollow cameraScript;
    
    // Start is called before the first frame update
    void Start()
    {
        deathMessage = GameObject.Find("DeathMessage");
        cameraScript = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        //cameraScript = camera.GetComponent<CameraFollow>();
        rb2d = rb2d = GetComponent<Rigidbody2D> ();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        deathMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            rb2d.velocity = Vector2.up * jumpPower;
        }

        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Piston")){
            DeathAnimation();
        }
    }

    private void DeathAnimation(){
        cameraScript.following = false;
        boxCollider2D.enabled = false;
        GameObject.Find("PistonProgress").GetComponent<PistonProgress>().enabled = false;
        GameObject.Find("PlayerProgress").GetComponent<PlayerProgress>().enabled = false;
        GameObject.Find("Piston").GetComponent<PistonMovement>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<CameraShake>().CallShake();
        rb2d.velocity = new Vector2(70.0f, 20.0f);
    }

    public void DeathMessage(){
        deathMessage.SetActive(true);
        Application.Quit();
    }
}
