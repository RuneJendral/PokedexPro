# 🧩 PokédexPro WPF

A modern **Pokédex desktop application** built with **WPF (C#)** and the [PokéAPI](https://pokeapi.co/).  
Displays full Pokémon information, official artwork, dynamic type-based backgrounds, and localized names (including Japanese).
The Design is inspired by the work of [Mauro E. Wernly](https://github.com/mauroWernly).  

---

## ✨ Features
  
- 🧠 **Pokédex data fetching** — Retrieves Pokémon, abilities, moves, stats, and species info via the PokéAPI.  
- 🇯🇵 **Multilingual support** — Fetches the **Japanese Pokémon name** from the species endpoint.  
- ⚙️ **Base stat calculator** — Computes base stats and modifiers (IV/EV/Nature ready).  
- 🔢 **Number picker** — Scrollable Pokémon ID selector for quick navigation.  
- 🖼️ **Official artwork display** — Uses the high-quality sprites from the PokéAPI.  
- 💡 **Clean MVVM architecture** — Separation of concerns between UI, logic, and data access.  

---

## ⚙️ Tech Stack

| Technology                  | Description                                                                |
| --------------------------- | ---------------------------------------------------------------------------|
| **.NET 8 (WPF)**            | Framework for building the Windows desktop application                     |
| **C# 12**                   | Core programming language for application and library logic                |
| **MVVM Pattern**            | Architectural pattern separating UI, logic, and data                       |
| **System.Text.Json**        | High-performance JSON serialization and deserialization                    |
| **HttpClient**              | Handles API requests to PokéAPI                                            |
| **PokéAPI**                 | REST API providing Pokémon data, sprites, abilities, and species details   |
| **XAML**                    | UI markup language defining the interface and bindings                     |
| **ObservableCollection**    | Dynamic data collection for reactive UI updates                            |
| **Async / Await**           | Asynchronous operations for smooth, non-blocking API requests              |
