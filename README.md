# VGA_CoinPusher

A simple, physics-based Coin Pusher game prototype built with Unity.

## 🚀 Overview
This project implements the core mechanics of a classic coin pusher game, focusing on physical interactions, resource management, and simple component communication.

## ✨ Key Features
- **Dynamic Coin Spawning**: Initial batch spawning in a defined area and real-time spawning via player input.
- **Physics-based Movement**: Pusher movement using Rigidbody physics for realistic coin interaction.
- **Resource Management**: A centralized counter tracking player coins, updated when coins fall into the "Finish" area.
- **Interactive Mechanics**: Unique parenting logic to ensure coins move smoothly when in contact with the pusher.

## 🛠 Technical Architecture

### Design Pattern: Simple Service Locator
The project uses a static bridge class `CoinMessage` to facilitate communication between the `CoinCounter` and other systems (like `CoinFactory` and `CoinPhysics`). This allows components to interact with the coin count without requiring direct hard-references to the UI or Counter object in every prefab.

### Physics & Stability
The `CoinPhysics` script employs a hybrid Trigger/Collision approach. When a coin is within the pusher's influence (Trigger) and makes physical contact (Collision), it is temporarily parented to the pusher. This technique prevents the physics "jitter" often seen when pushing high-density objects in Unity, ensuring a smooth mechanical feel.

---

## 📄 Scripts Explanation

### `CoinCounter.cs`
Manages the player's current coin balance.
- **Intent**: Centralize the game state and UI updates.
- **Mechanism**: Updates a `Text` component whenever the balance changes and registers itself to `CoinMessage`.

### `CoinFactory.cs`
Handles the creation of coin entities.
- **Intent**: Manage both the initial game state (populating the table) and player interactions.
- **Mechanism**: 
    - `Start()`: Spawns a randomized batch of coins within a gizmo-defined area.
    - `Update()`: Listens for Space key input to spawn new coins at the player's position, deducting from the counter.

### `Pusher.cs`
Controls the oscillating movement of the pusher block.
- **Intent**: Provide a consistent, physics-compliant mechanical force.
- **Mechanism**: Uses `Mathf.Sin` to calculate a smooth back-and-forth path and applies it via `Rigidbody.MovePosition` to ensure physical collisions are correctly calculated.

### `CoinPhysics.cs`
Attached to each coin to handle its lifecycle and behavior.
- **Intent**: Define how coins react to the environment and the scoring system.
- **Mechanism**:
    - **Scoring**: Detects collision with objects tagged `Finish` to increment the player's score and destroy the coin.
    - **Parenting**: Dynamically parents/unparents the coin to the `Pusher` to improve movement stability during active pushing.

---

## ⚙️ Setup Requirements

To function correctly, the following Tags must be defined in the Unity Project:
- `Pusher`: Assigned to the moving pusher object.
- `Finish`: Assigned to the trigger/collider area where coins are collected.

### Input
- **Space Key**: Spawn a new coin.
