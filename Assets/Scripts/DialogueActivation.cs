using UnityEngine;
using System.Collections;

public class DialogueActivation : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject player;

	private bool playerDetected = false;
    private bool boxActive = false;

    private RectTransform trans;
    private PlayerController playerCont;
    private Rigidbody2D playerRbody;

    void Start()
    {
        trans = dialogBox.GetComponent<RectTransform>();
        playerCont = player.GetComponent<PlayerController>();
        playerRbody = player.GetComponent<Rigidbody2D>();
    }
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player")
			playerDetected = true;
	}
	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Player")
			playerDetected = false;
	}
	void Update()
	{
		if (playerDetected == true && Input.GetButtonDown("Interact") && boxActive == false)
		{
            playerCont.enabled = false;
            playerRbody.constraints = RigidbodyConstraints2D.FreezeAll;
            trans.localScale = new Vector3(1,1,1);
            boxActive = true;
		} else if (Input.GetButtonDown("Interact") && boxActive == true)
        {
            playerCont.enabled = true;
            playerRbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            trans.localScale = new Vector3(0, 0, 1);
            boxActive = false;
        }
	}
}