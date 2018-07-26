using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private MapRotation map;
    private GamePlay gp;
    private bool inCollision;
    private int count;

    public GameObject Destination;

    private void OnCollisionEnter(Collision collision) {
        Vector3 up = new Vector3(0, 500, 0);
        if (inCollision)
            return;
        rb.AddForce(up);
        inCollision = true;
        map.setCollisionPoint(transform.position);

        if(IsDestination(collision)) {
            gp.ClearGame();
        }
        Debug.Log(collision.gameObject.name);
        Color tileColor = collision.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Renderer>().material.GetColor("_Color");
        Color playerColor = transform.GetComponent<Renderer>().material.GetColor("_Color");
        transform.GetComponent<Renderer>().material.SetColor("_Color",addColor(tileColor, playerColor));

        collision.gameObject.SetActive(false);
    }

    void FixedUpdate () {
        if (inCollision) {
            count++;
            if (count > 3) {
                inCollision = false;
                count = 0;
            }
        }
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * 300);
        map = GameObject.Find("Map").GetComponent<MapRotation>();
        gp = GameObject.Find("GamePlay").GetComponent<GamePlay>();
        SetDestination();
		Reset();
    }

	public void Reset() {
		transform.position = new Vector3(0, 5, 0);
		transform.GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f));
	}

    private void SetDestination() {
        Destination = GameObject.Find("Area_2").transform.GetChild(0).gameObject;
    }

    private bool IsDestination(Collision c) {
        return c.transform.parent.name.Equals("Area_1") && c.transform.name.Equals("tile");
    }

	private Color addColor(Color tile, Color player) {
        Color c = player;
        if (c.r > tile.r)
            c.r -= 0.25f;
        else if (c.r < tile.r)
            c.r += 0.25f;

        if (c.g > tile.g)
            c.g -= 0.25f;
        else if (c.g < tile.g)
            c.g += 0.25f;

        c.b = 0.5f;
        return c;
    }
}
