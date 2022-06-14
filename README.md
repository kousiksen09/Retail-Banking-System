# Retail-Banking-System
One of the largest and leading Retail Bank within the US, serving millions of customers across the country offering a range of financial products from Credit Cards, Savings &amp; Checking accounts, Auto loans, small business &amp; commercial accounts. The retail bank has historically been served by a large monolith system. This system has Customer information, Transaction information, Account information – Pretty much a ledger generating taxes &amp; statements. The bank is looking for a solution that will provide resilience &amp; scalability for future growth. Following are the required features: • Highly available • Highly scalable • Highly Performant • Easily built and maintained • Developed and deployed quickly
**How to run the project in local?**
Please follow the below steps-
1) Open a microservice like "UserMicroService".
2) change the connection string in appsettings.json with you localhost sql server name.
3) Repeat the above 2 steps for all microservice.
4) In the Pacakage manager console Select UserMicroservice from default project dropdown.
5) write the command Update-Database & Hit Enter.
6) Repeat 4 & 5 steps for Account & Transaction Microservice.
7) Open Sql Server management studio and insert a admin credentials in the UserCreds table.
8) Run the project.
9) Login with Admin Username & Password.
10) Create a account by clicking the Create account button.
11) You will get the Username, Password & CustomerId for the customer. Kept it in Notepad.
12) Perform some transactions.
13) Go back to the login page.
14) Login with Username, Password & CustomerId by selecting customer from the dropdown.
15) Perform the Customer related activity.

This project contains email & sms functionality by default.
If you don't want this functionality comment the appropiate code in Retail_Bank_UI -> TransactionController -> Deposit, Withdraw, Transfer Method which is self explanatory.
**Without commenting this code you may got exception while performing Deposit, Withdraw, Transfer functionality.**
