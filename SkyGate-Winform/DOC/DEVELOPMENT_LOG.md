# 🚀 開發筆記 (Development Log) - SkyGate WinForm

## 📂 系統分層架構設計 (System Architecture)

為了實現 **「高內聚、低耦合」** 的開發目標，本專案捨棄了將邏輯全部擠在 UI 層的傳統做法，改採 **N-Tier (多層次) 架構** 設計。這確保了程式碼的可維護性，並為日後遷移至 Web 平台奠定了紮實基礎。

### 1. UI Layer (展示層)
* **組成**：`MainForm`、各種功能的 `UserControl`（如 `HRManagementUserControl`）。
* **職責**：專注於使用者互動與資料呈現。
* **技術決策**：
    * 透過 **事件驅動** 呼叫 Service 層。
    * 導入 `LayoutManager` 實作 **宣告式佈局**，統一管理控制項的顯示狀態與座標。

### 2. Service Layer (商業邏輯層)
* **組成**：`EmployeeService.cs` 等。
* **職責**：系統的「大腦」，負責處理核心業務規則。
* **技術決策**：
    * 封裝複雜邏輯（如：工時計算、多階層審核狀態流轉）。
    * 作為 UI 與 DAL 之間的橋樑，確保 UI 層不直接接觸資料庫實作。

### 3. DAL / Repository Layer (資料存取層)
* **組成**：`SqlHelper.cs`、`EmployeeRepository.cs` 等。
* **職責**：專門負責與 SQL Server 溝通，執行 CRUD 操作。
* **技術決策**：
    * **介面導向開發 (Interface-Based)**：定義 `IRepository` 介面，降低系統對特定資料庫的依賴。
    * **參數化查詢**：全面使用 `SqlParameter` 杜絕 SQL Injection 風險。
    * **事務管理**：利用 `SqlTransaction` 確保跨表操作的 **原子性 (Atomicity)**。

### 4. Models & Utilities (模型與工具)
* **Models**：定義 `Entity` (DB對應) 與 `DTO` (傳輸用)，確保層級間資料傳遞的嚴謹性。
* **Utilities**：
    * `ValidationHelper`：利用 **正規表示法 (Regex)** 進行門神級的資料預檢。
    * `LayoutManager`：解決 WinForm 佈局難以維護的痛點。

---

## 🔄 資料流向示意 (Data Flow)
`使用者輸入 (UI)` ➔ `格式驗證 (Utility)` ➔ `業務邏輯處理 (Service)` ➔ `資料庫操作 (Repository/DAL)` ➔ `SQL Server`