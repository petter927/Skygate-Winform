# Tech Debt & TODO - SkyGate WinForm

## 使用目的

本檔案只放「尚未完成」「技術風險」「優化待辦」。
已完成事項請記錄在 `DOC/DEVELOPMENT_LOG.md`。

---

## P0 - 高優先（先做）

### 1) 系統管理模組尚未落地
- 現況：`SystemManagementUserControl` 已建立但內容空白
- 影響：系統管理員缺少後台功能入口
- 建議：優先補齊角色/帳號/系統參數維護

### 2) 報表 Refresh 按鈕未實作
- 現況：`AttendanceReportUserControl.btnRefreshHistory_Click` 為空
- 影響：使用者行為與按鈕預期不一致
- 建議：至少呼叫 `LoadReportList()` 或重置條件後再查詢

### 3) 命名一致性問題
- 現況：存在 `Initialze*`, `loadOTRequstList` 等拼字與風格不一致
- 影響：閱讀成本提高，搜尋與維護不便
- 建議：逐步統一命名規範（camelCase/PascalCase）

---

## P1 - 中優先（提升穩定性）

### 1) SMTP 設定為開發環境值
- 現況：`sender@test.local` + `localhost:25`
- 風險：部署環境不可用或設定外洩
- 建議：改為設定檔/環境變數注入，並區分 Dev/Prod

### 2) Remark 字串標記耦合
- 現況：使用 `#理由-...-理由#`、`#審核結果-...-審核結果#`
- 風險：字串格式稍有變動就會解析失敗
- 建議：拆成獨立欄位或改 JSON 結構儲存

### 3) Repository 仍有占位實作
- 現況：如 `GetEmployeesByDept`、`UpdateEmployee` 尚未完整
- 風險：未來誤用造成行為不一致
- 建議：補實作或明確標示 NotImplemented

---

## P2 - 低優先（中長期優化）

### 1) 單元測試不足
- 建議：從 Service 層規則開始（請假時數、加班時數、審核流程）

### 2) 資料存取風格一致化
- 建議：逐步統一查詢與交易封裝方式，降低維護分散度

### 3) 錯誤訊息集中管理
- 建議：統一 UI 例外訊息與顯示策略，減少重複字串

---

## 後續追蹤模板

```md
## [Priority] 項目名稱
- Owner:
- Status: Todo / Doing / Done
- Impact:
- Plan:
- Done Criteria:
```
