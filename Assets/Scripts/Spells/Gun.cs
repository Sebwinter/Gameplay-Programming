using System.Collections;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class Gun : MonoBehaviour
{
    public RangedSpell SpellStats;
    public PlayerStats stats;
    public GameObject spell;

    public PlayerController player;
    public Transform SpellPoint;

    public Transform MyTarget { get; protected set; }

    [SerializeField]
    protected LayerMask layerMask;

    public Camera PlayerCam;

    private float nextFireFireBall;
    private float nextFireLightningBolt;
    private float nextFireIceSpike;
    private float nextFireGrassTrap;
    private float nextFireHeals;
    public float range;
    
    public RaycastHit hit;
    Ray ray;

    public void Start()
    {
        SpellStats = GetComponent<RangedSpell>();
        stats = GetComponent<PlayerStats>();
        hit = new RaycastHit();
        ray = PlayerCam.ScreenPointToRay(Input.mousePosition);
        
    }

    // Update is called once per frame
    void Update()
    {
        FireBall();
        LightningBolt();
        IceSpike();
        GrassTrap();
        Heals();
    }

    public void FireBall()
    {
        if (Input.GetButtonDown("Spell1") && Time.time > nextFireFireBall)
        {
            nextFireFireBall = Time.time + SpellStats.PlayerSpells[0].SpellFireRate;

            Vector3 rayOrigin = PlayerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));


            if (Physics.Raycast(rayOrigin, PlayerCam.transform.forward, out hit, SpellStats.PlayerSpells[0].SpellRange))
            {

                if (hit.collider != null)
                {
                    MyTarget = hit.transform;

                }

                Spell0();
            }
            else
            {

                MissSpell0();

            }
        }

    }

    public void LightningBolt()
    {
        if (Input.GetButtonDown("Spell2") && Time.time > nextFireLightningBolt)
        {
            nextFireLightningBolt = Time.time + SpellStats.PlayerSpells[1].SpellFireRate;

            Vector3 rayOrigin = PlayerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));


            if (Physics.Raycast(rayOrigin, PlayerCam.transform.forward, out hit, SpellStats.PlayerSpells[1].SpellRange))
            {

                if (hit.collider != null)
                {
                    MyTarget = hit.transform;

                }

                Spell1();

            }
            else
            {

                MissSpell1();

            }
        }
    }

    public void IceSpike()
    {
        if (Input.GetButtonDown("Spell3") && Time.time > nextFireIceSpike)
        {
            nextFireIceSpike = Time.time + SpellStats.PlayerSpells[2].SpellFireRate;

            Vector3 rayOrigin = PlayerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));


            if (Physics.Raycast(rayOrigin, PlayerCam.transform.forward, out hit, SpellStats.PlayerSpells[2].SpellRange))
            {

                if (hit.collider != null)
                {
                    MyTarget = hit.transform;

                }

                Spell2();

            }
            else
            {

                MissSpell2();

            }
        }

    }

    public void GrassTrap()
    {
        if (Input.GetButtonDown("Spell4") && Time.time > nextFireGrassTrap)
        {
            nextFireGrassTrap = Time.time + SpellStats.PlayerSpells[3].SpellFireRate;

            Vector3 rayOrigin = PlayerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));


            if (Physics.Raycast(rayOrigin, PlayerCam.transform.forward, out hit, SpellStats.PlayerSpells[3].SpellRange))
            {

                if (hit.collider != null)
                {
                    MyTarget = hit.transform;

                }

                Spell3();

            }
            else
            {
                
                MissSpell3();

            }
        }

    }

    private void Heals()
    {
        if (Input.GetButtonDown("Spell5") && Time.time > nextFireHeals)
        {
            nextFireHeals = Time.time + SpellStats.PlayerSpells[4].SpellFireRate; 

            Spell4(); // Used to activate the particle affect which is a prefab.

            PlayerStats health = GetComponent<PlayerStats>();
            int spellDamage = stats.spellDamage.GetValue();
            
            if (health != null)
            {
                            
                health.Heal(spellDamage);  
                 
            }

        }

    }

    //FireBall
    public void Spell0()
    {
        Vector3 myTarget = MyTarget.transform.position;
        Vector3 playerP = SpellPoint.transform.position;
        GameObject spell = Instantiate(SpellStats.PlayerSpells[0].SpellPrefab, playerP, Quaternion.LookRotation(ray.direction)) as GameObject;

        spell.GetComponent<Rigidbody>().velocity = (myTarget - transform.position).normalized * SpellStats.PlayerSpells[0].SpellSpeed;

        Debug.Log("Fire Ball fired");
        Destroy(spell, SpellStats.PlayerSpells[0].SpellLiveTime);

    }

    //Lightning bolt
    public void Spell1()
    {
        Vector3 myTarget = MyTarget.transform.position;
        Vector3 playerP = SpellPoint.transform.position;
        GameObject spell = Instantiate(SpellStats.PlayerSpells[1].SpellPrefab, playerP, Quaternion.LookRotation(ray.direction)) as GameObject;

        spell.GetComponent<Rigidbody>().velocity = (myTarget - transform.position).normalized * SpellStats.PlayerSpells[1].SpellSpeed;

        Debug.Log("Chain lightning fired");
        Destroy(spell, SpellStats.PlayerSpells[1].SpellLiveTime);

    }

    //IceSpike
    public void Spell2()
    {
        Vector3 myTarget = MyTarget.transform.position;
        Vector3 playerP = SpellPoint.transform.position;
        GameObject spell = Instantiate(SpellStats.PlayerSpells[2].SpellPrefab, playerP, Quaternion.LookRotation(ray.direction)) as GameObject;

        spell.GetComponent<Rigidbody>().velocity = (myTarget - transform.position).normalized * SpellStats.PlayerSpells[2].SpellSpeed;

        Debug.Log("IceSpikes fired");
        Destroy(spell, SpellStats.PlayerSpells[2].SpellLiveTime);

    }

    //GrassTrap
    public void Spell3()
    {
        Vector3 myTarget = MyTarget.transform.position;
        Vector3 playerP = SpellPoint.transform.position;
        GameObject spell = Instantiate(SpellStats.PlayerSpells[3].SpellPrefab, playerP, Quaternion.LookRotation(ray.direction)) as GameObject;

        spell.GetComponent<Rigidbody>().velocity = (myTarget - transform.position).normalized * SpellStats.PlayerSpells[3].SpellSpeed;

        Debug.Log("Grass Trap launched");
        Destroy(spell, SpellStats.PlayerSpells[3].SpellLiveTime);

    }

    //Heal
    public void Spell4()
    {
        //Vector3 myTarget = MyTarget.transform.position;
        Vector3 playerP = SpellPoint.transform.position;
        GameObject spell = Instantiate(SpellStats.PlayerSpells[4].SpellPrefab, playerP, Quaternion.LookRotation(ray.direction)) as GameObject;


        Debug.Log("Heal used");
        Destroy(spell, SpellStats.PlayerSpells[4].SpellLiveTime);

    }

    //Missed FireBall
    public void MissSpell0()
    {
        Vector3 playerP = SpellPoint.transform.position;
        GameObject spell = Instantiate(SpellStats.PlayerSpells[0].SpellPrefab, playerP, Quaternion.LookRotation(ray.direction)) as GameObject;

        spell.GetComponent<Rigidbody>().velocity = (transform.forward * SpellStats.PlayerSpells[0].SpellSpeed);
        Debug.Log("missed spell");
        Destroy(spell, SpellStats.PlayerSpells[0].SpellLiveTime);

    }

    //Missed LightningBolt
    public void MissSpell1()
    {
        Vector3 playerP = SpellPoint.transform.position;
        GameObject spell = Instantiate(SpellStats.PlayerSpells[1].SpellPrefab, playerP, Quaternion.LookRotation(ray.direction)) as GameObject;

        spell.GetComponent<Rigidbody>().velocity = (transform.forward * SpellStats.PlayerSpells[1].SpellSpeed);
        Debug.Log("missed spell");
        Destroy(spell, SpellStats.PlayerSpells[1].SpellLiveTime);

    }

    //Missed IceSpike
    public void MissSpell2()
    {
        Vector3 playerP = SpellPoint.transform.position;
        GameObject spell = Instantiate(SpellStats.PlayerSpells[2].SpellPrefab, playerP, Quaternion.LookRotation(ray.direction)) as GameObject;

        spell.GetComponent<Rigidbody>().velocity = (transform.forward * SpellStats.PlayerSpells[2].SpellSpeed);
        Debug.Log("missed spell");
        Destroy(spell, SpellStats.PlayerSpells[2].SpellLiveTime);

    }

    //Missed GrassTrap
    public void MissSpell3()
    {
        Vector3 playerP = SpellPoint.transform.position;
        GameObject spell = Instantiate(SpellStats.PlayerSpells[3].SpellPrefab, playerP, Quaternion.LookRotation(ray.direction)) as GameObject;

        spell.GetComponent<Rigidbody>().velocity = (transform.forward * SpellStats.PlayerSpells[3].SpellSpeed);
        Debug.Log("missed spell");
        Destroy(spell, SpellStats.PlayerSpells[3].SpellLiveTime);

    }

}  
