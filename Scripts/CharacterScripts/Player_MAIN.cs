using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class Player_MAIN : MonoBehaviour {

	public static Player player = new Player();
	public GameObject startObject;
	public SaveLoad saveLoad;
	public VignetteAndChromaticAberration vigAndChrom;
	public BlurOptimized blurOpt;

	void Awake()
	{
		if(startObject != null)
		{
			player.setPosition(startObject.transform.position);
			player.setRotation(startObject.transform.rotation);
		}
		if(player.getName() != "unnamed")
			saveLoad.Load();
	}

	void Update()
	{
		player.setPosition(transform.position);
	}

	public void displayDamage()
	{

		if(player.getHealth() > 1)
		{
			float ratioEquator = 1 / (player.getHealth() / 15f);

			if(player.getHealth() < 100 * 2/3)
			{
				blurOpt.blurIterations = 2;
				blurOpt.downsample = 1;
				vigAndChrom.intensity = Mathf.Lerp(vigAndChrom.intensity, 1.75f, Time.deltaTime);
				blurOpt.blurSize = ratioEquator;
			}
			else if(player.getHealth() < 100 * 1/3)
			{
				blurOpt.blurIterations = 3;
				blurOpt.downsample = 2;
				vigAndChrom.intensity = Mathf.Lerp(vigAndChrom.intensity, 3.5f, Time.deltaTime);
				blurOpt.blurSize = ratioEquator;
			}
			else
			{
				blurOpt.blurIterations = 1;
				blurOpt.downsample = 0;
				vigAndChrom.intensity = Mathf.Lerp(vigAndChrom.intensity, 0.0f, Time.deltaTime);
				blurOpt.blurSize = Mathf.Lerp(blurOpt.blurSize, 0, Time.deltaTime);
			}

		}

	}

}
