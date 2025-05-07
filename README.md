# 📈🌡️ Real-Time Temperature and 💧 Humidity Dashboard (ASP.NET MVC and IOT)
🖥️ Live Demo:  
🔗 [https://render-smarttempdashboard.onrender.com](https://render-smarttempdashboard.onrender.com)

❗️The project is deployed on Render using a Docker container and connects to a PostgreSQL database in the deployed environment. The deployment uses a separate private GitHub repository. 

❗️This public repository is intended for local development and testing, where the application is configured to use Microsoft SQL Server Express as the database.

![Live Graph](media/Animation5.gif)
(Every 5 s)


A real-time Temperature Graph Dashboard and a full-stack IoT Project built with ASP.NET CORE MVC, SignalR, and Chart.js. Data is collected using a NodeMCU ESP8266 + DHT11 Sensor sent with REST API, and visualized dynamically on a web dashboard. The server stores the data and broadcasts it to connected clients in real-time using SignalR. 

Live Version:
The Project is containerized using Docker and deployed to Render, with a managed PostgreSQL database for persistent storage. 

🚀 Features
1. Real-time updates with SignalR
2. Live temperature monitoring from DHT11
3. Dynamic and responsive graphs using Chart.js
4. NodeMCU ESP8266 integration via HTTP POST

🛠️ Tech Stack
1. ASP.NET Core MVC (.NET 8)
2. SignalR (Real-Time Communication)
3. AJAX (Asynchronous JavaScript and XML) – Fetches 3-day average temperature data from the backend without reloading the page
4. Entity Framework Core (MS SQL Server Express Database) / Online Version (Postgresql)
5. Chart.js (Frontend charting library)
6. NodeMCU ESP8266 (Microcontroller)
7. DHT11 (Temperature & Humidity Sensor)

⚙️ How to Run
1. Clone The Repository SmartTempDashboard and ArduinoCode-NODEMCU
2. Upload the code to your NodeMCU (See the README File in the Repo ArduinoCode-NODEMCU to connect the cables between NODEMCU and DHT-11 Sensor)
3. Ensure your NodeMCU sends data to: POST http://xxxxxx/api/temperature/temperaturepost
4. Set the database Server Name (MS SQL Server) with the project under Program.cs
5. Build and Run the Project


# 🏛️ System Architecture
![grafik](https://github.com/user-attachments/assets/41c1a12d-b0c5-478b-86b5-80677ab22b29)



