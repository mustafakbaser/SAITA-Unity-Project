using UnityEngine;
using Random = UnityEngine.Random;

public class Fighter : MonoBehaviour {

    //Bu kısım PlayerType

    public enum PlayerType {
        HUMAN, AI
    };

    //Buraya kadar (PlayerType)

    public static float MAX_HEALTH = 100f;
    public float health = MAX_HEALTH;
    public string fighterName;
    public Fighter opponent;

    public PlayerType player;
    public FighterStates currentState = FighterStates.IDLE;


    protected Animator animator;
    private Rigidbody myBody;

    //for ai only
    private float random;
    private float randomSetTime;

    void Start() {
        if (CharacterSelection.data == 0)
        {
            opponent = GameObject.Find("Ryu").GetComponent<Fighter>();
        }
        if (CharacterSelection.data == 1)
        {
            opponent = GameObject.Find("Ken").GetComponent<Fighter>();
        }

        myBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void UpdateHumanInput() {
        if (Input.GetAxis("Horizontal") > 0.1) {
            animator.SetBool("WALK", true);
        }
        else {
            animator.SetBool("WALK", false);
        }

        if (Input.GetAxis("Horizontal") < -0.1)
        {
            if (opponent.attacking){
                animator.SetBool("WALK_BACK", false);
                animator.SetBool("DEFEND", true);
            }else{
                animator.SetBool("WALK_BACK", true);
                animator.SetBool("DEFEND", false);
            }
        }else{
            animator.SetBool("WALK_BACK", false);
            animator.SetBool("DEFEND", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            animator.SetTrigger("JUMP");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("PUNCH");
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            animator.SetTrigger("KICK");
        }

        //Sonradan eklendi

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0f, 0f, 0.12f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0f, 0f, -0.12f);
        }
    }

    public void UpdateAiInput() {
        animator.SetBool("opponent_attacking", opponent.attacking);
        animator.SetBool("defending", defending);
        animator.SetBool("invulnerable", invulnerable);
        animator.SetBool("enabled", enabled);
        animator.SetFloat("distance", getDistance());


        if (Time.time - randomSetTime > 1) {
            random = Random.value;
            randomSetTime = Time.time;
        }

        animator.SetFloat("random", random);
    }

    private float getDistance()    {
        //return Vector3.Distance(transform.position, opponent.transform.position);
        return Mathf.Abs(transform.position.z - opponent.transform.position.z);
    }
    void Update()    {
        animator.SetFloat("health", healthPercent);

        if (opponent != null)
        {
            animator.SetFloat("opponent_health", opponent.healthPercent);
        }
        else
        {
            animator.SetFloat("opponent_health", 1);
        }

        if (enabled)
        {
            if (player == PlayerType.HUMAN)
            {
                UpdateHumanInput();
            }
            else
            {
                UpdateAiInput();
            }
        }

        if (health <= 0 && currentState != FighterStates.DEAD)
        {
            animator.SetTrigger("DEAD");
        }
    }

    public virtual void hurt (float damage) {
        if (!invulnerable){
            if (defending)
            {
                damage *= 0.2f;
            }

            if (health >= damage){
                health -= damage;
            }
            else{
                health = 0;
            }
            if (health > 0) {
                animator.SetTrigger("TAKE_HIT");
            }
        }
    }

    public bool invulnerable {
        get{
            return currentState == FighterStates.TAKE_HIT
                || currentState == FighterStates.TAKE_HIT_DEFEND
                    || currentState == FighterStates.DEAD;
        }
    }
    public bool defending
    {
        get
        {
            return currentState == FighterStates.DEFEND
                  || currentState == FighterStates.TAKE_HIT_DEFEND;
        }
    }

        public bool attacking {
            get {
                return currentState == FighterStates.ATTACK;
            }
         }

    public float healthPercent{
        get{
            return health / MAX_HEALTH;
        }
    }
        public Rigidbody body{
        get{
            return this.myBody;
        }
    }
}