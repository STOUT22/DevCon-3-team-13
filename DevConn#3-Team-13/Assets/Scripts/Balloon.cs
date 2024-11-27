using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    // Environmental factors
    public float windSpeed = 5f; // m/s
    public Vector3 windDirection = Vector3.forward; // normalized Vector3
    public float altitude; // meters
    public float airPressure = 101325f; // Pa (sea level pressure)
    public float externalAirTemperature = 288.15f; // Kelvin (15°C at sea level)
    public float temperatureGradient = 0.0065f; // K/m (standard lapse rate)

    // Balloon factors
    public float internalAirTemperature = 373.15f; // Kelvin (100°C starting)
    public float envelopeVolume = 2800f; // m^3 (volume of balloon envelope)
    public float internalAirDensity; // kg/m^3
    public float externalAirDensity; // kg/m^3
    public float buoyancyForce; // Newtons
    public float gravityForce; // Newtons
    public float dragForce; // Newtons

    // Physical properties
    public float burnerHeatOutput = 5000f; // Watts
    public float ventOpening = 0f; // 0-1 (closed-open)
    public float fuelConsumptionRate = 0.1f; // kg/s
    public float heatLossRate = 50f; // Watts
    public float dragCoefficient = 0.5f; // Typical drag coefficient
    public float crossSectionalArea = 20f; // m^2

    // References
    public Rigidbody balloonRigidbody;
    public float fuelRemaining = 100f; // kg of fuel

    private const float gasConstant = 287.05f; // J/(kg·K)
    private const float gravity = 9.81f; // m/s²

    void Start()
    {
        if (!balloonRigidbody)
        {
            balloonRigidbody = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        // Update altitude and environmental factors
        altitude = transform.position.y;
        externalAirTemperature = Mathf.Max(223.15f, 288.15f - temperatureGradient * altitude); // Min temperature = -50°C
        externalAirDensity = airPressure / (gasConstant * externalAirTemperature);

        // Control inputs
        HandleBurner();
        HandleVent();
    }

    void FixedUpdate()
    {
        // Calculate internal air density
        internalAirDensity = airPressure / (gasConstant * internalAirTemperature);

        // Calculate forces
        CalculateBuoyancyForce();
        CalculateGravityForce();
        CalculateDragForce();

        // Apply forces
        ApplyForces();
    }

    private void HandleBurner()
    {
        if (Input.GetKey(KeyCode.Space) && fuelRemaining > 0f)
        {
            // Adjust heating power
            float heatAdded = burnerHeatOutput * Time.deltaTime;
            internalAirTemperature += heatAdded / (envelopeVolume * gasConstant);

            fuelRemaining -= fuelConsumptionRate * Time.deltaTime;

            // Debug the temperature increase
            Debug.Log($"Burner Active: Internal Temp = {internalAirTemperature}, Fuel Remaining = {fuelRemaining}");
        }
    }


    private void HandleVent()
    {
        if (Input.GetKey(KeyCode.V))
        {
            ventOpening = Mathf.Clamp01(ventOpening + Time.deltaTime); // Increase vent opening
        }
        else
        {
            ventOpening = Mathf.Clamp01(ventOpening - Time.deltaTime); // Decrease vent opening
        }

        // Apply heat loss when venting
        internalAirTemperature -= (ventOpening * heatLossRate + Time.deltaTime) / envelopeVolume;

        // Ensure internal air temperature does not fall below external air temperature
        internalAirTemperature = Mathf.Max(internalAirTemperature, externalAirTemperature);
    }



    private void CalculateBuoyancyForce()
    {
        buoyancyForce = (externalAirDensity - internalAirDensity) * envelopeVolume * gravity;

        // Debug forces
        Debug.Log($"Buoyancy Force = {buoyancyForce}, Gravity Force = {gravityForce}, Net = {buoyancyForce - gravityForce}");
    }


    private void CalculateGravityForce()
    {
        gravityForce = balloonRigidbody.mass * gravity;
    }

    private void CalculateDragForce()
    {
        dragForce = 0.5f * externalAirDensity * windSpeed * windSpeed * dragCoefficient * crossSectionalArea;
    }

    private void ApplyForces()
    {
        // Apply buoyancy force
        balloonRigidbody.AddForce(Vector3.up * (buoyancyForce - gravityForce), ForceMode.Force);

        // Apply wind force
        Vector3 windForce = windDirection.normalized * windSpeed * dragForce;
        balloonRigidbody.AddForce(windForce, ForceMode.Force);
    }
}
