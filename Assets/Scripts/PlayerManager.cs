using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject playerArea;
    public GameObject enemyArea;
    public GameObject playerText;
    public GameObject enemyText;
    public GameObject finiteState;
    public GameObject Card1;
    public GameObject playerHealthNums;
    public GameObject enemyHealthNums;
    public GameObject playerDamageTaken;
    public GameObject enemyDamageTaken;
    public GameObject playerSliceText;
    public GameObject playerStabText;
    public GameObject playerHealText;
    public GameObject enemySliceText;
    public GameObject enemyStabText;
    public GameObject enemyHealText;

    public override void OnStartClient()
    {    
        base.OnStartClient();
        playerArea = GameObject.Find("PlayerArea");
        playerText = GameObject.Find("PlayerText");
        enemyText = GameObject.Find("EnemyText");
        finiteState = GameObject.Find("FiniteStateMachine");
        playerHealthNums = GameObject.Find("PlayerHealthNums");
        enemyHealthNums = GameObject.Find("EnemyHealthNums");
        playerDamageTaken = GameObject.Find("PlayerDamageTaken");
        enemyDamageTaken = GameObject.Find("EnemyDamageTaken");
        playerSliceText = GameObject.Find("PlayerSliceText");
        playerStabText = GameObject.Find("PlayerStabText");
        playerHealText = GameObject.Find("PlayerHealText");
        enemySliceText = GameObject.Find("EnemySliceText");
        enemyStabText = GameObject.Find("EnemyStabText");
        enemyHealText = GameObject.Find("EnemyHealText");
    }
    [Command]
    public void CmdSlice(string text)
    {
        
        RpcSlice(text);
    }
    
    [ClientRpc]
    public void RpcSlice(string text)
    {
        if (hasAuthority)
        {
            playerText.GetComponent<Text>().text = text;
            
        }
        else
        {
            Debug.Log("Called from Player ");

            finiteState.GetComponent<BattleController_FSM>().playerAttack = text;
            enemyText.GetComponent<Text>().text = text;

            finiteState.GetComponent<BattleController_FSM>().playerIsDone = true;

            finiteState.GetComponent<BattleController_FSM>().TransitionToState(
                finiteState.GetComponent<BattleController_FSM>().enemyState);
        }
    }

    [Command]
    public void CmdSliceEnemy(string text, int health)
    {
        
        RpcSliceEnemy(text, health);
    }
    [ClientRpc]
    public void RpcSliceEnemy(string text, int health)
    {
        if (hasAuthority)
        {
            Debug.Log("Called from Enemy ");
            playerText.GetComponent<Text>().text = text;  
        } else
        {
            enemyText.GetComponent<Text>().text = text;
        }
    }
    [Command]
    public void CmdUpdateUI(int playerHealth, int enemyHealth, int playerDamage, int enemyDamage, int playerSliceCount, 
        int playerStabCount, int playerHealCount, int enemySliceCount,
        int enemyStabCount, int enemyHealCount)
    {
        RpcUpdateUI(playerHealth, enemyHealth, playerDamage, enemyDamage, playerSliceCount, playerStabCount, playerHealCount,
            enemySliceCount, enemyStabCount, enemyHealCount);
    }
    [ClientRpc]
    public void RpcUpdateUI(int playerHealth, int enemyHealth, int playerDamage, int enemyDamage, 
        int playerSliceCount, int playerStabCount, int playerHealCount, int enemySliceCount,
        int enemyStabCount, int enemyHealCount)
    {
        if (hasAuthority)
        {
            playerHealthNums.GetComponent<Text>().text = "30 / " + enemyHealth.ToString();
            enemyHealthNums.GetComponent<Text>().text = "30 / " + playerHealth.ToString();

            playerDamageTaken.GetComponent<Text>().text = "Damage Taken: " + enemyDamage;
            enemyDamageTaken.GetComponent<Text>().text = "Damage Taken: " + playerDamage;

            playerSliceText.GetComponent<Text>().text = enemySliceCount.ToString();
            playerStabText.GetComponent<Text>().text = enemyStabCount.ToString();
            playerHealText.GetComponent<Text>().text = enemyHealCount.ToString();

            enemySliceText.GetComponent<Text>().text = playerSliceCount.ToString();
            enemyStabText.GetComponent<Text>().text = playerStabCount.ToString();
            enemyHealText.GetComponent<Text>().text = playerHealCount.ToString();


        }
        else
        {

            playerHealthNums.GetComponent<Text>().text = "30 / " + playerHealth.ToString();
            enemyHealthNums.GetComponent<Text>().text = "30 / " + enemyHealth.ToString();

            playerDamageTaken.GetComponent<Text>().text = "Damage Taken: " + enemyDamage;
            enemyDamageTaken.GetComponent<Text>().text = "Damage Taken: " + playerDamage;

            playerSliceText.GetComponent<Text>().text = playerSliceCount.ToString();
            playerStabText.GetComponent<Text>().text = playerStabCount.ToString();
            playerHealText.GetComponent<Text>().text = playerHealCount.ToString();

            enemySliceText.GetComponent<Text>().text = enemySliceCount.ToString();
            enemyStabText.GetComponent<Text>().text = enemyStabCount.ToString();
            enemyHealText.GetComponent<Text>().text = enemyHealCount.ToString();

        }
    }
}


