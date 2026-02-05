# in-Krypt: Decentralized P2P Lending Platform

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-blue)
![Ethereum](https://img.shields.io/badge/Blockchain-Ethereum-8C8C8C)

**in-Krypt** is an automated, decentralized Peer-to-Peer (P2P) lending platform designed to provide secure, transparent, and collateral-backed financial transactions. By leveraging Ethereum smart contracts and the .NET framework, in-Krypt allows users to borrow funds against their crypto assets without the need for traditional credit checks.

---

## 🚀 Key Features

- **Collateral-Backed Loans**: Borrow fiat/stable funds by locking Ether (ETH) as collateral.
- **Smart Contract Escrow**: (Planned) Trustless holding of assets during the loan lifecycle.
- **Instant Loan Calculator**: Real-time calculation of interest rates and collateral requirements based on loan duration:
    - **3 Months**: 5% Interest | 0.0001 ETH Collateral
    - **6 Months**: 10% Interest | 0.0002 ETH Collateral
    - **1 Year**: 15% Interest | 0.00035 ETH Collateral
- **Seamless Repayments**: Integrated with Razorpay for secure and easy loan repayments.
- **Zero Credit Score Impact**: Loan eligibility is determined solely by crypto holdings.

---

## 🛠️ Tech Stack

- **Backend**: ASP.NET Web Forms (.NET Framework 4.7.2)
- **Database**: Microsoft SQL Server
- **Blockchain Interface**: Ether-based collateral logic (Nethereum integration recommended)
- **Payment Gateway**: Razorpay API
- **Frontend**: Bootstrap 3, jQuery, Vanilla CSS

---

## 🏗️ Architecture Overview

in-Krypt follows a classic N-tier architecture optimized for blockchain interaction:

1.  **Presentation Layer**: Web Forms (`.aspx`) providing a user-friendly interface for loan management.
2.  **Logic Layer**: C# Backend handling collateral calculations, user sessions, and payment processing.
3.  **Data Layer**: SQL Server for user profiles, loan history, and platform metrics.
4.  **Blockchain Layer**: (Conceptual/Upcoming) Ethereum network for collateral locking and interest distribution.

---

## ⚙️ Getting Started

### Prerequisites
- Visual Studio 2019 or newer
- .NET Framework 4.7.2 SDK
- SQL Server (LocalDB or Express)

### Installation
1.  **Clone the Repository**:
    ```bash
    git clone https://github.com/your-repo/in-Krypt.git
    cd in-Krypt
    ```
2.  **Database Setup**:
    - Update the `connectionString` in `Web.config` to point to your local SQL Server instance.
    - Run the migration scripts or update the `inKryptDataSet` to initialize the `inKryptDB`.
3.  **Restore Packages**:
    Open the solution in Visual Studio and allow NuGet to restore missing packages (Razorpay, EntityFramework, etc.).
4.  **Run the Project**:
    Press `F5` or click **Start** in Visual Studio to launch the application.

---

## 📝 Usage

1.  **Register/Login**: Create an account to access the lending dashboard.
2.  **Calculate Loan**: Navigate to the Calculator to see how much Ether is required for your desired loan amount.
3.  **Submit Collateral**: (Simulated) Transfer ETH to the platform's escrow address.
4.  **Receive Loan**: Once collateral is verified, the loan is processed.
5.  **Repay & Unlock**: Use the Repayment portal to pay back the loan and reclaim your ETH.

---

## 🛡️ Security

- **ASP.NET Identity**: Secure user authentication and membership management.
- **Tls 1.2 Integration**: Ensured for all payment gateway communications.
- **Collateral Safeguards**: (Planned) Smart contracts prevent manual interference with locked assets.

---

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

---
