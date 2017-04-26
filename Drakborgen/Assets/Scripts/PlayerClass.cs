using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClass : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;
	public int gold;
	public float attack;
	public float defense;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
	public Text goldText;

	//private fields
	bool isDead;
	bool damaged;


	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		currentHealth = maxHealth;
		healthSlider.maxValue = maxHealth;
		healthSlider.value = currentHealth;
		damaged = false;
		isDead = false;
		goldText.text = gold.ToString();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (damaged)
		{
			damageImage.color = flashColor;
		}
		else
		{
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;

		// test/debug
		if (Input.GetKeyDown(KeyCode.F))
		{
			Damage(3);
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
			AddGold((int)Random.Range(1, 11));
		}
	}

	public void Defend(float attackValue){
		if ((attackValue - defense) > 0)
			Damage(attackValue - defense);
	}

	public void Damage(float value){
		currentHealth -= value;
		damaged = true;
		
		healthSlider.value = currentHealth;
		if (healthSlider.value < 0) healthSlider.value = 0;
		
		if (currentHealth <= 0 && !isDead)
		{
			Death();
		}
	}

	public void Death()
	{
		isDead = true;

		// more here
	}

	public void AddGold(int value)
	{
		gold += value;
		goldText.text = gold.ToString();
	}
}
