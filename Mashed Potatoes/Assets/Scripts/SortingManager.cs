using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using Valve.VR;

public class SortingManager : MonoBehaviour
{
    public static SortingManager Instance;
    public GameObject uraniumOutput;
    public GameObject radiumOutput;
    public GameObject plutoniumOutput;
    public GameObject thisObject;

    public GameObject startingText;
    public GameObject upgrade2Text;
    public GameObject upgrade3Text;

    public GameObject sortingMachine1;
    public GameObject sortingMachine2;
    public GameObject sortingMachine3;

    private int uraniumCount = 0;
    private int radiumCount = 0;
    private int plutoniumCount = 0;
    private int randomOutput = 0;

    private bool uraniumSet = false;
    private bool radiumSet = false;
    private bool plutoniumSet = false;

    private bool sorter1 = false;
    private bool sorter2 = false;
    private bool sorter3 = false;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sorter1 == false)
        {
            sorter1 = true;
            GameObject textClone = Instantiate(startingText, transform.position, transform.rotation);
            textClone.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
            Destroy(textClone, 20);

        }
        else if (sorter2 == false)
        {
            if (Money.Instance.moneyAmount >= 750)
            {
                sorter2 = true;
                Money.Instance.RemoveMoney(750);
                Destroy(sortingMachine1);
                sortingMachine2.gameObject.SetActive(true);
                GameObject textClone = Instantiate(upgrade2Text, transform.position, transform.rotation);
                textClone.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
                Destroy(textClone, 20);
            }
        }
        else if (sorter3 == false)
        {
            if (Money.Instance.moneyAmount >= 1500)
            {
                sorter3 = true;
                Money.Instance.RemoveMoney(1500);
                Destroy(sortingMachine2.gameObject);
                Instantiate(sortingMachine3, new Vector3(-0.23f, -0.0028512f, 4.45f), transform.rotation);
                GameObject textClone = Instantiate(upgrade3Text, transform.position, transform.rotation);
                textClone.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
                Destroy(textClone, 20);
            }
        }
        if (sorter1 == true && sorter2 == false)
        {
            sortingUpgrade1();
        }
        else if (sorter2 == true && sorter3 == false)
        {
            sortingUpgrade2();
        }    
        else if (sorter3 == true)
        {
            sortingUpgrade3();
        }

        randomOutput = Random.Range(1, 4);

    }

    public void countUranium()
    {
        uraniumCount += 1;
        uraniumSet = true;
    }
    public void countRadium()
    {
        radiumCount += 1;
        radiumSet = true;
    }
    public void countPlutonium()
    {
        plutoniumCount += 1;
        plutoniumSet = true;
    }
    public void sortingUpgrade1()
    {
        //Upgrade 1 (3 Input - 1 Output)
        if (uraniumSet == true && radiumSet == true && plutoniumSet == true)
        {
            for (var i = thisObject.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(thisObject.transform.GetChild(i).gameObject);
            }

            if (randomOutput == 1)
            {
                Instantiate(uraniumOutput, new Vector3(-0.249f, 0.512f, 8.56f), transform.rotation);
            }
            else if (randomOutput == 2)
            {
                Instantiate(radiumOutput, new Vector3(-0.249f, 0.512f, 8.56f), transform.rotation);
            }
            else if (randomOutput == 3)
            {
                Instantiate(plutoniumOutput, new Vector3(-0.249f, 0.512f, 8.56f), transform.rotation);
            }

            Money.Instance.AddMoney(50);
            uraniumSet = false;
            radiumSet = false;
            plutoniumSet = false;
        }
    }
    public void sortingUpgrade2()
    {
        //Upgrade 2 (1 Input - 1 Output)
        if (uraniumSet == true)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            Instantiate(uraniumOutput, new Vector3(1.422f, 0.562f, 7.873f), transform.rotation);
            uraniumSet = false;
            Money.Instance.AddMoney(50);
        }
        else if (radiumSet == true)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            Instantiate(radiumOutput, new Vector3(-0.274f, 0.562f, 7.873f), transform.rotation);
            radiumSet = false;
            Money.Instance.AddMoney(50);
        }
        else if (plutoniumSet == true)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            Instantiate(plutoniumOutput, new Vector3(-1.994f, 0.562f, 7.873f), transform.rotation);
            plutoniumSet = false;
            Money.Instance.AddMoney(50);
        }
    }

    public void sortingUpgrade3()
    {
        //Upgrade 3 (1 Input - 3 Outputs)
        if (uraniumSet == true || radiumSet == true || plutoniumSet)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            Instantiate(uraniumOutput, new Vector3(1.422f, 0.562f, 7.873f), transform.rotation);
            Instantiate(radiumOutput, new Vector3(-0.217f, 0.562f, 7.873f), transform.rotation);
            Instantiate(plutoniumOutput, new Vector3(-1.841f, 0.562f, 7.873f), transform.rotation);
            uraniumSet = false;
            radiumSet = false;
            plutoniumSet = false;
            Money.Instance.AddMoney(50);
        }
    }
}
