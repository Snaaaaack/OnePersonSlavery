﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private MapRotation map;
    private GamePlay gp;
    private bool inCollision;
    private int count;
    List<GameObject> fading;

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

        collision.gameObject.GetComponent<MeshCollider>().isTrigger = true;
		collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
		collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, -1000f, 0f));
		
		Fade(collision.gameObject);
		//collision.gameObject.SetActive(false);
	}

    void FixedUpdate () {
        if (inCollision) {
            count++;
            if (count > 3) {
                inCollision = false;
                count = 0;
            }
        }
        
        FadeUpdate();
    }

    void Start() {
        fading = new List<GameObject>();
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
        string area = "Area_" + Data.DestArea;
        Destination = GameObject.Find(area).transform.GetChild(Data.DestTile).gameObject;
    }

    private bool IsDestination(Collision c) {
        string area = "Area_" + Data.DestArea.ToString();
        string tile = "tile" + (Data.DestTile == 0 ? "" : " (" + Data.DestTile.ToString() + ")");
        
        return c.transform.parent.name.Equals(area) && c.transform.name.Equals(tile);
    }

	private Color addColor(Color tile, Color player) {
        Color c = player;

        if (c.r == 1f)
            return tile;

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

    private void Fade(GameObject tile) {
        fading.Add(tile);
    }

    private void FadeUpdate() {
        GameObject remove = null;
        foreach(GameObject obj in fading) {
            Material mat = obj.GetComponent<Transform>().GetChild(0).GetComponent<Renderer>().material;
            Color c = mat.GetColor("_Color");

            if(c.a <= 0.0f) {
                obj.SetActive(false);
                remove = obj;
                continue;
            }
            
            c.a -= 0.02f;
            mat.SetColor("_Color", c);
        }
        if(remove != null)
            fading.Remove(remove);
    }
}
