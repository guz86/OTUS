namespace Lessons.Architecture.Mechanics
{
    public class Movement
    {
        
    /*
    movement

    - Transform SetPosition
        
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime;
        
        // transform.position = target.position;
    }

    - Transform Translate
    
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    - Rigidbody AddForce  add freezerotation XYZ
    
    private Rigidbody _rb;
    private float _forceMult; 
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rb.AddForce(transform.forward * (_forceMult * Time.fixedDeltaTime));
    }
    
    - Rigidbody MovePosition
    
    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 newPosition = transform.position + (transform.forward * Time.fixedDeltaTime);
        _rb.MovePosition(newPosition);
    }
    

    - Rigidbody SetVelocity
    
    private Rigidbody _rb;
    private float _forceMult; 
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rb.velocity = transform.forward * (_forceMult * Time.fixedDeltaTime);
    }
    
    - MoveTowards постоянная скорость
    
    private float _speed; 
    private void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }
    
    - Lerp замедление от и до - _dampingFactor is basically a percentage value.  (0.1 = 10%, 0.5 = 50%, 1 = 100%.)
    
    private float _dampingFactor; 
    private void Update()
    {
       transform.position = Vector3.Lerp(transform.position, target.position, _dampingFactor * Time.deltaTime);
    }
    
    - Lerp and MoveToward
    
    private float _dampingFactor; 
    private void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, 
                                               Vector3.Lerp(transform.position, 
                                               target.position, 
                                               _dampingFactor * Time.deltaTime),
                                                _dampingFactor * Time.deltaTime);
    }
    
    - SmoothDamp -  нечто среднее между MoveToward и Lerp
    
    private float _speed; 
    private Vector3 velocity = Vector3.zero; 
    private void Update()
    {
       transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, _dampingFactor * Time.deltaTime);
    }
    
    - Rigidbody to target
    
    private Rigidbody _rb;
    private float _forceMult; 
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Vector3 direction = (transform.position - target.position).normalize;
    }
    private void FixedUpdate()
    {
        _rb.AddForce(direction * (_forceMult * Time.fixedDeltaTime));
    }
    
    - Character Controller
    

    movement */
    }
}