# SkyGate-Winform (HR & Attendance Management 練習作品) 👋
### 核心架構：C# WinForm | .NET Framework 4.8 | 模組化設計 (Repository Pattern)

本專案是我在學習 C# 與 .NET 期間，嘗試將過去在製造業觀察到的行政流程（如請假、加班申請）轉化為軟體的練習作品。開發重點在於實踐 **「職責分離」** 的設計原則，並建構一個易於維護的系統架構。

---

## 🛠 實作重點與技術細節 (Implementation Highlights)

### 1. 模組化架構設計 (Modular Design)
* **DAL (Repository Pattern)**：練習透過介面 (Interface) 隔離資料存取邏輯，確保系統具備替換資料庫的靈活性（支援 SQL Server / MySQL）。
* **Service Layer**：實作獨立的商業邏輯層，處理如工時計算與審核狀態流轉，確保 UI 層專注於介面呈現。
* **DTOs & Entities**：練習區分資料庫模型與前端呈現模型，提升資料處理的嚴謹性。

### 2. UI 組件化開發
* 將系統功能拆解為多個獨立的 **UserControl**（如考勤統計、請假管理），提升程式碼重用性與視窗開發的條理。
* **LayoutManager**：自主實作簡單的介面管理工具，統一系統的操作流暢度。

### 3. 業務邏輯實作
* **角色權限區分**：實作基礎的 RBAC 概念，根據登入角色（主管/員工）動態調整可視功能。
* **多階層審核邏輯流程**：模擬企業內部的單據流轉，練習處理請假與加班申請的狀態。
* **資料驗證機制**：透過自定義的 `ValidationHelper` 確保資料輸入符合基礎格式規範。

---

## 📂 技術棧 (Tech Stack)
* **Language**: C# (.NET Framework 4.8)
* **Database**: Microsoft SQL Server (ADO.NET / Entity Framework 5.0)
* **Design Patterns**: Repository Pattern, Service Layer
* **Tools**: Visual Studio, Git

---

## 💡 開發初衷
本專案的核心目標是透過模擬實際的行政作業流程，練習如何撰寫具備擴展性的程式碼架構。透過此過程，我成功掌握了從底層資料庫串接、商業邏輯封裝到前端 UI 組件化的開發全流程。

---

## 📸 系統截圖 (Screenshots)
![登入介面](images/screenshot/LoginScreen1.png)
![職務功能](images/screenshot/Functions.png)
![滑鼠追蹤](images/screenshot/Mouse_Tracking.png)
![請假申請審核](images/screenshot/LeaveRequest.png)
![加班申請審核](images/screenshot/overtime.png)
![人事管理](images/screenshot/HRM.png)
![紀錄查詢](images/screenshot/Report.png)

---


[⬅ 回到個人首頁](https://github.com/petter927/petter927)