using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject winCanvas;
    public Button[] line;
    public Button[] box1;
    public Button[] box2;
    public Button[] box3;
    public Button[] box4;
    public Button[] box5;
    public Button[] box6;
    public Button[] box7;
    public Button[] box8;
    public Button[] box9;
    int selectedNum = 1;
    private void Start()
    {
        foreach (var btn in line)
        {
            btn.onClick.AddListener(() => onLineBtnClick(btn));
        }
        addListnerToAllGameButtons(box1, box2, box3, box4, box5, box6, box7, box8, box9);
    }
    void onLineBtnClick(Button btn)
    {
        foreach (var button in line)
        {
            button.interactable = true;
        }
        btn.interactable = false;
        selectedNum = int.Parse(btn.gameObject.name);
        Debug.Log(selectedNum);
    }
    void onGameBtnClick(Button btn)
    {
        btn.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = selectedNum.ToString();
        CheckWinning();
    }
    void addListnerToAllGameButtons(params Button[][] btns)
    {
        foreach (var box in btns)
        {
            foreach (var btn in box)
            {
                btn.onClick.AddListener(() => onGameBtnClick(btn));
            }
        }
    }
    void CheckWinning()
    {
        if (!CheckAllBoxes())
        {
            Debug.Log("Failed: One of the boxes has incorrect numbers.");
            return;
        }

        if (!CheckAllRows())
        {
            Debug.Log("Failed: One of the rows has incorrect numbers.");
            return;
        }

        if (!CheckAllColumns())
        {
            Debug.Log("Failed: One of the columns has incorrect numbers.");
            return;
        }

        Debug.Log("win");
        winCanvas.SetActive(true);
    }

    bool CheckAllBoxes()
    {
        int winPoints = 45;
        return
            SumBox(box1) == winPoints &&
            SumBox(box2) == winPoints &&
            SumBox(box3) == winPoints &&
            SumBox(box4) == winPoints &&
            SumBox(box5) == winPoints &&
            SumBox(box6) == winPoints &&
            SumBox(box7) == winPoints &&
            SumBox(box8) == winPoints &&
            SumBox(box9) == winPoints;
    }

    bool CheckAllRows()
    {
        int winPoints = 45;
        return
            IntBtn(box1[0]) + IntBtn(box1[1]) + IntBtn(box1[2]) + IntBtn(box2[0]) + IntBtn(box2[1]) + IntBtn(box2[2]) + IntBtn(box3[0]) + IntBtn(box3[1]) + IntBtn(box3[2]) == winPoints &&
            IntBtn(box1[3]) + IntBtn(box1[4]) + IntBtn(box1[5]) + IntBtn(box2[3]) + IntBtn(box2[4]) + IntBtn(box2[5]) + IntBtn(box3[3]) + IntBtn(box3[4]) + IntBtn(box3[5]) == winPoints &&
            IntBtn(box1[6]) + IntBtn(box1[7]) + IntBtn(box1[8]) + IntBtn(box2[6]) + IntBtn(box2[7]) + IntBtn(box2[8]) + IntBtn(box3[6]) + IntBtn(box3[7]) + IntBtn(box3[8]) == winPoints &&
            IntBtn(box4[0]) + IntBtn(box4[1]) + IntBtn(box4[2]) + IntBtn(box5[0]) + IntBtn(box5[1]) + IntBtn(box5[2]) + IntBtn(box6[0]) + IntBtn(box6[1]) + IntBtn(box6[2]) == winPoints &&
            IntBtn(box4[3]) + IntBtn(box4[4]) + IntBtn(box4[5]) + IntBtn(box5[3]) + IntBtn(box5[4]) + IntBtn(box5[5]) + IntBtn(box6[3]) + IntBtn(box6[4]) + IntBtn(box6[5]) == winPoints &&
            IntBtn(box4[6]) + IntBtn(box4[7]) + IntBtn(box4[8]) + IntBtn(box5[6]) + IntBtn(box5[7]) + IntBtn(box5[8]) + IntBtn(box6[6]) + IntBtn(box6[7]) + IntBtn(box6[8]) == winPoints &&
            IntBtn(box7[0]) + IntBtn(box7[1]) + IntBtn(box7[2]) + IntBtn(box8[0]) + IntBtn(box8[1]) + IntBtn(box8[2]) + IntBtn(box9[0]) + IntBtn(box9[1]) + IntBtn(box9[2]) == winPoints &&
            IntBtn(box7[3]) + IntBtn(box7[4]) + IntBtn(box7[5]) + IntBtn(box8[3]) + IntBtn(box8[4]) + IntBtn(box8[5]) + IntBtn(box9[3]) + IntBtn(box9[4]) + IntBtn(box9[5]) == winPoints &&
            IntBtn(box7[6]) + IntBtn(box7[7]) + IntBtn(box7[8]) + IntBtn(box8[6]) + IntBtn(box8[7]) + IntBtn(box8[8]) + IntBtn(box9[6]) + IntBtn(box9[7]) + IntBtn(box9[8]) == winPoints;
    }

    bool CheckAllColumns()
    {
        int winPoints = 45;
        return
            IntBtn(box1[0]) + IntBtn(box1[3]) + IntBtn(box1[6]) + IntBtn(box4[0]) + IntBtn(box4[3]) + IntBtn(box4[6]) + IntBtn(box7[0]) + IntBtn(box7[3]) + IntBtn(box7[6]) == winPoints &&
            IntBtn(box1[1]) + IntBtn(box1[4]) + IntBtn(box1[7]) + IntBtn(box4[1]) + IntBtn(box4[4]) + IntBtn(box4[7]) + IntBtn(box7[1]) + IntBtn(box7[4]) + IntBtn(box7[7]) == winPoints &&
            IntBtn(box1[2]) + IntBtn(box1[5]) + IntBtn(box1[8]) + IntBtn(box4[2]) + IntBtn(box4[5]) + IntBtn(box4[8]) + IntBtn(box7[2]) + IntBtn(box7[5]) + IntBtn(box7[8]) == winPoints &&
            IntBtn(box2[0]) + IntBtn(box2[3]) + IntBtn(box2[6]) + IntBtn(box5[0]) + IntBtn(box5[3]) + IntBtn(box5[6]) + IntBtn(box8[0]) + IntBtn(box8[3]) + IntBtn(box8[6]) == winPoints &&
            IntBtn(box2[1]) + IntBtn(box2[4]) + IntBtn(box2[7]) + IntBtn(box5[1]) + IntBtn(box5[4]) + IntBtn(box5[7]) + IntBtn(box8[1]) + IntBtn(box8[4]) + IntBtn(box8[7]) == winPoints &&
            IntBtn(box2[2]) + IntBtn(box2[5]) + IntBtn(box2[8]) + IntBtn(box5[2]) + IntBtn(box5[5]) + IntBtn(box5[8]) + IntBtn(box8[2]) + IntBtn(box8[5]) + IntBtn(box8[8]) == winPoints &&
            IntBtn(box3[0]) + IntBtn(box3[3]) + IntBtn(box3[6]) + IntBtn(box6[0]) + IntBtn(box6[3]) + IntBtn(box6[6]) + IntBtn(box9[0]) + IntBtn(box9[3]) + IntBtn(box9[6]) == winPoints &&
            IntBtn(box3[1]) + IntBtn(box3[4]) + IntBtn(box3[7]) + IntBtn(box6[1]) + IntBtn(box6[4]) + IntBtn(box6[7]) + IntBtn(box9[1]) + IntBtn(box9[4]) + IntBtn(box9[7]) == winPoints &&
            IntBtn(box3[2]) + IntBtn(box3[5]) + IntBtn(box3[8]) + IntBtn(box6[2]) + IntBtn(box6[5]) + IntBtn(box6[8]) + IntBtn(box9[2]) + IntBtn(box9[5]) + IntBtn(box9[8]) == winPoints;
    }

    int SumBox(Button[] box)
    {
        int sum = 0;
        foreach (var btn in box)
        {
            sum += IntBtn(btn);
        }
        return sum;
    }

    int IntBtn(Button btn)
    {
        var txt = btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        if (int.TryParse(txt, out int result))
        {
            return result;
        }
        return 0;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}