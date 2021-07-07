using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Controller : MonoBehaviour
{

    private SceneLoad sceneLoad;
    public SimpleObjectPool optionButtonObjectPool;
    public Transform optionButtonParent;
    public GameObject panel;

    public string[] scene;
    private int sceneControl = 0;

    private DataController dataController;
    private RoundData currentRound;
    private PhaseData[] currentPhasePool;

    private int phaseIndex = 0;
    private bool activeRound;
    
    private int currentPhaseNumber = 0;

    private List<GameObject> optionsButtonsGameObjects = new List<GameObject>();


    static Controller ImTheOne;


    // Start is called before the first frame update
    void Start()
    {

        
        if(ImTheOne != null)
        {
            ImTheOne.panel.SetActive(true);
            ImTheOne.ShowOptions();
            Destroy(this.gameObject);
            return;
        }


        Debug.Log("ENTROU Start");

        sceneLoad = new SceneLoad();
       

        dataController = FindObjectOfType<DataController>();
        currentRound = dataController.GetCurrentRoundData();
        currentPhasePool = currentRound.phases; 
        ImTheOne = this;
        
        GameObject.DontDestroyOnLoad(gameObject);

        ShowOptions();
        

      
        
        //activeRound = True

    }

    // Update is called once per frame
    void Update()
    {

        if (optionButtonObjectPool == null)
        {

            optionButtonObjectPool = FindObjectOfType<SimpleObjectPool>();

        }

    }

    private void ShowOptions()
    {

        RemoveOptionsButtons();

        
        if(optionButtonObjectPool == null)
        {
            optionButtonObjectPool = FindObjectOfType<SimpleObjectPool>();
        }
        PhaseData phasedata = currentPhasePool[currentPhaseNumber];
        
        for (int i = 0; i < phasedata.options.Length; i++)
        {
            

            GameObject optionButtonObject = optionButtonObjectPool.GetObject();

            optionButtonObject.transform.SetParent(optionButtonParent);

            optionsButtonsGameObjects.Add(optionButtonObject);

            OptionsButtons optionbutton = optionButtonObject.GetComponent<OptionsButtons>();
            optionbutton.Setup(phasedata.options[i]);

        }
    }

    private void RemoveOptionsButtons()
    {
        while (optionsButtonsGameObjects.Count > 0)
        {
            Debug.Log(optionButtonObjectPool);
            optionButtonObjectPool.ReturnObject(optionsButtonsGameObjects[0]);
            optionsButtonsGameObjects.RemoveAt(0);
        }
    }


    public void OptionClicked(bool rightOption)
    {
        panel.SetActive(false);
        if(rightOption){
            currentPhaseNumber++;
        }
        if(currentPhaseNumber >= currentPhasePool.Length){
            currentPhaseNumber = 0;
            RemoveOptionsButtons();
            sceneLoad.LoadScene("SampleScene");
        }else{
            
            sceneLoad.LoadScene(scene[sceneControl]);
            sceneControl++;
            ShowOptions();
        }
        if(sceneControl == 4)
        {
            sceneControl = 0;
        }
        
        
    }
}
