using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeyControlsScript : MonoBehaviour
{

    public Transform menuPanel;
    private Event keyEvent;
    private Text buttonText;
    private KeyCode newKey;
    private bool waitingForKey;

    private void Start()

    {
        while (menuPanel == null)
        {
            menuPanel = GameObject.FindGameObjectWithTag("Panel").transform;
        }

        waitingForKey = false;

        for (int i = 0; i < menuPanel.childCount; i++)
        {
            switch (menuPanel.GetChild(i).GetChild(0).name)
            {
                case "UPKey":
                    menuPanel.GetChild(i).GetChild(0).GetComponentInChildren<Text>().text = GameManager.GM.up.ToString();
                    break;
                case "DownKey":
                    menuPanel.GetChild(i).GetChild(0).GetComponentInChildren<Text>().text = GameManager.GM.down.ToString();
                    break;
                case "LeftKey":
                    menuPanel.GetChild(i).GetChild(0).GetComponentInChildren<Text>().text = GameManager.GM.left.ToString();
                    break;
                case "RightKey":
                    menuPanel.GetChild(i).GetChild(0).GetComponentInChildren<Text>().text = GameManager.GM.right.ToString();
                    break;
                case "AttackKey":
                    menuPanel.GetChild(i).GetChild(0).GetComponentInChildren<Text>().text = GameManager.GM.attack.ToString();
                    break;
                case "PauseKey":
                    menuPanel.GetChild(i).GetChild(0).GetComponentInChildren<Text>().text = GameManager.GM.pause.ToString();
                    break;
                default:
                    menuPanel.GetChild(i).GetChild(0).GetComponentInChildren<Text>().text = "No Key Settings";
                    break;
            }

        }

    }

    private void Update()

    {


        if (Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf)
        {
            menuPanel.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
        {
            menuPanel.gameObject.SetActive(false);
        }
    }

    private void OnGUI()

    {
        keyEvent = Event.current;

        if (keyEvent.isKey && waitingForKey)

        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }

    }

    public void StartAssignment(string keyName)

    {
        if (!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }

    public void SendText(Text text)

    {
        buttonText = text;
    }

    private IEnumerator WaitForKey()

    {
        while (!keyEvent.isKey)
        {
            yield return null;
        }
    }

    public IEnumerator AssignKey(string keyName)

    {

        waitingForKey = true;
        yield return WaitForKey();

        switch (keyName)
        {

            case "forward":

                GameManager.GM.up = newKey;

                buttonText.text = GameManager.GM.up.ToString();

                PlayerPrefs.SetString("forwardKey", GameManager.GM.up.ToString());

                break;

            case "backward":

                GameManager.GM.down = newKey;

                buttonText.text = GameManager.GM.down.ToString();

                PlayerPrefs.SetString("backwardKey", GameManager.GM.down.ToString());

                break;

            case "left":

                GameManager.GM.left = newKey;

                buttonText.text = GameManager.GM.left.ToString();

                PlayerPrefs.SetString("leftKey", GameManager.GM.left.ToString());

                break;

            case "right":

                GameManager.GM.right = newKey;

                buttonText.text = GameManager.GM.right.ToString();

                PlayerPrefs.SetString("rightKey", GameManager.GM.right.ToString());

                break;

            case "attack":

                GameManager.GM.attack = newKey;

                buttonText.text = GameManager.GM.attack.ToString();

                PlayerPrefs.SetString("attackKey", GameManager.GM.attack.ToString());

                break;
            case "pause":

                GameManager.GM.pause = newKey;

                buttonText.text = GameManager.GM.pause.ToString();

                PlayerPrefs.SetString("pauseKey", GameManager.GM.pause.ToString());

                break;

        }

        yield return null;

    }
}
