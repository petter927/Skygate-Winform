# Development Log - SkyGate WinForm

本檔案只記錄「開發進度與決策時間軸」。
架構與模組說明請看 `DOC/SYSTEM_OVERVIEW.md`。
未完成事項與風險請看 `DOC/TECH_DEBT.md`。

---

## 使用方式 (Template)

```md
## YYYY-MM-DD
- Done:
  - ...
- Why:
  - ...
- Next:
  - ...
- Verify:
  - ...
```

---

## 2026-03-27
- Done:
  - 將原本單一 `DEVELOPMENT_LOG.md` 重新拆分為三份文件。
  - 建立 `SYSTEM_OVERVIEW.md`（集中架構、資料流、模組設計與回坑導覽）。
  - 建立 `TECH_DEBT.md`（集中未完成項目、技術債、優先級）。
  - 將本檔精簡為時間序進度紀錄格式，降低閱讀成本。
- Why:
  - 原文件同時承載「進度 + 架構 + TODO」，長期維護會變得難查與難更新。
  - 拆分後可讓日誌維持簡短，並讓知識文件各司其職。
- Next:
  - 之後每次開發僅更新本檔當日區塊。
  - 重大架構變更時更新 `SYSTEM_OVERVIEW.md`。
  - 新增/清除技術債時更新 `TECH_DEBT.md`。
- Verify:
  - 檢查三份文件內容是否分工明確且可互相參照。