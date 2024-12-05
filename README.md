# **Winds of Fury** 
## Team 13 Game Design Document

### November 17, 2024
Logan and Param joined a call at around 5:00 PM to brainstorm ideas for our game. We explored several concepts, including a physics-based human simulator similar to Surgeon Simulator, a free-fall obstacle-dodging game, a racing simulator, and a submarine simulator. Ultimately, we settled on creating a hot air balloon simulator, factoring in elements like wind, gravity, fuel management, and various obstacles.

To organize our thoughts and streamline the planning process, Param set up a Miro board where we could visually lay out our ideas and concepts. This helped us clarify our direction and refine the core mechanics of the game.

**Objective Statement:** The objective of our game is to navigate a hot air balloon through dynamic environments, skillfully managing wind currents, fuel, and obstacles to reach your destination safely.

##### Tasks for week 1
- [x] Create a github repository
- [x] Find assets
- [x] Write pseudocode
- [x] Brainstorm level design

### Game Mechanics
To ensure a realistic and engaging hot air balloon simulation, we need to factor in the following elements:

1. **Gravity**

- Constant downward force requiring players to manage altitude effectively.
- Increased fuel usage when counteracting gravity.
2. **Wind**

- Horizontal forces pushing the balloon in various directions.
- Randomized gusts and directional shifts as difficulty increases.
3. **Pressure and Altitude**

- Lower atmospheric pressure at higher altitudes reduces lift capacity.
- Adjustments in fuel consumption based on altitude changes.
4. **Fuel Management**

- Limited fuel requires strategic use to maintain altitude and direction.
- Opportunities to refuel at checkpoints or during specific scenarios.
5. **Temperature**

- Colder air at higher altitudes or in certain environments affects balloon lift.
- Temperature-based hazards like ice formation.
6. **Obstacles**

- Physical obstacles such as buildings, mountains, or trees.
 - Environmental hazards like birds, storms, and lightning.

 

# Research Breakdown

## Environmental Factors
- **Wind Speed**: Moderate at **5 m/s** (meters per second).
- **Wind Direction**: Along the **Z-axis** (`Vector3.forward`).
- **Air Pressure**: Standard sea-level pressure at **101,325 Pascals**.
- **External Air Temperature**: **288.15 K** (15°C).
- **Temperature Gradient**: Decrease in temperature with altitude at **0.0065 K/m**.

## Balloon Factors
- **Internal Air Temperature**: Starts at **373.15 K** (100°C).
- **Envelope Volume**: **2,800 m³** (typical balloon volume).
- **Internal Air Density**: **Dynamically calculated** using the ideal gas law.
- **External Air Density**: **Dynamically calculated** using the ideal gas law.
- **Buoyancy Force**: **Dynamically calculated**, depends on the air density difference.
- **Gravity Force**: **Dynamically calculated**, depends on the balloon's total mass.
- **Drag Force**: **Dynamically calculated**, influenced by wind speed and external air density.

## Physical Properties
- **Burner Heat Output**: **5,000 W** (Watts).
- **Vent Opening**: Starts **fully closed (0)**; can range from **0 (closed)** to **1 (fully open)**.
- **Fuel Consumption Rate**: **2 kg/s** (burner uses 0.1 kg per second).
- **Heat Loss Rate**: **200 W**, due to venting and natural cooling.
- **Drag Coefficient**: **0.5**, typical for a round object.
- **Cross-Sectional Area**: **20 m²**, represents the balloon's surface facing wind resistance.

## Rigidbody Settings
- **Mass**: **500 kg**, includes basket, balloon fabric, burner, and passengers.
- **Drag**: **0**, managed via custom scripting.
- **Gravity**: **Enabled**.

## Fuel
- **Fuel Remaining**: Starts at **100 kg**, adjustable based on gameplay requirements.

# Sources
https://www.youtube.com/watch?v=iLKG9y20aOA
https://www.real-world-physics-problems.com/hot-air-balloon-physics.html

https://youtu.be/AqhnZz17amw?si=UkBAahx4qrpcZAct

### How Hot Air Balloons Work
Air, when it gets hot, likes to rise. It’s like the air is saying, "I’m too good for the ground!" So, inside the big colorful part of the balloon (that’s called the envelope), there’s a flame blasting heat. That hot air fills the balloon, and because hot air is lighter than cold air, it lifts the whole thing up into the sky. Science magic!

The basket underneath is where people hang out. That’s where the fire comes from too, controlled by something called a burner. Want to go higher? Blast more fire and heat up the air! Want to come down? Let the air cool off a bit. The pilot can control that, like a sky wizard.

#### Process
Logan researched the mechanics of hot air balloons and shared the findings with Param, who translated them into the game code to control the balloon.

We had to adjust the values during testing because the initial setup wasn’t working as intended.

Issues we faced: the balloon ascended too slowly, descended too quickly, and couldn’t be sent back up fast enough to avoid obstacles.

#### November 26, 2024
Logan designed and implemented the start screen

---

### November 27, 2024
Logan designed and implemented the prototype map and created obstacles for the balloon.

---

### November 28, 2024
Ali created the UI for the game scene and developed an alternative code for the hot air balloon mechanics.

---

### December 4, 2024
Param polished the game, ensuring the hot air balloon mechanics ran smoothly and functioned seamlessly.

---

## What We Learned
- **Importance of Iteration:** Testing and tweaking values was crucial for getting the hot air balloon mechanics to work properly. It showed us the value of refining features through trial and error.
- **Collaboration is Key:** By dividing tasks and leveraging each team member’s strengths, we were able to bring different aspects of the game together efficiently.
- **Balancing Gameplay Elements:** We learned how small changes in physics parameters can drastically affect gameplay, emphasizing the need for precision and balance.

---

## Challenges We Overcame
- **Hot Air Balloon Mechanics:** Initially, the balloon ascended too slowly, descended too quickly, and couldn’t rise in time to avoid obstacles. Through collaboration and adjustments, we managed to fine-tune the mechanics for a smoother experience.
- **Integrating Features:** Combining the start screen, UI elements, map design, and hot air balloon controls into a cohesive game required careful coordination and troubleshooting.
- **Coding Complexity:** Ali’s alternative balloon code was a great backup and helped resolve some mechanical issues we encountered during development.

---

## What We Could Do Better Next Time
- **Early Testing:** Starting the testing phase earlier could have helped us identify issues with the hot air balloon mechanics sooner, saving time later.
- **Better Communication:** While collaboration went well, more frequent updates could have streamlined the integration process across different game components.
- **Documentation:** Keeping clearer documentation of code changes and design decisions would make debugging and future iterations smoother. 


# Controls
"V" key to release the heat from ballon. (Go/Move Down)
"Space-bar" to Gather heat in balloon using the burner. (Go/Move Up)
