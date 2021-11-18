using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadInAndOutScript : MonoBehaviour
{
    //Transistion colours
    public Color Fad1, Fad2;
    public static Color transitionCol;
    public SpriteRenderer[] remdArray;

    [Space(25)]
    public GameObject TreeOne;
    public Image topBean;
    public Image middleBottomBean;
    public Image rightBottomBeanTwo;
    public Image bottomLeftBeans;
    [Space(25)]
    public GameObject TreeTwo;
    public Image topBeanTTwo;
    public Image middleBottomBeanTTwo;
    public Image rightBottomBeanTwoTTwo;
    public Image bottomLeftBeansTTwo;
    [Space(25)]
    public GameObject TreeThree;
    public Image topBeanTThree;
    public Image middleBottomBeanTThree;
    public Image rightBottomBeanTwoTThree;
    public Image bottomLeftBeansTThree;
    [Space(25)]
    public Button Grow;
    public Button Harvest;
    [Space(25)]
    public Button addWorker;
    public Text WorkerCosts;
    public int workerPrice;
    int harSpeed;
    [Space(25)]
    public Button addTree;
    public Text TreeCost;
    public int treePrice;
    [Space(25)]
    public Button sellBeans;
    public int beanPrice;
    public Text BeansButtonText;
    [Space(25)]
    public Text coffeeBeans;
    public Text money;
    public Text plants;
    public Text gorwthRate;
    public Text Workers;
    public Text incomePerCycle;
    public Text exspensePerCycal;
    [Space(25)]
    public Image coffeeBag;
    public Image CoffeeBagBeans;
    [Space(25)]
    public Button autoHarvest;
    public Button autoSell;
    public Text AutoHarvOnOrOff;
    public Text AutoSellOnOrOff;
    [Space(25)]
    public static int _Beans;
    public static int _Moneys;
    public static int _Plant;
    public static int _AutoSellHarvest;
    [Space(25)]
    public static int _GrowRate;
    public float growthPerClick = 2.0f;
    public int growStart = 0;
    public int growEnd = 40;
    public Slider growthBar;
    public Slider growthBarTTwo;
    public Slider growthBarTThree;
    [Space(25)]
    public static int _Worker;
    public static int _Income;
    public static int _Exspenses;
    [Space(25)]

    public static bool autoHarv;
    public static bool autoSel;
    [Space(25)]
    public Button FireThem;

    







    // Start is called before the first frame update
    void Start()
    {

        TreesOne();
        _Beans = PlayerPrefs.GetInt("Beans", 0) * 0;
        _Moneys = PlayerPrefs.GetInt("Money", 0) * 0;
        _Plant = PlayerPrefs.GetInt("Plants", 0) * 0;
        _GrowRate = PlayerPrefs.GetInt("Growth", 0) * 0;
        _Worker = PlayerPrefs.GetInt("Workers", 0) * 0;
        _Income = PlayerPrefs.GetInt("Income", 0) * 0;
        _Exspenses = PlayerPrefs.GetInt("Costs", 0) * 0;
        _AutoSellHarvest = PlayerPrefs.GetInt("Costs", 0) * 0;

        growStart = growEnd;

        CoffeeBagBeans.gameObject.SetActive(false);

        TreeTwo.gameObject.SetActive(false);
        TreeThree.gameObject.SetActive(false);
        FireThem.gameObject.SetActive(false);
        SellDemBeans();

        _Plant += 1;
        TreePrice();

        //_Moneys += 1000;
        autoHarv = false;
        autoSel = false;
        AutoHarvOnOrOff.text = "On";
        
    }

    public void GrowthButtonPress()
    {
        Debug.Log("Press, frame time: "+Time.deltaTime);
        growthBar.value += 2;
        if (_Plant >= 2)
        {
            growthBarTTwo.value += 2;
            TreesTwo();
        }
        if (_Plant >= 3)
        {
            growthBarTThree.value += 2;
            TreesThree();
        }
        //Tells Tree ones to update 
        TreesOne();
    }
    

    void TreePrice()
    {
        treePrice = _Plant * 100;
        TreeCost.text = treePrice + "";
    }
    void TreesOne()
    {
        //Bean one gorwth
        if (growthBar.value >= 10)
        {
            bottomLeftBeans.gameObject.SetActive(true);

        }
        if (growthBar.value < 10)
        {
            bottomLeftBeans.gameObject.SetActive(false);
        }
        //Bean two Growth
        if (growthBar.value >= 20)
        {
            rightBottomBeanTwo.gameObject.SetActive(true);
        }
        if (growthBar.value < 20)
        {
            rightBottomBeanTwo.gameObject.SetActive(false);
        }
        //Beans three Growth
        if (growthBar.value >= 30)
        {
            middleBottomBean.gameObject.SetActive(true);
        }
        if (growthBar.value < 30)
        {
            middleBottomBean.gameObject.SetActive(false);
        }
        //Beans four growth
        if (growthBar.value >= 40)
        {
            topBean.gameObject.SetActive(true);
            //if harvest button is on and they have money then call harvest
            if (autoHarv == true && _Moneys >= 2)
            {
                HarvestButton();
                AutoHarvest();
            }
        }
        if (growthBar.value < 40)
        {
            topBean.gameObject.SetActive(false);
        }

    }

    void TreesTwo()
    {
        //Bean one gorwth
        if (growthBarTTwo.value >= 10)
        {
            bottomLeftBeansTTwo.gameObject.SetActive(true);

        }
        if (growthBarTTwo.value < 10)
        {
            bottomLeftBeansTTwo.gameObject.SetActive(false);
        }
        //Bean two Growth
        if (growthBarTTwo.value >= 20)
        {
            rightBottomBeanTwoTTwo.gameObject.SetActive(true);
        }
        if (growthBarTTwo.value < 20)
        {
            rightBottomBeanTwoTTwo.gameObject.SetActive(false);
        }
        //Beans three Growth
        if (growthBarTTwo.value >= 30)
        {
            middleBottomBeanTTwo.gameObject.SetActive(true);
        }
        if (growthBarTTwo.value < 30)
        {
            middleBottomBeanTTwo.gameObject.SetActive(false);
        }
        //Beans four growth
        if (growthBarTTwo.value >= 40)
        {
            topBeanTTwo.gameObject.SetActive(true);
        }
        if (growthBarTTwo.value < 40)
        {
            topBeanTTwo.gameObject.SetActive(false);
        }
    }

    void TreesThree()
    {
        //Bean one gorwth
        if (growthBarTThree.value >= 10)
        {
            bottomLeftBeansTThree.gameObject.SetActive(true);

        }
        if (growthBarTThree.value < 10)
        {
            bottomLeftBeansTThree.gameObject.SetActive(false);
        }
        //Bean two Growth
        if (growthBarTThree.value >= 20)
        {
            rightBottomBeanTwoTThree.gameObject.SetActive(true);
        }
        if (growthBarTThree.value < 20)
        {
            rightBottomBeanTwoTThree.gameObject.SetActive(false);
        }
        //Beans three Growth
        if (growthBarTThree.value >= 30)
        {
            middleBottomBeanTThree.gameObject.SetActive(true);
        }
        if (growthBarTThree.value < 30)
        {
            middleBottomBeanTThree.gameObject.SetActive(false);
        }
        //Beans four growth
        if (growthBarTThree.value >= 40)
        {
            topBeanTThree.gameObject.SetActive(true);
        }
        if (growthBarTThree.value < 40)
        {
            topBeanTThree.gameObject.SetActive(false);
        }
    }
    public void HarvestButton()
    {
        //Tree one harvest button slider
        if (growthBar.value >= 10 && growthBar.value < 20)
        {
            growthBar.value -= 10;
            _Beans += 5;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
        }
        if (growthBar.value >= 20 && growthBar.value < 30)
        {
            growthBar.value -= 20;
            _Beans += 10;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
        }
        if (growthBar.value >= 30 && growthBar.value < 40)
        {
            growthBar.value -= 30;
            _Beans += 15;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
        }
        if (growthBar.value >= 40)
        {
            growthBar.value -= 40;
            _Beans += 20;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
            //if Auto sell is on then sell 50 beans for 10 gold and keep 5 beans as tax
            if (autoSel==true && _Beans >= 55)
            {
                _Beans -= 5;
                coffeeBeans.text = _Beans + "";
                SellDemBeans();
            }
        }
        //Tree two harvest button sliver 
        if (growthBarTTwo.value >= 10 && growthBarTTwo.value < 20)
        {
            growthBarTTwo.value -= 10;
            _Beans += 5;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
        }
        if (growthBarTTwo.value >= 20 && growthBarTTwo.value < 30)
        {
            growthBarTTwo.value -= 20;
            _Beans += 10;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
        }
        if (growthBarTTwo.value >= 30 && growthBarTTwo.value < 40)
        {
            growthBarTTwo.value -= 30;
            _Beans += 15;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
        }
        if (growthBarTTwo.value >= 40)
        {
            growthBarTTwo.value -= 40;
            _Beans += 20;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
        }
        //Tree three slider value area thing
        if (growthBarTThree.value >= 10 && growthBarTThree.value < 20)
        {
            growthBarTThree.value -= 10;
            _Beans += 5;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
        }
        if (growthBarTThree.value >= 20 && growthBarTThree.value < 30)
        {
            growthBarTThree.value -= 20;
            _Beans += 10;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
        }
        if (growthBarTThree.value >= 30 && growthBarTThree.value < 40)
        {
            growthBarTThree.value -= 30;
            _Beans += 15;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
        }
        if (growthBarTThree.value >= 40)
        {
            growthBarTThree.value -= 40;
            _Beans += 20;
            PlayerPrefs.SetInt("Beans", _Beans);
            BeanCount();
        }
        //tells trees check to see if you need to update your berry pics
        TreesOne();
        TreesTwo();
        TreesThree();
    }
    public void BeanCount()
    {
        coffeeBeans.text = _Beans + "";
        if (_Beans >= 50)
        {
            CoffeeBagBeans.gameObject.SetActive(true);
        }
        if (_Beans < 50)
        {
            CoffeeBagBeans.gameObject.SetActive(false);
        }
    }
    //add workers as well as conditions for them to be added
    public void AddTreeButton()
    {

        if (_Moneys >= treePrice && _Plant < 3)
        {
            _Plant += 1;
            _Moneys -= treePrice;
            Plants();
            TreePrice();
        }
        if (_Plant >= 3)
        {
            Plants();
            TreePrice();
        }



    }
    void WorkerPrice()
    {
        workerPrice = _Worker * 100;
        WorkerCosts.text = workerPrice + "";
    }
    public void AddWorkerButton()
    {
        if (_Moneys >= workerPrice && _Worker < 3)
        {
            _Worker += 1;
            _Moneys -= workerPrice;
            Worker();
            WorkerPrice();
        }
        if (_Worker >= 3)
        {
            Worker();
            WorkerPrice();
        }
    }
    //invokes repeating growth based on number of workers
    void GrowthRate()
    {
        gorwthRate.text = _Worker * 2 + " Per Second";
    }
    void Costs()
    {
        _Exspenses = (_Worker * 6)+_AutoSellHarvest;
        
        exspensePerCycal.text = _Exspenses + "";
    }
    void Income()
    {
        _Income = _Plant * 10;
        incomePerCycle.text = _Income + "";
        
    }
    void Worker()
    {
        
            Workers.text = _Worker + "";
            //harSpeed = _Worker*2;
            InvokeRepeating("GrowthButtonPress", 0.3f * _Worker, 1f);
            //calls Costs to say hey this costs stuff
            InvokeRepeating("Costs", 10f, 10f);
            GrowthRate();
            Costs();
        


    }
    void AutoHarvest()
    {
        _Moneys -= _Plant* 1;
        AutoHarvOnOrOff.text = "Off";
        money.text = _Moneys + "";
    }
    public void AutoHarvestOn()
    {
        if (_Moneys >= 2)
        {

            autoHarv = !autoHarv;
            if (autoHarv)
            {
                autoHarv = true;
                _AutoSellHarvest += _Plant *3;
            }
            else
            {
                if (autoHarv == true)
                {
                    autoHarv = false;
                    AutoHarvOnOrOff.text = "On";
                    _AutoSellHarvest -= _Plant * 3;
                }

            }
        }

    }
    public void FireWorker()
    {
        if (_Worker >= 1 && _Moneys >= 200)
        {
            _Worker -= 1;
            _Moneys -= 200;
            Costs();
        }
    }
    public void AutoSellBeanOn()
    {
        

            autoSel = !autoSel;
            if (autoSel)
            {
                autoSel = true;
                AutoSellOnOrOff.text = "off";
            }
            else
            {
                if (autoSel == true)
                {
                    autoSel = false;
                    AutoSellOnOrOff.text = "On";

                }

            }
        
    }
    //number of plants and the change of costs calls void trees two and three if it meets the number
    public void Plants()
    {
        
        
        if (_Plant >= 2)
        {
            TreeTwo.gameObject.SetActive(true);
            TreesTwo();

        }
        if (_Plant >= 3)
        {
            TreeThree.gameObject.SetActive(true);
            TreesThree();
        }
    }
    //Selling beans and the amount they go for 
    public void SellDemBeans()
    {
        
        beanPrice = 10;
        BeansButtonText.text = "Sell 50 beans for " + beanPrice + " Gold" ;
        money.text = _Moneys + "";
        if (_Beans >= 50 )
        {
            _Beans -= 50;
            _Moneys += beanPrice;
            money.text = _Moneys + "";
            BeanCount();
        }
        


    }
    // Update is called once per frame
    //calling trees to make sure its all G
    //calling Plants to make sure its all G
    void Update()
    {
        Costs();
        Income();
        treePrice = _Plant * 100;
        
        if (_Worker >= 1)
        {
            FireThem.gameObject.SetActive(true);
        }
        else
        {
            if (_Worker <1)
            {
                FireThem.gameObject.SetActive(false);
            }
        }
        
    }

    
}
