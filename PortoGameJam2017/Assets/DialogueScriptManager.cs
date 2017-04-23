using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueScriptManager : MonoBehaviour {

	public GameObject player;
	public Image image;

	public int dialogueIndex;

	public Sprite[] oldManSprites;
	public Sprite[] area1Sprites;
	public Sprite[] transition1Sprites;
	public Sprite[] area2Sprites;
	public Sprite[] transition2Sprites;
	public Sprite[] bossSprites;

	public bool[] engaged;
	private int current_index;

	void Start ()
	{
		dialogueIndex = 0;
		current_index = 0;
		engaged = new bool[]{false, false, false, false, false, false};
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!engaged[dialogueIndex])
			return;

		switch (dialogueIndex)
		{
		case 0:
			updateOldMan ();
			break;

		case 1:
			updateArea1 ();
			break;

		case 2:
			updateTransition1 ();
			break;

		case 3:
			updateArea2 ();
			break;

		case 4:
			updateTransition2 ();
			break;

		case 5:
			updateBoss ();
			break;

		default:
			break;
		}
	}

	// OLD MAN

	public void updateOldMan()
	{
		if (current_index == oldManSprites.Length)
		{
			changeTransparency (false);
			engaged[dialogueIndex] = false;
			return;
		}

		image.sprite = oldManSprites [current_index];

		if(Input.GetKeyUp(KeyCode.E))
		{
			current_index++;

			if (current_index == oldManSprites.Length)
			{
				return;
			}

			image.sprite = oldManSprites [current_index];
		}
	}

	// Area 1

	public void updateArea1()
	{
		if (current_index == area1Sprites.Length)
		{
			changeTransparency (false);
			engaged[dialogueIndex] = false;
			return;
		}

		image.sprite = area1Sprites [current_index];

		if(Input.GetKeyUp(KeyCode.E))
		{
			current_index++;

			if (current_index == area1Sprites.Length)
			{
				return;
			}

			image.sprite = area1Sprites [current_index];
		}
	}

	// Transition 1

	public void updateTransition1()
	{
		if (current_index == transition1Sprites.Length)
		{
			changeTransparency (false);
			engaged[dialogueIndex] = false;
			return;
		}

		image.sprite = transition1Sprites [current_index];

		if(Input.GetKeyUp(KeyCode.E))
		{
			current_index++;

			if (current_index == transition1Sprites.Length)
			{
				return;
			}

			image.sprite = transition1Sprites [current_index];
		}
	}

	// Area 2

	public void updateArea2()
	{
		if (current_index == area2Sprites.Length)
		{
			changeTransparency (false);
			engaged[dialogueIndex] = false;
			return;
		}

		image.sprite = area2Sprites [current_index];

		if(Input.GetKeyUp(KeyCode.E))
		{
			current_index++;

			if (current_index == area2Sprites.Length)
			{
				return;
			}

			image.sprite = area2Sprites [current_index];
		}
	}

	// Transition 2

	public void updateTransition2()
	{
		if (current_index == transition2Sprites.Length)
		{
			changeTransparency (false);
			engaged[dialogueIndex] = false;
			return;
		}

		image.sprite = transition2Sprites [current_index];

		if(Input.GetKeyUp(KeyCode.E))
		{
			current_index++;

			if (current_index == transition2Sprites.Length)
			{
				return;
			}

			image.sprite = transition2Sprites [current_index];
		}
	}

	// Boss

	public void updateBoss()
	{
		if (current_index == bossSprites.Length)
		{
			changeTransparency (false);
			engaged[dialogueIndex] = false;
			return;
		}

		image.sprite = bossSprites [current_index];

		if(Input.GetKeyUp(KeyCode.E))
		{
			current_index++;

			if (current_index == bossSprites.Length)
			{
				SceneManager.LoadScene ("gameMenu");
				return;
			}

			image.sprite = bossSprites [current_index];
		}
	}

	// COLLISIONS
	 
	public void collidedWithOldMan()
	{
		dialogueIndex = 0;
		processCollision ();
	}

	public void collidedWithArea1()
	{
		dialogueIndex = 1;
		processCollision ();
	}

	public void collidedWithTransition1()
	{
		dialogueIndex = 2;
		processCollision ();
	}

	public void collidedWithArea2()
	{
		dialogueIndex = 3;
		processCollision ();
	}

	public void collidedWithTransition2()
	{
		dialogueIndex = 4;
		processCollision ();
	}

	public void collidedWithBoss()
	{
		dialogueIndex = 5;
		processCollision ();

	}

	public void processCollision()
	{
		if (engaged [dialogueIndex] == false)
		{
			current_index = 0;
			engaged [dialogueIndex] = true;
			changeTransparency (true);
		}
	}

	public void changeTransparency(bool option)
	{
		Color c = image.color;
		if (option)
			c.a = 1;
		else
			c.a = 0;
		image.color = c;
	}
}
