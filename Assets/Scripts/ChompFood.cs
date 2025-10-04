using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChompFood : MonoBehaviour
{

    private GameManager gm;

    [SerializeField]
    private AudioSource chompSound;

    private Button currentButtonHovered = null;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        Cursor.visible = false;
    }

    private void Update()
    {
        if (currentButtonHovered != null)
        {
            currentButtonHovered.Select();

            if (Input.GetMouseButtonUp(0))
            {
                currentButtonHovered.onClick.Invoke();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Food")
        {
            chompSound.pitch = Random.Range(0.8f, 1.2f);
            chompSound.Play();
            Destroy(collision.transform.gameObject);
            gm.IncreaseScore(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UIButton")
        {
            currentButtonHovered = other.GetComponent<Button>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "UIButton")
        {
            EventSystem.current.SetSelectedGameObject(null);
            currentButtonHovered = null;
        }
    }

}
