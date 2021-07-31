using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public float initialSpeed = 0.2f;
    private float speed = 0.2f;
    public Rigidbody rb;
    public GameObject explosion;
    public CameraSmoothFollow cameraFollow;
    public GameObject gameOverMenu;

    public Text score;
    public Text combo;

    private AudioSource scoreSound;

    void Start() {
        speed = initialSpeed;
        cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraSmoothFollow> ();
        cameraFollow.enabled = true;
        score = GameObject.Find("ScoreText").GetComponent<Text>();
        combo = GameObject.Find("ComboText").GetComponent<Text>();
        scoreSound = GameObject.Find("ScoreSound").GetComponent<AudioSource>();
    }


    void FixedUpdate () {
        if (Input.GetMouseButton(0)) {
            if(speed < 0.7f) {
                speed += 0.05f;
            }
         }else {
             speed = initialSpeed;
             Vars.combo = 1;
             combo.enabled = false;
         }
		rb.transform.position = new Vector3 (rb.transform.position.x, rb.transform.position.y, rb.transform.position.z + speed);
    }

    void OnTriggerEnter(Collider col) {
        scoreSound.pitch = 0.9f + (float)Vars.combo / 10;
        scoreSound.Play();
        Vars.score += Vars.combo;
        score.text = "SCORE: " + Vars.score;
        combo.text = "+" + Vars.combo;
        if(Vars.combo > 1) {
            combo.enabled = true;
        }
        Vars.combo++;
    }

    void OnCollisionEnter(Collision col) {
        explosion.transform.parent = null;
        explosion.SetActive(true);
        cameraFollow.enabled = false;
        GameObject.Find("GameManager").GetComponent<Menus>().ShowGameOverMenu();
        GameObject.Find("ExplosionSound").GetComponent<AudioSource>().Play();
        Destroy(this.gameObject);
    }

}
