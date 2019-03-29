using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarutaManager : MonoBehaviour
{
    [SerializeField] private List<Karuta> karutas = new List<Karuta>();
    [SerializeField] private Text[] texts;
    [SerializeField] private Text hiraganaText;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject nextButton;

    private int[] ids = new int[4];
    static int id;
    private List<int> readIds = new List<int>();

    private void Start()
    {
        var karutaCSV = Resources.Load("CSV/KarutaSample") as TextAsset;
        var csv = CSVReader.SplitCsvGrid(karutaCSV.text);
        for(int i = 1; i < csv.GetLength(1) - 1; i++)
        { 
            Karuta karuta = new Karuta();
            karuta.SetFromCSV(GetRaw(csv, i));
            karutas.Add(karuta);
        }

        setKaruta();
    }

    private string[] GetRaw(string[,] csv, int row)
    {
        string[] data = new string[csv.GetLength(0)];
        for (int i = 0; i < csv.GetLength(0); i++)
        {
            data[i] = csv[i, row];
        }
        return data;
    }

    private void setKaruta()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            int tmpId = Random.Range(0, karutas.Count);
            ids[i] = tmpId;
            texts[i].text = karutas[ids[i]].text;
            if (i != 0)
            {
                for (int j = 0; j < i; j++)
                {
                    if (tmpId == ids[j])
                    {
                        i--;
                        break;
                    }
                }
            }
        }
        ReadKaruta();
    }

    private void ReadKaruta()
    {
        nextButton.SetActive(false);
        id = Random.Range(0, ids.Length);

        if(readIds.Count != 0)
        {
            for(int i = 0; i < readIds.Count; i++) {
                if(readIds[i] == id)
                {
                    ReadKaruta();
                    return;
                }
            }
        }
        hiraganaText.text = karutas[ids[id]].hiragana;
        readIds.Add(id);
    }

    public void tapNextButton()
    {
        ReadKaruta();
    }

    public void tapButton1()
    {
   
        if(id == 0)
        {
            nextButton.SetActive(true);
            buttons[0].SetActive(false);
        }
        else
        {
            print("ng");
        }
    }

    public void tapButton2()
    {
        if (id == 1)
        {
            nextButton.SetActive(true);
            buttons[1].SetActive(false);
        }
        else
        {
            print("ng");
        }
    }

    public void tapButton3()
    {
        if (id == 2)
        {
            nextButton.SetActive(true);
            buttons[2].SetActive(false);
        }
        else
        {
            print("ng");
        }
    }

    public void tapButton4()
    {
        if (id == 3)
        {
            nextButton.SetActive(true);
            buttons[3].SetActive(false);
        }
        else
        {
            print("ng");
        }
    }
}
