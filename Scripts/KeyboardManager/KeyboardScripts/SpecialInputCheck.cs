using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpecialInputCheck : MonoBehaviour
{

	//This method takes care of all of the odd keys that don't return the KeyCode string
	/*****************************************************************************************************************
	 * 
	 * This class DOES stretch down a very long way, so nothing other than this method
	 * 	will be down there. 
	 * 
	***/
	public static bool checkSpecialInput(Button buttonInput, ChangeHelpMenuText changeText, 
	                                     HoverKeyboard hoverKeyboard)
	{
		
		bool foundKey = false;
		string key = "";
		int index = 0;
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			
			foundKey = true;
			key = "Tab";
			index = 51;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftAlt))
		{
			
			foundKey = true;
			key = "LeftAlt";
			index = 54;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			
			foundKey = true;
			key = "LeftShift";
			index = 49;
			
		}
		else if(Input.GetKeyDown(KeyCode.RightAlt))
		{
			
			foundKey = true;
			key = "RightAlt";
			index = 57;
			
		}
		else if(Input.GetKeyDown(KeyCode.RightShift))
		{
			
			foundKey = true;
			key = "RightShift";
			index = 48;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			
			foundKey = true;
			key = "LeftControl";
			index = 55;
			
		}
		else if(Input.GetKeyDown(KeyCode.Backspace))
		{
			
			foundKey = true;
			key = "Backspace";
			index = 43;
			
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			
			foundKey = true;
			key = "Space";
			index = 56;
			
		}
		else if(Input.GetKeyDown(KeyCode.Escape))
		{
			
			foundKey = true;
			key = "Escape";
			index = 53;
			
		}
		else if(Input.GetKeyDown(KeyCode.CapsLock))
		{
			
			foundKey = true;
			key = "CapsLock";
			index = 50;
			
		}
		else if(Input.GetKeyDown(KeyCode.Semicolon))
		{
			
			foundKey = true;
			key = "Semicolon";
			index = 26;
			
		}
		else if(Input.GetKeyDown(KeyCode.Quote))
		{
			
			foundKey = true;
			key = "Quote";
			index = 27;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftBracket))
		{
			
			foundKey = true;
			key = "LeftBracket";
			index = 28;
			
		}
		else if(Input.GetKeyDown(KeyCode.RightBracket))
		{
			
			foundKey = true;
			key = "RightBracket";
			index = 29;
			
		}
		else if(Input.GetKeyDown(KeyCode.Backslash))
		{
			
			foundKey = true;
			key = "Backslash";
			index = 42;
			
		}
		else if(Input.GetKeyDown(KeyCode.Slash))
		{
			
			foundKey = true;
			key = "Slash";
			index = 47;
			
		}
		else if(Input.GetKeyDown(KeyCode.Period))
		{
			
			foundKey = true;
			key = "Period";
			index = 46;
			
		}
		else if(Input.GetKeyDown(KeyCode.Equals))
		{
			
			foundKey = true;
			key = "Equals";
			index = 41;
			
		}
		else if(Input.GetKeyDown(KeyCode.BackQuote))
		{
			
			foundKey = true;
			key = "BackQuote";
			index = 52;
			
		}
		else if(Input.GetKeyDown(KeyCode.Return))
		{
			
			foundKey = true;
			key = "Return";
			index = 44;
			
		}
		else if(Input.GetKeyDown(KeyCode.Minus))
		{
			
			foundKey = true;
			key = "Minus";
			index = 40;
			
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			
			foundKey = true;
			key = "RightArrow";
			index = 60;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			
			foundKey = true;
			key = "LeftArrow";
			index = 61;
			
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			
			foundKey = true;
			key = "DownArrow";
			index = 59;
			
		}
		else if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			
			foundKey = true;
			key = "UpArrow";
			index = 58;
			
		}
		else if(Input.GetKeyDown(KeyCode.Comma))
		{
			
			
			foundKey = true;
			key = "Comma";
			index = 45;
			
		}
		else if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			
			foundKey = true;
			key = "Alpha1";
			index = 30;
			
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			
			foundKey = true;
			key = "Alpha2";
			index = 31;
			
		}
		else if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			
			foundKey = true;
			key = "Alpha3";
			index = 32;
			
		}
		else if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			
			foundKey = true;
			key = "Alpha4";
			index = 33;
			
		}
		else if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			
			foundKey = true;
			key = "Alpha5";
			index = 34;
			
		}
		else if(Input.GetKeyDown(KeyCode.Alpha6))
		{
			
			foundKey = true;
			key = "Alpha6";
			index = 35;
			
		}
		else if(Input.GetKeyDown(KeyCode.Alpha7))
		{
			
			foundKey = true;
			key = "Alpha7";
			index = 36;
			
		}
		else if(Input.GetKeyDown(KeyCode.Alpha8))
		{
			
			foundKey = true;
			key = "Alpha8";
			index = 37;
			
		}
		else if(Input.GetKeyDown(KeyCode.Alpha9))
		{
			
			foundKey = true;
			key = "Alpha9";
			index = 38;
			
		}
		else if(Input.GetKeyDown(KeyCode.Alpha0))
		{
			
			foundKey = true;
			key = "Alpha0";
			index = 39;
			
		}
		else if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			
			foundKey = true;
			key = "Mouse0";
			index = 62;
			
		}
		else if(Input.GetKeyDown(KeyCode.Mouse1))
		{
			
			foundKey = true;
			key = "Mouse1";
			index = 63;
			
		}
		
		if(foundKey)
		{
			bool contained = false;
			foreach(KeyValuePair<string, Inputs> anInput in Inputs.inputDict)
			{
				
				if(anInput.Value.getInputButton().name.ToLower().Equals(key.ToLower()))
				{
					
					contained = true;
					changeText.changedText("This key has already been binded, please choose another one");
					Debug.Log("This key has already been binded, choose another one.");
					break;
					
				}
				
			}
			if(!contained)
			{
				
				changeText.changedText(key);
				for(int i = 0; i < InputManager.inputManagerList.Count; i++)
				{	
					if(InputManager.inputManagerList[i].Tag.Equals(buttonInput.tag))
					{
						Keyboard.setKeyboardBasedOnTags(AllKeys.allKeys[index], 
						                                buttonInput,
						                                AllKeys.allKeys[index].name,
						                                InputManager.inputManagerList[i].Type, 
						                                AllKeys.allKeys[index].name);
						break;
					}
				}
				InputManager.isOn = false;
				buttonInput.tag = "Untagged";
				hoverKeyboard.keyboardKeyboardExit();
				return true;
				
			}
			else
				return true;
			
		}
		
		return false;
		
	}

}

