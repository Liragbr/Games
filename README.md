<!DOCTYPE html>
<html lang="en">
<head>
   
<body>
    <h1>🏦 Introduction to Simple Bank API</h1>
    <p>This C# script demonstrates the implementation of a simple banking API.</p>
    <p>The API allows you to perform basic banking operations, including creating accounts, depositing and withdrawing funds, and checking balances.</p>
    <h2>Endpoints</h2>
    <p>1. <code>GET /api/ContaBancaria</code>: Retrieve information about all bank accounts.</p>
    <p>2. <code>GET /api/ContaBancaria/{id}</code>: Retrieve information about a specific bank account by providing its ID.</p>
    <p>3. <code>POST /api/ContaBancaria</code>: Create a new bank account by providing the account holder's name and initial balance.</p>
    <p>4. <code>PUT /api/ContaBancaria/{id}/deposito</code>: Make a deposit to a specific account by providing the account ID and deposit amount.</p>
    <p>5. <code>PUT /api/ContaBancaria/{id}/saque</code>: Make a withdrawal from a specific account by providing the account ID and withdrawal amount.</p>
    <p>6. <code>DELETE /api/ContaBancaria/{id}</code>: Close a bank account by providing its ID.</p>
</body>
</html>

