# 📈🌡️ Real-Time Temperature Dashboard (ASP.NET MVC and IOT)

![grafik](https://github.com/user-attachments/assets/041a10b2-d48a-404f-948a-1db7fdccea7c)



A real-time Temperature Graph Dashboard built with ASP.NET CORE MVC, SignalR, and Chart.js. Data is collected using a NodeMCU ESP8266 + DHT11 Sensor sent with REST API, and visualized dynamically on a web dashboard.

🚀 Features
1. Real-time updates with SignalR
2. Live temperature monitoring from DHT11
3. Dynamic and responsive graphs using Chart.js
4. NodeMCU ESP8266 integration via HTTP POST

🛠️ Tech Stack
1. ASP.NET Core MVC (.NET 8)
2. SignalR (Real-Time Communication)
3. Entity Framework Core (MS SQL Server Database)
4. Chart.js (Frontend charting library)
5. NodeMCU ESP8266 (Microcontroller)
6. DHT11 (Temperature & Humidity Sensor)

⚙️ How to Run
1. Clone The Repository SmartTempDashboard and ArduinoCode-NODEMCU
2. Upload the code to your NodeMCU (See the README File in the Repo ArduinoCode-NODEMCU to connect the cables between NODEMCU and DHT-11 Sensor)
3. Ensure your NodeMCU sends data to: POST http://192.168.xxx.xx:xxxx/api/temperature/temperaturepost
4. Set the database Server Name (MS SQL Server) with the project under Program.cs
5. Build and Run the Project


# 🏛️ System Architecture
![grafik](https://github.com/user-attachments/assets/41c1a12d-b0c5-478b-86b5-80677ab22b29)



