# Genpact Automation Assignment – Wisam Okkeh

This repository contains my solution for the **Automation Infrastructure Assignment**.

---

## 🧩 Tech Stack
- **Language:** C#
- **Framework:** NUnit
- **Automation:** Selenium WebDriver (Chrome)
- **API:** MediaWiki Parse API (via `HttpClient`)
- **Reporting:** ExtentReports (HTML report generated for each run)

---

## 📄 Report
Each test run automatically generates a timestamped HTML report under:
    Reports/report_yyyy-MM-dd_HH-mm-ss.html
The report includes:
  - Test status (✅ Passed / ❌ Failed)
  - Detailed logs (which item failed or passed)



## ▶️ Run Instructions
1. Clone the repo:
   ```bash
   git clone https://github.com/wisamokkeh/genpact_assignment_wisam_okkeh-.git
   
2. Open the solution in Visual Studio or run from terminal:
   ```bash
    dotnet test

4. After tests finish, open the latest report from:
   ```bash
    /Reports/report_<timestamp>.html


💡 Author: Wisam Okkeh

🕹️ Assignment: Genpact Automation Infrastructure Test
